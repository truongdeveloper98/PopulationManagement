using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
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
    public class TownShipService : ITownShipService
    {
        private readonly ITownShipRepository _townshipRepository;
        private readonly ICompanyRepository _companyRepository;
        public TownShipService(ITownShipRepository townshipRepository, ICompanyRepository companyRepository)
        {
            _townshipRepository = townshipRepository;
            _companyRepository = companyRepository;
        }
        public async Task<bool> CreateTownShip(TownShipDto model)
        {
            var company = _companyRepository.FirstOrDefault(x=>x.Name == model.CompanyId);

            if (company == null)
            {
                throw new Exception("Company not found");
            }

            var township = new TownShip()
            {
                TownShipId = model.TownShipId,
                Name = model.Name,
                CompanyId = company.Id
            };

            await _townshipRepository.Add(township);

            return true;
        }

        public async Task<bool> DeleteTownShip(int id)
        {
            var township = await _townshipRepository.Get(id);
            
            if (township == null)
            {
                throw new Exception($"Can not find the township with id = {id}");
            }

            await _townshipRepository.Delete(township);

            return true;
        }

        public async Task<TownShipDto> GetTownShipById(int id)
        {
            var township = await _townshipRepository.Get(id, "Company");

            if(township == null)
            {
                throw new Exception($"Can not find the township with id = {id}");
            }

            var result = new TownShipDto()
            {
                TownShipId = township.TownShipId,
                Name = township.Name,
                CompanyName = township.Company.Name,
                CompanyId = township.Company.Name,
            };

            return result;
        }

        public async Task<PagedResponseDto<TownShipDto>> GetTownShips(PagedRequestDto model)
        {
            Expression<Func<TownShip, bool>> filter = i => !i.IsDeleted;

            if (!string.IsNullOrEmpty(model.TextSearch))
            {
                Expression<Func<TownShip, bool>> searchFilter = i => i.Name.Contains(model.TextSearch)||
                                                                     (!string.IsNullOrEmpty(i.TownShipId) &&
                                                                     i.TownShipId.Contains(model.TextSearch));
                filter = PredicateBuilder.AndAlso(filter, searchFilter);
            }

            var totalItems = await _townshipRepository.Count(filter);

            Expression<Func<TownShip, TownShipDto>> selectorExpression = i => new TownShipDto()
            {
                Id = i.Id,
                TownShipId = i.TownShipId,
                Name = i.Name,
                CompanyName = i.Company.Name
            };

            var items = await _townshipRepository
                .QueryAndSelectAsync(
                    selector: selectorExpression,
                    filter: filter,
                    orderBy: m => PredicateBuilder.ApplyOrder(m, model.SortColumnName ?? string.Empty, model.SortColumnDirection ?? string.Empty),
                    "",
                    pageSize: model.PageSize,
                    page: model.CurrentPage
                );

            return new PagedResponseDto<TownShipDto>
            {
                TotalItems = totalItems,
                Limit = model.PageSize,
                Page = model.CurrentPage,
                TotalPages = (int)Math.Ceiling(totalItems / (double)model.PageSize),
                Items = items.ToList()
            };

        }

        public async Task<bool> UpdateTownShip(int id, TownShipDto model)
        {
            var township = await _townshipRepository.Get(id);

            if( township == null)
            {
                throw new Exception($"Can not find the township with id = {id}");
            }

            var company = _companyRepository.FirstOrDefault(x => x.Name == model.CompanyId);

            if (company == null)
            {
                throw new Exception($"Can not find the company with name = {model.CompanyId}");
            }

            township.TownShipId = model.TownShipId;
            township.Name = model.Name;
            township.CompanyId = company.Id;

            await _townshipRepository.Update(township);

            return true;
        }
    }
}
