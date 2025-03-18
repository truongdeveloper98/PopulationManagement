using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static SWECVI.ApplicationCore.Enum;

namespace SWECVI.ApplicationCore.ViewModels
{
    public class BuildingDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = default!;
        public string BuildingId { get; set; } = default!;
        public BuildingStatus Status { get; set; } = default!;
    }
    public class BuildingForSelectionDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = default!;
    }
}
