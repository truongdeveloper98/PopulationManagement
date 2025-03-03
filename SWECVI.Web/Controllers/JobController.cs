using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SWECVI.ApplicationCore.Interfaces.Services;
using SWECVI.ApplicationCore.ViewModels;

namespace SWECVI.Web.Controllers
{
    public class JobController : ControllerBase
    {
        private readonly IJobService _jobService;

        public JobController(IJobService jobService)
        {
            _jobService = jobService;
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("api/job-management/jobs")]
        public async Task<IActionResult> CreateJob([FromBody] JobDto model)
        {
            try
            {
                await _jobService.CreateJob(model);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [AllowAnonymous]
        [Route("api/job-management/jobs/{id}")]
        public async Task<IActionResult> UpdateJob(int id, [FromBody] JobDto model)
        {
            try
            {
                await _jobService.UpdateJob(id, model);
                return Ok();
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("api/job/{id}")]
        public async Task<IActionResult> GetJobById(int id)
        {
            try
            {
                var result = await _jobService.GetById(id);
                return Ok(result);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("api/job-management/jobs")]
        public async Task<IActionResult> GetAllJobs([FromQuery] PagedRequestDto model)
        {
            try
            {
                var result = await _jobService.GetJobs(model);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
