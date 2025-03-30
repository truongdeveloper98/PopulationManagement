using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static SWECVI.ApplicationCore.Enum;

namespace SWECVI.ApplicationCore.ViewModels
{
    public class PriceListDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = default!;
        public string PriceListCode { get; set; } = default!;
        public int ServiceId { get; set; }
        public string? ServiceName { get; set; }
        public DateTime ApplyDate { get; set; }
        public TypeOfFee TypeOfFee { get; set; }
        public double Price { get; set; }
    }
}
