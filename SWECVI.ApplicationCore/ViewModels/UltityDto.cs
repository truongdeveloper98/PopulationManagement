using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static SWECVI.ApplicationCore.Enum;

namespace SWECVI.ApplicationCore.ViewModels
{
    public class UltityDto
    {
        public int  Id { get; set; }
        public string UltityId { get; set; } = default!;
        public string Name { get; set; } = default!;
        public double Price { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public string UseTime { get; set; } = default!;
        public Date OpenDate { get; set; }
        public string? Note { get; set; }
        public string? Commitment { get; set; }
        public bool IsStatus { get; set; }
    }
}
