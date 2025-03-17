using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWECVI.ApplicationCore.Entities
{
    public class Staff
    {
        public string Name { get; set; } = default!;
        public string StaffId { get; set; } = default!;
        public string Email { get; set; } = default!;
        public string? PhoneNumber { get; set; }
        public string Position { get; set; } = default!;
        public string? NationalId { get; set; }
        public string?  Address { get; set; }
        public int DepartmentId { get; set; }
        public Department? Department { get; set; }
    }
}
