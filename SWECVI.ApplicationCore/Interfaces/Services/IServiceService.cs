using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SWECVI.ApplicationCore.ViewModels;

namespace SWECVI.ApplicationCore.Interfaces.Services
{
    public interface IServiceService
    {
        Task<bool> CreateService(ServiceDto model);
        Task<bool> DeleteService(int id);
        Task<bool> UpdateService(int id, ServiceDto model);
        Task<ServiceDto> GetServiceById(int id);
        Task<PagedResponseDto<ServiceDto>> GetAllServices(PagedRequestDto model);
    }
}
