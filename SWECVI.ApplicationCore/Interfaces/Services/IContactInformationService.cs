using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SWECVI.ApplicationCore.ViewModels;

namespace SWECVI.ApplicationCore.Interfaces.Services
{
    public interface IContactInformationService
    {
        Task<bool> Create(ContactInformationDto model);
        Task<bool> Update(int id, ContactInformationDto model); 
        Task<bool> Delete(int id);
        Task<ContactInformationDto> GetContactById(int id);
        Task<PagedResponseDto<ContactInformationDto>> GetAllContact(PagedRequestDto model);
    }
}
