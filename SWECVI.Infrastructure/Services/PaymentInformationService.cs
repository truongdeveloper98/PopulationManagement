using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using SWECVI.ApplicationCore.Entities;
using SWECVI.ApplicationCore.Interfaces.Repositories;
using SWECVI.ApplicationCore.Interfaces.Services;
using SWECVI.ApplicationCore.Utilities;
using SWECVI.ApplicationCore.ViewModels;

namespace SWECVI.Infrastructure.Services
{
    public class PaymentInformationService : IPaymentInformationService
    {
        private readonly IPaymentInformationRepository _paymentInformationRepository;

        public PaymentInformationService(IPaymentInformationRepository paymentInformationRepository)
        {
            _paymentInformationRepository = paymentInformationRepository;
        }

        public async Task<bool> CreatePaymentInformation(PaymentInformationDto model)
        {
            var paymentInformation = new PaymentInformation()
            {
                BankAccountNumber = model.BankAccountNumber,
                BankName = model.BankName,
                AccountName = model.AccountName,
                BankBranch = model.BankBranch,
                IsAutomaticTransactions = model.IsAutomaticTransactions,
                IsAutomaticAccounting = model.IsAutomaticAccounting,
            };

            await _paymentInformationRepository.Add(paymentInformation);

            return true;
        }

        public async Task<bool> DeletePaymentInformation(int id)
        {
           var paymentInformation = await _paymentInformationRepository.Get(id);

            if(paymentInformation == null)
            {
                throw new Exception($"Can not find the payment information with id = {id}");
            }

            await _paymentInformationRepository.Delete(paymentInformation);

            return true;
        }

        public async Task<PagedResponseDto<PaymentInformationDto>> GetAllPaymentInformation(PagedRequestDto model)
        {
            Expression<Func<PaymentInformation, bool>> filter = i => !i.IsDeleted;
            
            if(!string.IsNullOrEmpty(model.TextSearch))
            {
                Expression<Func<PaymentInformation, bool>> searchFilter = i => i.AccountName.Contains(model.TextSearch) ||
                                                                               (!string.IsNullOrEmpty(i.BankName) &&
                                                                               i.BankName.Contains(model.TextSearch));
                filter = PredicateBuilder.AndAlso(filter, searchFilter);
                                                                                
            }

            var totalItems = await _paymentInformationRepository.Count(filter);

            Expression<Func<PaymentInformation, PaymentInformationDto>> selector = i => new PaymentInformationDto()
            {
                BankAccountNumber = i.BankAccountNumber,
                BankName = i.BankName,
                AccountName = i.AccountName,
                BankBranch = i.BankBranch,
                IsAutomaticAccounting = i.IsAutomaticAccounting,
                IsAutomaticTransactions = i.IsAutomaticTransactions
            };

            var items = await _paymentInformationRepository
                .QueryAndSelectAsync(
                    selector: selector,
                    filter: filter,
                    orderBy: m => PredicateBuilder.ApplyOrder(m, model.SortColumnName ?? string.Empty, model.SortColumnDirection ?? string.Empty),
                    "",
                    pageSize: model.PageSize,
                    page: model.CurrentPage
                );
            return new PagedResponseDto<PaymentInformationDto>
            {
                TotalItems = totalItems,
                Page = model.CurrentPage,
                Limit = model.PageSize,
                TotalPages = (int)Math.Ceiling(totalItems/ (double)model.PageSize),
                Items = items.ToList()
            };
        }

        public async Task<PaymentInformationDto> GetPaymentInformationById(int id)
        {
            var paymentInformation = await _paymentInformationRepository.Get(id);

            if (paymentInformation == null)
            {
                throw new Exception($"Can not find the payment information with id = {id}");
            }

            var result = new PaymentInformationDto()
            {
                BankAccountNumber = paymentInformation.BankAccountNumber,
                BankName= paymentInformation.BankName,
                AccountName= paymentInformation.AccountName,
                BankBranch = paymentInformation.BankBranch,
                IsAutomaticTransactions = paymentInformation.IsAutomaticTransactions,
                IsAutomaticAccounting = paymentInformation.IsAutomaticAccounting
            };

            return result;
        }

        public async Task<bool> UpdatePaymentInformation(int id, PaymentInformationDto model)
        {
            var paymentInformation = await _paymentInformationRepository.Get(id);

            if(paymentInformation == null)
            {
                throw new Exception($"Can not find the payment information with id = {id}");
            }

            paymentInformation.BankName = model.BankName;
            paymentInformation.BankAccountNumber = model.BankAccountNumber;
            paymentInformation.AccountName = model.AccountName;
            paymentInformation.BankBranch = model.BankBranch;
            paymentInformation.IsAutomaticTransactions = model.IsAutomaticTransactions;
            paymentInformation.IsAutomaticAccounting = model.IsAutomaticAccounting;

            await _paymentInformationRepository.Update(paymentInformation);

            return true;
        }
    }
}
