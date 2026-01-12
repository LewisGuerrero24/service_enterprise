using Microsoft.AspNetCore.Mvc;
using serviceEnterprise.Application.Common;
using serviceEnterprise.Application.DTOs.Company;
using serviceEnterprise.Application.Interfaces;

namespace serviceEnterprise.WebApi.Controllers;

[ApiController]
[Route("api/companies")]
public class CompaniesController : ControllerBase
{
    private readonly ICompanyService _service;

    public CompaniesController(ICompanyService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var companies = await _service.GetAllAsync();
        return Ok(ApiResponse<IReadOnlyList<CompanyDto>>
            .Ok(companies, "Companies retrieved successfully"));
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateCompanyDto dto)
    {
        var result = await _service.CreateAsync(dto);
        return Ok(ApiResponse<CompanyDto>.Ok(result, "Company created successfully"));
    }
}
