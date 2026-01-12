using AutoMapper;
using serviceEnterprise.Application.DTOs.Supplier;
using serviceEnterprise.Domain.Entities;
namespace serviceEnterprise.Application.Mapping;


public class SupplierProfile : Profile
{
    public SupplierProfile()
    {
        CreateMap<Supplier, SupplierDto>();
    }
}