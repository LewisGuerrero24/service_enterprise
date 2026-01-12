using AutoMapper;
using serviceEnterprise.Application.DTOs.Company;
using serviceEnterprise.Domain.Entities;
namespace serviceEnterprise.Application.Mapping;


public class CompanyProfile : Profile
{
    public CompanyProfile()
    {
       CreateMap<Company, CompanyDto>();

        CreateMap<CompanyDto, Company>()
            .ConstructUsing(dto =>
                Company.Rehydrate(
                    dto.CompanyId,
                    dto.Name,
                    dto.CreatedAt
                )
            );
    }
}