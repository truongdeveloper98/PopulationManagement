using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWECVI.ApplicationCore.Entities
{
    public class PaymentInformation : BaseEntity
    {
        public string BankAccountNumber { get; set; } = default!;
        public string BankName { get; set; } = default!;
        public string AccountName { get; set; } = default!;
        public string? BankBranch { get; set; }
        public bool IsAutomaticTransactions { get; set; }
        public bool IsAutomaticAccounting { get; set; }
    }
}
