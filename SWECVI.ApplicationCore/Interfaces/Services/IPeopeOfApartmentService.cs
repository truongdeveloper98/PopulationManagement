using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SWECVI.ApplicationCore.Entities.Building_Resident;
using SWECVI.ApplicationCore.ViewModels;

namespace SWECVI.ApplicationCore.Interfaces.Services
{
    public interface IPeopeOfApartmentService
    {
        Task<bool> CreatePeopleOfApartment(PeopleOfApartmentDto model);
        Task<bool> DeletePeopleOfApartment(int id);
        Task<bool> UpdatePeopleOfApartment(int id, PeopleOfApartmentDto model);
        Task<PeopleOfApartmentDto> GetPeopleOfApartmentById(int id);
        Task<PagedResponseDto<PeopleOfApartmentDto>> GetAllPeopleOfApartment(PagedRequestDto model);
    }
}
