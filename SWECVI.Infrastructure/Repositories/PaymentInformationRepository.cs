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
    public class PaymentInformationRepository : RepositoryBase<PaymentInformation>, IPaymentInformationRepository
    {
        public PaymentInformationRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
