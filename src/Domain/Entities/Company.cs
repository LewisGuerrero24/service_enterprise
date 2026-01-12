using serviceEnterprise.Domain.Exceptions;

namespace serviceEnterprise.Domain.Entities;

public class Company
{
    public Guid CompanyId {get; private set;}
    public string Name {get; private set;}
    public DateTime CreatedAt {get; private set;}

    private Company() {}
    
    private Company(Guid id, string name, DateTime createdAt)
    {
        CompanyId = id;
        Name = name;
        CreatedAt = createdAt;
    }

    public Company(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new DomainException("Company name is required");

        CompanyId = Guid.NewGuid();
        Name = name.Trim();
        CreatedAt = DateTime.UtcNow;
    }

    public static Company Rehydrate(
        Guid id,
        string name,
        DateTime createdAt
    )
    {
        return new Company(id, name, createdAt);
    }

}
