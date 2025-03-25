using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SWECVI.ApplicationCore.Entities.Building_Resident;
using SWECVI.ApplicationCore.Interfaces.Repositories;
using SWECVI.Infrastructure.Data;

namespace SWECVI.Infrastructure.Repositories
{
    public class ApartmentRepository : RepositoryBase<Apartment>, IApartmentRepository
    {
        public ApartmentRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
