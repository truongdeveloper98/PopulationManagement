using System;
using System.Collections.Generic;
using System.Linq;
using SWECVI.ApplicationCore.Entities.Building_Resident;
using static SWECVI.ApplicationCore.Enum;

namespace SWECVI.ApplicationCore.Entities
{
    public class BuildingInformation : BaseEntity
    {
        public string Name { get; set; } = default!;
        public string BuildingId { get; set; } = default!;
        public BuildingStatus Status { get; set; }
        public ICollection<FloorInformation>? Floors { get; set; }
        public ICollection<Apartment>? Apartments { get; set; } 
    }
}
