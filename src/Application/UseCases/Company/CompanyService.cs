using serviceEnterprise.Application.DTOs.Company;
using serviceEnterprise.Application.Interfaces;
using serviceEnterprise.Domain.Entities;
using serviceEnterprise.Domain.Interfaces;

namespace serviceEnterprise.Application.UseCases.Company;

public class CompanyService : ICompanyService
{
    private readonly ICompanyRepository _repository;
    
    public CompanyService(ICompanyRepository repository)
    {
        _repository = repository;
    }

    public async Task<IReadOnlyList<CompanyDto>> GetAllAsync()
    {
        var companies = await _repository.GetAllAsync();

        return companies.Select(c => new CompanyDto {
            CompanyId = c.CompanyId,
            Name = c.Name,
            CreatedAt = c.CreatedAt
        }).ToList();
    }
}