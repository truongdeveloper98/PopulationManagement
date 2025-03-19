using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static SWECVI.ApplicationCore.Enum;

namespace SWECVI.ApplicationCore.Entities.Building_Resident
{
    public class Apartment : BaseEntity
    {
        public string Name { get; set; } = default!;
        public string ApartmentId { get; set; } = default!;
        public int BuildingId { get; set; }
        public int FloorId { get; set; }
        public string? ElectricId { get; set; }
        public string? WaterId { get; set; }
        public string Area { get; set; } = default!;
        public int NumberOfBedroom { get; set; }
        public string? ApplicationFee { get; set; }
        public int CustomerId { get; set; }
        public int Population {  get; set; }
        public double Price { get; set; } = 6600;
        public string? Description { get; set; }
        public StatusApartment Status { get; set; }
        public AppUser? Customer { get; set; }
        public BuildingInformation? BuildingInformation { get; set; }
        public FloorInformation? FloorInformation { get; set; }
        public ICollection<ApartmentInService>? ApartmentInServices { get; set; }
        public ICollection<PeopleOfApartment>? PeopleOfApartments { get; set; }
        public ICollection<Vehicle>? Vehicles { get; set; }
    }
}
