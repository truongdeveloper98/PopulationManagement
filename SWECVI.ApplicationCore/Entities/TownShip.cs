using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWECVI.ApplicationCore.Entities
{
    public class TownShip : BaseEntity
    {
        public string TownShipId { get; set; } = default!;
        public string Name { get; set; } = default!;
        public int CompanyId { get; set; } = default!;
        public Company Company { get; set; } = default!;
        public ICollection<Project>? Projects { get; set; }
    }
}
