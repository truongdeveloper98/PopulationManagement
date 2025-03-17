using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static SWECVI.ApplicationCore.Enum;

namespace SWECVI.ApplicationCore.Entities
{
    public class Ultity : BaseEntity
    {
        public string UltityId { get; set; } = default!;
        public string Name { get; set; } = default!;
        public double Price { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string UseTime { get; set; } = default!;
        public Date OpenDate { get; set; }
        public string? Note { get; set; }
        public string? Commitment { get; set; }
        public bool IsStatus { get; set; }
    }
}
