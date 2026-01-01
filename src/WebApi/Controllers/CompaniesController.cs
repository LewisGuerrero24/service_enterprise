using Microsoft.AspNetCore.Mvc;
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
        return Ok(companies);
    }

    // [HttpPost]
    // public async Task<IActionResult> Create([FromBody] CreateCompanyDto dto)
    // {
    //     await _service.CreateAsync(dto);
    //     return Created(string.Empty, null);
    // }
}
