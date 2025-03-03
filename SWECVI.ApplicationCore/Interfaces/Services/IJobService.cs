using SWECVI.ApplicationCore.ViewModels;

namespace SWECVI.ApplicationCore.Interfaces.Services
{
    public interface IJobService
    {
        Task<bool> CreateJob(JobDto model);
        Task<bool> UpdateJob(int id, JobDto model );
        Task<bool> DeleteJob(int id);
        Task<JobDto> GetById(int id);
        Task<PagedResponseDto<JobDto>> GetJobs(PagedRequestDto model);
    }
}
