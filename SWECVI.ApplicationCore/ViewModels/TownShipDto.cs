using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWECVI.ApplicationCore.ViewModels
{
    public class TownShipDto
    {
        public int Id { get; set; }
        public string TownShipId { get; set; } = default!;
        public string Name { get; set; } = default!;
        public string? CompanyName { get; set; }
        public string? CompanyId { get; set; }
    }

    public class TownShipForSelectionDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = default!;
    }
}
