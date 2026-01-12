using Microsoft.AspNetCore.Mvc;
using serviceEnterprise.Application.Common;
using serviceEnterprise.Application.DTOs.Supplier;
using serviceEnterprise.Application.Interfaces;

[ApiController]
[Route("api/suppliers")]
public class SupplierController : ControllerBase
{
    private readonly ISupplierService _supplierService;

    public SupplierController(ISupplierService supplierService)
    {
        _supplierService = supplierService;
    }

    [HttpGet("{supplierId:guid}")]
    public async Task<IActionResult> GetById(Guid supplierId)
    {
        var supplier = await _supplierService.GetByIdAsync(supplierId);

        return Ok(ApiResponse<SupplierDto>.Ok(
            supplier,
            "Supplier retrieved successfully"
        ));
    }
}
