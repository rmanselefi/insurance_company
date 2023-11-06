using System;
using System.Collections.Generic;

public class Proposal
{
    public Guid Id { get; private set; }
    public Guid CompanyId { get; private set; }
    public List<InsuredGroup> InsuredGroups { get; private set; } = new List<InsuredGroup>();

    // Make the default constructor private to force using the factory method
    private Proposal() { }

    // Factory method to create a new proposal
    public static Proposal Create(Guid companyId)
    {
        return new Proposal
        {
            Id = Guid.NewGuid(),
            CompanyId = companyId
        };
    }

    public void AddInsuredGroup(InsuredGroup group)
    {
        InsuredGroups.Add(group);
    }
    
    public decimal CalculateTotalPremium()
    {
        return InsuredGroups.Sum(g => g.CalculateGroupPremium());
    }
}
