using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static SWECVI.ApplicationCore.Enum;

namespace SWECVI.ApplicationCore.Entities.Building_Resident
{
    public class PeopleOfApartment : BaseEntity
    {
        public int AppUserId { get; set; }
        public string Name { get; set; } = default!;
        public string? NationalId { get; set; }
        public DateTime Dob { get; set; }
        public Gender Gender {  get; set; }
        public RelationShip Relationship { get; set; } 
        public User? AppUser { get; set; }
        public int ApartmentId { get; set; }
        public Apartment? Apartment { get; set; }

    }
}
