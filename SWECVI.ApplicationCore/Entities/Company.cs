using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWECVI.ApplicationCore.Entities
{
    public class Company : BaseEntity
    {
        public string CompanyId { get; set; } = default!;
        public string Name { get; set; } = default!;
        public ICollection<TownShip>? TownShips { get; set; }
    }
}
