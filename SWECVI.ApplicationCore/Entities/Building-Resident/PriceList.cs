using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static SWECVI.ApplicationCore.Enum;

namespace SWECVI.ApplicationCore.Entities.Building_Resident
{
    public class PriceList : BaseEntity
    {
        public string Name { get; set; } = default!;
        public string PriceListCode { get; set; } = default!;
        public int ServiceId { get; set; }
        public DateTime ApplyDate { get; set; }
        public TypeOfFee TypeOfFee { get; set; }
    }
}
