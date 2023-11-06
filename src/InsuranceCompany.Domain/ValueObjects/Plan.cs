public enum PlanType
{
    Base,
    Premium
}

public class Plan
{
    public PlanType Type { get; private set; }
    public decimal Price { get; private set; }
    // Other properties and methods relevant to an insurance plan.
}
