namespace serviceEnterprise.Domain.ValueObjects;

public class Quantity : ValueObject
{
    public decimal Value { get; private set; }

    public Quantity(decimal value)
    {
        if (value < 0)
            throw new ArgumentException("Quantity cannot be negative", nameof(value));

        Value = value;
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
