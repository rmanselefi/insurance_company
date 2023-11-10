

namespace InsuranceCompany.Domain.ValueObjects;
using InsuranceCompany.Domain.Entities;


public class Plan
{
    public Guid Id { get; private set; }
    public PlanType Type { get; private set; }
    public decimal Price { get; private set; }

    public Plan(PlanType type, decimal price)
    {
        Id = Guid.NewGuid();
        Type = type;
        Price = price;
    }
}
