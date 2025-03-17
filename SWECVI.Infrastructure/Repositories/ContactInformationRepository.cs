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
    public class ContactInformationRepository : RepositoryBase<ContactInformation>, IContactInformationRepository
    {
        public ContactInformationRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
