using AutoMapper;
using serviceEnterprise.Application.DTOs.Company;
using serviceEnterprise.Application.Interfaces;
using serviceEnterprise.Domain.Interfaces;
using serviceEnterprise.Domain.Entities;

namespace serviceEnterprise.Application.UseCases.Companies;

public class CompanyService : ICompanyService
{
    private readonly ICompanyRepository _repository;
    private readonly IMapper _mapper;

    public CompanyService(ICompanyRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<IReadOnlyList<CompanyDto>> GetAllAsync()
    {
        var companies = await _repository.GetAllAsync();
        return _mapper.Map<IReadOnlyList<CompanyDto>>(companies);
    }

    public async Task<CompanyDto> CreateAsync(CreateCompanyDto createCompanyDto)
    {
        var entity = new Company(createCompanyDto.Name);
        var created = await _repository.CreateAsync(entity);
        return _mapper.Map<CompanyDto>(created);
    }
}