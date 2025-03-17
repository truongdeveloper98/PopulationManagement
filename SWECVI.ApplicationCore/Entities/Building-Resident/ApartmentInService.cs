using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWECVI.ApplicationCore.Entities.Building_Resident
{
    public class ApartmentInService : BaseEntity
    {
        public int DepartmentId { get; set; }
        public Apartment? Apartment { get; set; } 
        public int ServiceId { get; set; }
        public Service? ServiceApartment { get; set; } 

    }
}
