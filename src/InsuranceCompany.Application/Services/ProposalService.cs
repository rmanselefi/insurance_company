using InsuranceCompany.Domain.Entities;
using InsuranceCompany.Domain.Interfaces;
using System;
using System.Collections.Generic;

namespace InsuranceCompany.Application.Services
{
    public class ProposalService
    {
        private readonly IProposalRepository _proposalRepository;

        public ProposalService(IProposalRepository proposalRepository)
        {
            _proposalRepository = proposalRepository;
        }

       public Proposal CreateProposal(Company clientCompany, List<InsuranceGroup> insuredGroups)
        {
        // You might want to add some validation to check if the company and groups are valid
        var proposal = new Proposal
        {
            ClientCompany = clientCompany,
            InsuredGroups = insuredGroups,
            TotalPremium = insuredGroups.Sum(group => CalculatePremiumForGroup(group))
        };

        _proposalRepository.Add(proposal);

        return proposal;
        }


        public decimal CalculatePremiumForGroup(InsuranceGroup group)
{
    int discountThreshold = 10; // For every 10 members, one gets a free insurance
    int discounts = group.Members.Count / discountThreshold;
    int payableMembers = group.Members.Count - discounts;
    return payableMembers * group.Plan.Price;
}


public decimal CalculateTotalPremium(Guid proposalId)
{
    var proposal = _proposalRepository.GetById(proposalId);
    if (proposal == null)
        throw new ArgumentException("Proposal not found.");

    return proposal.InsuredGroups.Sum(group => CalculatePremiumForGroup(group));
}

        // Add other methods as required by your user stories
    }
}
