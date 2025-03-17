using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWECVI.ApplicationCore.Entities
{
    public class Department : BaseEntity
    {
        public string Name { get; set; } = default!;
        public string DepartmentId { get; set; } = default!;
        public string? Description { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Email { get; set; }
        public int ManagerId { get; set; }
        public bool IsStatus { get; set; }
        public bool IsCommentStatus { get; set; }
        public bool IsNotifyStatus { get; set; }
        public bool IsReceiveJobStatus { get; set; }
        public AppUser DepartmentManager { get; set; } = default!;
        public ContactInformation ContactInformationManager { get; set; } = default!;
        public ICollection<Staff> Staffs { get; set; } = default!;
    }
}
