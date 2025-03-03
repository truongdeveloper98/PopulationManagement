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
    public class CompanyService : ICompanyService
    {
        private readonly ICompanyRepository _companyRepository;

        public CompanyService(ICompanyRepository companyRepository)
        {
            _companyRepository = companyRepository;
        }

        public async Task<bool> CreateCompany(CompanyDto model)
        {
            var company = new Company()
            {
                CompanyId = model.CompanyId,
                Name = model.Name
            };

            await _companyRepository.Add(company);

            return true;
        }

        public async Task<bool> DeleteCompany(int id)
        {
            var company = await _companyRepository.Get(id);

            if(company == null)
            {
                throw new Exception($"Can not find the Company with id = {id}");
            }

            await _companyRepository.Delete(company);

            return true;
        }

        public async Task<PagedResponseDto<CompanyDto>> GetCompanies(PagedRequestDto model)
        {
            Expression<Func<Company, bool>> filter = i => !i.IsDeleted;

            if(!string.IsNullOrEmpty(model.TextSearch))
            {
                Expression<Func<Company, bool>> searchFilter = i => i.Name.Contains(model.TextSearch) ||
                                                                    (!string.IsNullOrEmpty(i.CompanyId) &&
                                                                    i.CompanyId.Contains(model.TextSearch));
                filter = PredicateBuilder.AndAlso(filter, searchFilter);
            }

            var totalItems = await _companyRepository.Count(filter);

            Expression<Func<Company, CompanyDto>> selectorExpression = i => new CompanyDto()
            {
                Id = i.Id,
                CompanyId = i.CompanyId,
                Name = i.Name,
            };

            var items = await _companyRepository
                .QueryAndSelectAsync(
                    selector: selectorExpression,
                    filter: filter,
                    orderBy: m => PredicateBuilder.ApplyOrder(m , model.SortColumnName ?? string.Empty, model.SortColumnDirection ?? string.Empty),
                    "",
                    pageSize: model.PageSize,
                    page: model.CurrentPage
                );

            return new PagedResponseDto<CompanyDto>
            {
                TotalItems = totalItems,
                Limit = model.PageSize,
                Page = model.CurrentPage,
                TotalPages = (int)Math.Ceiling(totalItems / (double)model.PageSize),
                Items = items.ToList()
            };
        }

        public async Task<List<CompanyForSelectionDto>> GetCompaniesForSelection()
        {
            var result = await _companyRepository.QueryAndSelectAsync(selector: x => new CompanyForSelectionDto()
            {
                Id = x.Id,
                Name = x.Name,
            });

            return result.ToList();
        }

        public async Task<CompanyDto> GetCompanyById(int id)
        {
            var company = await _companyRepository.Get(id);

            if(company == null)
            {
                throw new Exception($"Can not fing the Company with id = {id}");
            }

            var result = new CompanyDto()
            {
                CompanyId = company.CompanyId,
                Name = company.Name,
            };

            return result;
        }

        public async Task<bool> UpdateCompany(int id, CompanyDto model)
        {
            var company = await _companyRepository.Get(id);

            if (company == null)
            {
                throw new Exception($"Can not find the Company with id = {id}");
            }

            company.CompanyId = model.CompanyId;
            company.Name = model.Name;

            await _companyRepository.Update(company);

            return true;
        }
    }
}
