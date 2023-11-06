public class InsuredGroup
{
    public Guid Id { get; private set; }
    public int NumberOfMembers { get; private set; }
    public Plan Plan { get; private set; }

    public InsuredGroup(int numberOfMembers, Plan plan)
    {
        Id = Guid.NewGuid();
        NumberOfMembers = numberOfMembers;
        Plan = plan;
    }
    
    public decimal CalculateGroupPremium()
    {
        // Assuming no discounts or additional logic for now
        return NumberOfMembers * Plan.Price;
    }
}

public class Plan
{
    public string Name { get; private set; }
    public decimal Price { get; private set; }

    public Plan(string name, decimal price)
    {
        Name = name;
        Price = price;
    }
}
