using FluentValidation;
using serviceEnterprise.Application.DTOs.Company;

public class CreateCompanyValidator
: AbstractValidator<CreateCompanyDto>
{
    public CreateCompanyValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .MaximumLength(150);
    }
}
