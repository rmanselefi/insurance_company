public class Proposal
{
    public ClientCompany Company { get; private set; }
    public IList<InsuredGroup> InsuredGroups { get; private set; }
    public decimal TotalPremium => CalculateTotalPremium();

    public void AddInsuredGroup(InsuredGroup group)
    {
        // Add an insured group to the proposal.
    }

    private decimal CalculateTotalPremium()
    {
        // Calculate the total premium based on insured groups and any discounts.
    }

    // Other properties and methods relevant to a proposal.
}
