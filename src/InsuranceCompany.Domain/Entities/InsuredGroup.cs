namespace InsuranceCompany.Domain.Entities;

using System.Collections.Generic;
using InsuranceCompany.Domain.ValueObjects;


using System;


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
        return NumberOfMembers * Plan.Price;
    }

    public decimal PremiumPerMember { get; set; }

    public decimal TotalGroupPremium => NumberOfMembers * PremiumPerMember;

    public decimal Premium { get; set; }


    public void ApplyDiscount(decimal discountAmount)
    {

        Premium -= Premium * (discountAmount / 100m);
    }
}

