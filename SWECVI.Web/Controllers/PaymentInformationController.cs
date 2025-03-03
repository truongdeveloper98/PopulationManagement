using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SWECVI.ApplicationCore.Interfaces.Services;
using SWECVI.ApplicationCore.ViewModels;

namespace SWECVI.Web.Controllers
{
    public class PaymentInformationController : ControllerBase
    {
        private readonly IPaymentInformationService _paymentInformationService;
        public PaymentInformationController(IPaymentInformationService paymentInformationService)
        {
            _paymentInformationService = paymentInformationService;
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("api/paymentInformation-management/paymentInformation")]
        public async Task<IActionResult> CreatePaymentInformation(PaymentInformationDto model)
        {
            try
            {
                var result = await _paymentInformationService.CreatePaymentInformation(model);
                return Ok();
                    
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [AllowAnonymous]
        [Route("api/paymentInformation-management/paymentInformation/{id}")]
        public async Task<IActionResult> UpdatePaymentInformation(int id, PaymentInformationDto model)
        {
            try
            {
                var result = await _paymentInformationService.UpdatePaymentInformation(id, model);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        [AllowAnonymous]
        [Route("api/paymentInformation-management/paymentInformation/{id}")]
        public async Task<IActionResult> DeletePaymentInformation(int id)
        {
            try
            {
                var result = await _paymentInformationService.DeletePaymentInformation(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("paymentInformation-management/paymentInformation/{id}")]
        public async Task<IActionResult> GetPaymentInformationById(int id)
        {
            try
            {
                var result = await _paymentInformationService.GetPaymentInformationById(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("paymentInformation-management/paymentInformation")]
        public async Task<IActionResult> GetAllPaymentInformation(PagedRequestDto model)
        {
            try
            {
                var result = await _paymentInformationService.GetAllPaymentInformation(model);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
