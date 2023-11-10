using System;
using System.Collections.Generic;

namespace InsuranceCompany.Domain.Entities;

public class Proposal
{
    public Guid Id { get; set; }
    public Guid CompanyId { get; set; }
    public List<InsuredGroup> InsuredGroups { get; set; } = new List<InsuredGroup>();

    public decimal TotalPremium
    {
        get { return InsuredGroups.Sum(group => group.TotalGroupPremium); }
        set { }
    }

    public Proposal()
    {
        Id = Guid.NewGuid();
        InsuredGroups = new List<InsuredGroup>();
        // Initialize other properties if necessary
    }

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
