using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SWECVI.ApplicationCore.ViewModels;

namespace SWECVI.ApplicationCore.Interfaces.Services
{
    public interface IApartmentService
    {
        Task<bool> CreateApartment(ApartmentDto model);
        Task<bool> UpdateApartment(int id, ApartmentDto model);
        Task<bool> DeleteApartment(int id);
        Task<ApartmentDto> GetApartmentById(int id);
        Task<PagedResponseDto<ApartmentDto>> GetAllApartments(PagedRequestDto model);
    }
}
