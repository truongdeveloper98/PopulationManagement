using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static SWECVI.ApplicationCore.Enum;

namespace SWECVI.ApplicationCore.Entities.Building_Resident
{
    public class VehicleCard : BaseEntity
    {
        public string VehicleCardCode { get; set; } = default!;
        public TypeOfVehicle TypeOfVehicle { get; set; }
        public int VehicleId { get; set; }
        public int BuildingId { get; set; }
        public int ApartmentId { get; set; }
        public string? Note { get; set; }
        public Vehicle? Vehicle { get; set; }
        public BuildingInformation? BuildingInformation { get; set; }
        public Apartment? Apartment { get; set; }
    }
}
