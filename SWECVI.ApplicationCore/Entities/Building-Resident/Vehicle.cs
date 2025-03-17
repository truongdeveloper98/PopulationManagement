using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static SWECVI.ApplicationCore.Enum;

namespace SWECVI.ApplicationCore.Entities.Building_Resident
{
    public class Vehicle : BaseEntity
    {
        public string VehicleCode { get; set; } = default!;
        public TypeOfVehicle TypeOfVehice { get; set; }
        public string NumberPlate { get; set; } = default!;
        public VehicleColor Color { get; set; }
        public int VehicleCardId { get; set; }
        public string? Description { get; set; }
        public int BuildingId { get; set; }
        public int ApartmentId { get; set; }
        public int VehicleOwnerId { get; set; }
        public int ServiceId { get; set; }
        public DateTime ApplyFeeDate { get; set; }
        public DateTime EndFeeDate { get; set; }
        public FeeLevel FeeLevel { get; set; }
        public BuildingInformation? Building { get; set; }
        public Apartment? Apartment { get; set; }
        public AppUser? AppUser { get; set; }
        public Service? Service { get; set; }
    }
}
