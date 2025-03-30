using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static SWECVI.ApplicationCore.Enum;

namespace SWECVI.ApplicationCore.ViewModels
{
    public class PeopleOfApartmentDto
    {
        public int Id { get; set; }
        public int AppUserId { get; set; }
        public string FirstName { get; set; } = default!;
        public string LastName { get; set; } = default!;
        public string? NationalId { get; set; }
        public DateTime Dob { get; set; }
        public Gender Gender { get; set; }
        public string? PhoneNumberUser { get; set; }
        public string? EmailUser { get; set; }
        public RelationShip Relationship { get; set; }
        public int ApartmentId { get; set; }
        public string? ApartmentName { get; set; }
    }
}
