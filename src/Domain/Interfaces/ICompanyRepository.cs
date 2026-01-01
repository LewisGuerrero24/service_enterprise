using serviceEnterprise.Domain.Entities;

namespace serviceEnterprise.Domain.Interfaces;

public interface ICompanyRepository
{
    //Task CreateAsync(Company company);
    Task<IReadOnlyList<Company>> GetAllAsync();
}