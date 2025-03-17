using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SWECVI.ApplicationCore.Entities.Building_Resident;

namespace SWECVI.ApplicationCore.Entities
{
    public class FloorInformation : BaseEntity
    {
        public string Name { get; set; } = default!;
        public string FloorId { get; set; } = default!;
        public int BuildingId { get; set; }
        public BuildingInformation BuildingInformation { get; set; } = default!;
        public ICollection<Apartment> Apartments { get; set; } = default!;
    }
}
