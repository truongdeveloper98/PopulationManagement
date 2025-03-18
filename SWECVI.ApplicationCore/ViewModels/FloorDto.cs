using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWECVI.ApplicationCore.ViewModels
{
    public class FloorDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = default!;
        public string FloorId { get; set; } = default!;
        public int BuildingId { get; set; }
        public string? BuildingName { get; set; }
    }
}
