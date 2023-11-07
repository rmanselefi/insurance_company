

namespace InsuranceCompany.Domain.ValueObjects;
using InsuranceCompany.Domain.Entities;


public class Plan
{
    public Guid Id { get; private set; }
        public PlanType Type { get; private set; }
        public decimal Price { get; private set; }

        // Constructor that takes PlanType and price
        public Plan(PlanType type, decimal price)
        {
            Id = Guid.NewGuid(); // Assign a new unique identifier
            Type = type;
            Price = price;
        }
}
