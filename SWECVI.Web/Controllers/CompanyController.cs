using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SWECVI.ApplicationCore.Interfaces.Services;
using SWECVI.ApplicationCore.ViewModels;

namespace SWECVI.Web.Controllers
{
    public class CompanyController : ControllerBase
    {
        private readonly ICompanyService _companyService;

        public CompanyController(ICompanyService companyService)
        {
            _companyService = companyService;
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("api/company-management/companies")]
        public async Task<IActionResult> CreateCompany([FromBody] CompanyDto model)
        {
            try
            {
                var result = await _companyService.CreateCompany(model);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [AllowAnonymous]
        [Route("api/company-management/companies/{id}")]
        public async Task<IActionResult> UpdateCompany(int id, [FromBody] CompanyDto model)
        {
            try
            {
                var result = await _companyService.UpdateCompany(id, model);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        [AllowAnonymous]
        [Route("api/company-management/companies/{id}")]
        public async Task<IActionResult> DeleteCompany(int id)
        {
            try
            {
                var result = await _companyService.DeleteCompany(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("api/company-management/companies/{id}")]
        public async Task<IActionResult> GetCompanyById(int id)
        {
            try
            {
                var result = await _companyService.GetCompanyById(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("api/company-management/companies")]
        public async Task<IActionResult> GetCompanies([FromQuery] PagedRequestDto model)
        {
            try
            {
                var result = await _companyService.GetCompanies(model);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
