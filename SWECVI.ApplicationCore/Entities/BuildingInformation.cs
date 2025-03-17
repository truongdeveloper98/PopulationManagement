using System;
using System.Collections.Generic;
using System.Linq;
using SWECVI.ApplicationCore.Entities.Building_Resident;

namespace SWECVI.ApplicationCore.Entities
{
    public class BuildingInformation : BaseEntity
    {
        public string Name { get; set; } = default!;
        public string BuildingId { get; set; } = default!;
        public string Status { get; set; } = default!;
        public ICollection<FloorInformation>? Floors { get; set; }
        public ICollection<Apartment>? Apartments { get; set; } 
        public ICollection<Vehicle>? Vehicles { get; set; } 
        public ICollection<VehicleCard>? VehicleCards { get; set; }
    }
}
