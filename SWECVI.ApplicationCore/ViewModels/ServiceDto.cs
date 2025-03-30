using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static SWECVI.ApplicationCore.Enum;

namespace SWECVI.ApplicationCore.ViewModels
{
    public class ServiceDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = default!;
        public string ServiceCode { get; set; } = default!;
        public TypeOfObject TypeOfObject { get; set; }
        public TypeOfService TypeOfService { get; set; }
        public string? Description { get; set; }
        public Cycle Cycle { get; set; }
        public Date PayDate { get; set; }
        public Date FirstDate { get; set; }
        public PriceCalculationMethod StartPriceCaculationMethod { get; set; }
        public PriceCalculationMethod EndPriceCaculationMethod { get; set; }
        public Date ApplyFrom { get; set; }
        public Date SwitchDay { get; set; }
    }
}
