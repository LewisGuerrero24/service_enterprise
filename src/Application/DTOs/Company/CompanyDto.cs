namespace serviceEnterprise.Application.DTOs.Company;

public class CompanyDto
{
    public Guid CompanyId {get; set;}
    public string Name { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; }

}