using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SWECVI.ApplicationCore.Entities;
using SWECVI.ApplicationCore.Interfaces.Repositories;
using SWECVI.Infrastructure.Data;

namespace SWECVI.Infrastructure.Repositories
{
    public class BuildingRepository : RepositoryBase<BuildingInformation>, IBuildingRepository
    {
        public BuildingRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
