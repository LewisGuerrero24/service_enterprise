namespace serviceEnterprise.Domain.Entities;

public class Company
{
    public Guid CompanyId {get; private set;}
    public string Name {get; private set;}
    public DateTime CreatedAt {get; private set;}

    private Company() {}

    public Company(string name){
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentNullException("Company name is required");

        CompanyId = Guid.NewGuid();
        Name = name.Trim();
        CreatedAt = DateTime.UtcNow;
    }

}
