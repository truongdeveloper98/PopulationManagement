using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SWECVI.ApplicationCore.ViewModels;

namespace SWECVI.ApplicationCore.Interfaces.Services
{
    public interface IPriceListService
    {
        Task<bool> CreatePriceList(PriceListDto model);
        Task<bool> UpdatePriceList(int id, PriceListDto model);
        Task<bool> DeletePriceList(int id);
        Task<PriceListDto> GetPriceListById(int id);
        Task<PagedResponseDto<PriceListDto>> GetAllPriceLists(PagedRequestDto model);
    }
}
