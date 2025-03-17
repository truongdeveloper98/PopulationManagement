using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using SWECVI.ApplicationCore.Entities;
using System.Linq.Expressions;
using System.Reflection;

namespace SWECVI.Infrastructure.Data
{
    public class ApplicationDbContext : IdentityDbContext<AppUser, AppRole, int>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<AppUser> AppUsers { get; set; } = default!;
        public DbSet<User> HospitalUsers { get; set; } = default!;
        public DbSet<AppRole> AppRoles { get; set; } = default!;
        public DbSet<SystemLog> SystemLogs { get; set; } = default!;
        public DbSet<Job> Jobs { get; set; } = default!;
        public DbSet<Company> Companies {get; set;} = default!;
        public DbSet<TownShip> TownShips { get; set; } = default!;
        public DbSet<PaymentInformation> PaymentInformations {  get; set; } = default!;
        public DbSet<Project> Projects { get; set; } = default!;
        public DbSet<ProjectInformation> ProjectInformations { get; set; } = default!;
        public DbSet<ContactInformation> ContactInformations { get; set; } = default!;
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Company>()
                   .HasMany(e => e.TownShips)
                   .WithOne(e => e.Company)
                   .HasForeignKey(e => e.CompanyId);
                
            builder.Entity<TownShip>()
                   .HasMany(e => e.Projects)
                   .WithOne(e => e.TownShip)
                   .HasForeignKey(e => e.TownShipId);

            AddSoftDeleteFilters(builder);
        }

        protected static void AddSoftDeleteFilters(ModelBuilder builder)
        {
            foreach (var entityType in builder.Model.GetEntityTypes())
            {
                //other automated configurations left out
                if (typeof(BaseEntity).IsAssignableFrom(entityType.ClrType))
                {
                    entityType.AddSoftDeleteQueryFilter();
                }
            }
        }
        public override int SaveChanges()
        {
            UpdateEntityState();
            return base.SaveChanges();
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            UpdateEntityState();
            return base.SaveChangesAsync(cancellationToken);
        }

        private void UpdateEntityState()
        {
            var now = DateTime.UtcNow;

            foreach (var changedEntity in ChangeTracker.Entries())
            {
                if (changedEntity.Entity is BaseEntity entity)
                {
                    switch (changedEntity.State)
                    {
                        case EntityState.Added:
                            entity.CreatedAt = now;
                            entity.UpdatedAt = now;
                            break;
                        case EntityState.Modified:
                            Entry(entity).Property(x => x.CreatedAt).IsModified = false;
                            entity.UpdatedAt = now;
                            break;
                        case EntityState.Deleted:
                            entity.IsDeleted = true;
                            entity.DeletedAt = now;
                            changedEntity.State = EntityState.Modified;
                            break;
                    }
                }
            }
        }
    }

    public static class SoftDeleteQueryExtension
    {
        public static void AddSoftDeleteQueryFilter(
             this IMutableEntityType entityData)
        {
            var methodToCall = typeof(SoftDeleteQueryExtension)
                .GetMethod(nameof(GetSoftDeleteFilter),
                    BindingFlags.NonPublic | BindingFlags.Static)
                ?.MakeGenericMethod(entityData.ClrType);
            var filter = methodToCall?.Invoke(null, new object[] { });
            if (filter != null)
            {
                entityData.SetQueryFilter((LambdaExpression)filter);
            }
        }

        private static LambdaExpression GetSoftDeleteFilter<TEntity>()
            where TEntity : BaseEntity
        {
            Expression<Func<TEntity, bool>> filter = x => !x.IsDeleted;
            return filter;
        }
    }
}
