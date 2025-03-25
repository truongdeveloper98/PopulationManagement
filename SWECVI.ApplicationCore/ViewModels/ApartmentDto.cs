using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static SWECVI.ApplicationCore.Enum;

namespace SWECVI.ApplicationCore.ViewModels
{
    public class ApartmentDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = default!;
        public string ApartmentId { get; set; } = default!;
        public int FloorId { get; set; }
        public string? FloorName { get; set; }
        public string? ElectricId { get; set; }
        public string? WaterId { get; set; }
        public string Area { get; set; } = default!;
        public int NumberOfBedroom { get; set; }
        public int CustomerId { get; set; }
        public string? CustomerName { get; set; }
        public int Population { get; set; }
        public StatusApartment Status { get; set; }
        public string? Description { get; set; }
    }
}
