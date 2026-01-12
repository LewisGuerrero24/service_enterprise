using AutoMapper;
using serviceEnterprise.Application.DTOs.Supplier;
using serviceEnterprise.Application.Interfaces;
using serviceEnterprise.Domain.Interfaces;
using serviceEnterprise.Domain.Entities;
using serviceEnterprise.Domain.Exceptions;

namespace serviceEnterprise.Application.UseCases.Supplier;

public class SupplierService : ISupplierService
{
    private readonly ISupplierRepository _repository;
    private readonly IMapper _mapper;

    public SupplierService(ISupplierRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<SupplierDto> GetByIdAsync(Guid supplierId)
    {
        var supplier = await _repository.GetSupplierAsync(supplierId);

        if (supplier is null)
            throw new NotFoundException("Supplier not found");
        
        return _mapper.Map<SupplierDto>(supplier);
    }
}