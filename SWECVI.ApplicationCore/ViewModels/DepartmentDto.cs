using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWECVI.ApplicationCore.ViewModels
{
    public class DepartmentDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = default!;
        public string DepartmentId { get; set; } = default!;
        public string? Description { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Email { get; set; }
        public int ManagerId { get; set; }
        public string ManagerName { get; set; }
    }
}
