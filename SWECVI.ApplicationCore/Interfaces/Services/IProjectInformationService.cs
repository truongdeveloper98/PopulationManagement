using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SWECVI.ApplicationCore.ViewModels;

namespace SWECVI.ApplicationCore.Interfaces.Services
{
    public interface IProjectInformationService
    {
        Task<bool> CreateProjecInformation(ProjectInformationDto model);
        Task<bool> DeleteProjecInformation(int id);
        Task<bool> UpdateProjectInformation(int id, ProjectInformationDto model);
        Task<ProjectInformationDto> GetProjectInformationById(int id);
        Task<PagedResponseDto<ProjectInformationDto>> GetAllProjectInformation(PagedRequestDto model);
    }
}
