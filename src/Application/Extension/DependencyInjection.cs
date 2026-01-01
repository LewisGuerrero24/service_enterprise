using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using serviceEnterprise.Application.Interfaces;
using serviceEnterprise.Application.UseCases.Company;
//using serviceEnterprise.Application.Validators.Company;

namespace serviceEnterprise.Application.Extension;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<ICompanyService, CompanyService>();
        //service.AddValidatorsFromAssemblyContaining<CreateComapnyValidator>();

        return services;
    }
}