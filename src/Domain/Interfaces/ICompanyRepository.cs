using serviceEnterprise.Domain.Entities;

namespace serviceEnterprise.Domain.Interfaces;

public interface ICompanyRepository
{
    Task<IReadOnlyList<Company>> GetAllAsync();
    Task<Company> CreateAsync(Company company);
}                                                                                                                                                                                                                                                                                                                                               