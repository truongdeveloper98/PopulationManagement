using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWECVI.ApplicationCore.ViewModels
{
    public class ContactInformationDto
    {
        public int Id { get; set; }
        public string TownName { get; set; } = default!;
        public string Address { get; set; } = default!;
        public string? AddressForPay { get; set; }
        public string PhoneNumber { get; set; } = default!;
        public string Email { get; set; } = default!;
        public string? Introduce { get; set; }
        public DateTime DateLock { get; set; }
        public int DepartmentId { get; set; }
        public string? DerpartmentName { get; set; }
    }
}
