using serviceEnterprise.Application.DTOs.Company;

namespace serviceEnterprise.Application.Interfaces;

public interface ICompanyService
{
    Task<IReadOnlyList<CompanyDto>> GetAllAsync();
    //Task CreateAsync(CreateCompanyDto dto);
}
