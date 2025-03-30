using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SWECVI.ApplicationCore.Entities.Building_Resident;
using SWECVI.ApplicationCore.Interfaces.Services;
using SWECVI.ApplicationCore.ViewModels;

namespace SWECVI.Web.Controllers
{
    public class PriceListController : ControllerBase
    {
        private readonly IPriceListService _priceListService;

        public PriceListController(IPriceListService priceListService)
        {
            _priceListService = priceListService;
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("api/priceList-management/priceLists")]
        public async Task<IActionResult> CreatePriceList([FromBody] PriceListDto model)
        {
            try
            {
                var result = await _priceListService.CreatePriceList(model);
                return Ok();
            }
            catch (Exception ex)
            {
                //return BadRequest(ex.Message);
                Console.WriteLine($"Lỗi khi cập nhật cơ sở dữ liệu: {ex.InnerException?.Message}");
                throw;
            }
        }

        [HttpPut]
        [AllowAnonymous]
        [Route("api/priceList-management/priceLists/{id}")]
        public async Task<IActionResult> UpdatePriceList(int id, [FromBody] PriceListDto model)
        {
            try
            {
                var result = await _priceListService.UpdatePriceList(id, model);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        [AllowAnonymous]
        [Route("api/priceList-management/priceLists/{id}")]
        public async Task<IActionResult> DeletePriceList(int id)
        {
            try
            {
                var result = await _priceListService.DeletePriceList(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("api/priceList-management/priceLists/{id}")]
        public async Task<IActionResult> GetPriceById(int id)
        {
            try
            {
                var result = await _priceListService.GetPriceListById(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("api/priceList-management/priceLists")]
        public async Task<IActionResult> GetAllPriceLists([FromQuery] PagedRequestDto model)
        {
            try
            {
                var result = await _priceListService.GetAllPriceLists(model);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
