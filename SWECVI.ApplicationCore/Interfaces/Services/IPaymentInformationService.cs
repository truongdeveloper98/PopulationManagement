using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SWECVI.ApplicationCore.ViewModels;

namespace SWECVI.ApplicationCore.Interfaces.Services
{
    public interface IPaymentInformationService
    {
        Task<bool> CreatePaymentInformation(PaymentInformationDto model);
        Task<bool> UpdatePaymentInformation(int id, PaymentInformationDto model);
        Task<bool> DeletePaymentInformation(int id);
        Task<PaymentInformationDto> GetPaymentInformationById(int id);
        Task<PagedResponseDto<PaymentInformationDto>> GetAllPaymentInformation(PagedRequestDto model);
    }
}
