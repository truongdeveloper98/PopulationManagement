using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SWECVI.ApplicationCore.ViewModels;

namespace SWECVI.ApplicationCore.Interfaces.Services
{
    public interface IProjectService
    {
        Task<bool> CreateProject(ProjectDto model);
        Task<bool> DeleteProject(int id);
        Task<bool> UpdateProject(int id, ProjectDto model);
        Task<ProjectDto> GetProjectById(int id);
        Task<PagedResponseDto<ProjectDto>> GetAllProject(PagedRequestDto model);
    }
}
