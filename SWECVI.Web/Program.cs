using System.Text;
using SWECVI.Infrastructure.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using SWECVI.Web.DependencyInjection;
using SWECVI.Web.Middlewares;
using SWECVI.ApplicationCore.Entities;
using Elastic.Clients.Elasticsearch;
using Elastic.Transport;

var builder = WebApplication.CreateBuilder(args);
ConfigurationManager configuration = builder.Configuration;

// Register HttpContextAccessor
builder.Services.AddHttpContextAccessor();

// Configure CORS
builder.Services.AddCors(option =>
{
    option.AddPolicy("_myAllowSpecificOrigins", builder =>
    {
        builder.AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader();
    });
});

// Configure DbContext with environment-specific settings
builder.Services.AddDbContext<ApplicationDbContext>(optionsAction =>
{
    if (Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") == "Stage")
    {
        var envConnectionString = Environment.GetEnvironmentVariable("ADMIN_CONNECTION_STRING");
        if (String.IsNullOrEmpty(envConnectionString))
        {
            optionsAction.UseSqlServer(configuration.GetConnectionString("DefaultConnection"), b => b.MigrationsAssembly("SWECVI.Database"));
        }
        else
        {
            optionsAction.UseSqlServer(envConnectionString, b => b.MigrationsAssembly("SWECVI.Database"));
        }
    }
    else
    {
        optionsAction.UseSqlServer(configuration.GetConnectionString("DefaultConnection"), b => b.MigrationsAssembly("SWECVI.Database"));
    }
});

// Configure Identity with user and role management
builder.Services.AddIdentity<AppUser, AppRole>().AddEntityFrameworkStores<ApplicationDbContext>()
    .AddDefaultTokenProviders();

var jwtKey = configuration["JwtKey"] ?? string.Empty;

// Configure JWT Authentication
JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Clear(); // Remove default claims
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
})
    .AddJwtBearer(options =>
    {
        options.SaveToken = true;
        options.RequireHttpsMetadata = false;
        options.TokenValidationParameters = new TokenValidationParameters()
        {
            ValidAudience = configuration["JwtIssuer"],
            ValidIssuer = configuration["JwtIssuer"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtKey))
        };
    });

builder.Services.AddControllers();

// Register custom services
builder.Services.ConfigureAppServices();

// Add memory cache
builder.Services.AddMemoryCache();

// Configure Swagger for API documentation
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure middleware pipeline
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseCors("_myAllowSpecificOrigins");
}

app.UseHttpsRedirection();

// Configure custom exception handling middleware
app.ConfigureExceptionHandler(app.Environment, app.Logger);

// Configure authentication and authorization
app.UseAuthentication();
app.UseAuthorization();
app.UseStaticFiles();
app.MapControllers();

// Fallback to index.html for SPA
app.MapFallbackToFile("index.html");

app.Run();
