using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SWECVI.ApplicationCore.ViewModels;

namespace SWECVI.ApplicationCore.Interfaces.Services
{
    public interface IUltityService
    {
        Task<bool> CreateUltity(UltityDto model);
        Task<bool> DeleteUltity(int id);
        Task<bool> UpdateUltity(int id, UltityDto model);
        Task<UltityDto> GetUltityById(int id);
        Task<PagedResponseDto<UltityDto>> GetAllUltitys(PagedRequestDto model);
    }
}
