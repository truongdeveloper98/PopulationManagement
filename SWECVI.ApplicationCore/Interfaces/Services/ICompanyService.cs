using SWECVI.ApplicationCore.ViewModels;

namespace SWECVI.ApplicationCore.Interfaces.Services
{
    public interface ICompanyService
    {
        Task<bool> CreateCompany(CompanyDto model);
        Task<bool> UpdateCompany(int id, CompanyDto model);
        Task<bool> DeleteCompany(int id);
        Task<CompanyDto> GetCompanyById(int id);
        Task<PagedResponseDto<CompanyDto>> GetCompanies(PagedRequestDto model);
        Task<List<CompanyForSelectionDto>> GetCompaniesForSelection();
    }
}
