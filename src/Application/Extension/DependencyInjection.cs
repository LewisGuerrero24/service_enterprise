using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using serviceEnterprise.Application.Interfaces;
using serviceEnterprise.Application.Mapping;
using serviceEnterprise.Application.UseCases.Companies;
using serviceEnterprise.Application.UseCases.Supplier;
//using serviceEnterprise.Application.Validators.Company;

namespace serviceEnterprise.Application.Extension;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<ICompanyService, CompanyService>();
        services.AddScoped<ISupplierService, SupplierService>();
        services.AddAutoMapper(typeof(CompanyProfile));
        //services.AddValidatorsFromAssemblyContaining<CreateCompanyValidator>();
        //service.AddValidatorsFromAssemblyContaining<CreateComapnyValidator>();

        return services;
    }
}