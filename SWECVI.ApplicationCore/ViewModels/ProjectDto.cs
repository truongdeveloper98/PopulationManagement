using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SWECVI.ApplicationCore.Entities;

namespace SWECVI.ApplicationCore.ViewModels
{
    public class ProjectDto
    {
        public int Id { get; set; }
        public string ProjectId { get; set; } = default!;
        public string Name { get; set; } = default!;
        public string OperationId { get; set; } = default!;
        public string TownShipId { get; set; } = default!;
        public string TownShipName { get; set; } = default!;
        public string? Description { get; set; }
        public string Address { get; set; } = default!;
        public string PhoneNumber { get; set; } = default!;
        public string Email { get; set; } = default!;
        public DateTime DateLock { get; set; }
        public string? ManagerId { get; set; }
        public string ManagerName { get; set; } = default!;
    }
}
