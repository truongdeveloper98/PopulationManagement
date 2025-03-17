using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWECVI.ApplicationCore.Entities.Building_Resident
{
    public class DocumentOfApartment : BaseEntity
    {
        public string?  Category { get; set; }
        public string? FilePath { get; set; }
        public string? Description { get; set; }
    }
}
