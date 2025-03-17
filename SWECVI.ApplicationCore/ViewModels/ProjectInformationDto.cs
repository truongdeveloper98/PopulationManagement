using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWECVI.ApplicationCore.ViewModels
{
    public class ProjectInformationDto
    {
        public int Id { get; set; }
        public string Content { get; set; } = default!;
        public int Quantity { get; set; }
        public string? Note { get; set; }
    }
}
