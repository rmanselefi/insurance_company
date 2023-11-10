using InsuranceCompany.Domain.Entities;
using InsuranceCompany.Domain.Interfaces;
using InsuranceCompany.Application.Interfaces;
using System;
using System.Collections.Generic;


namespace InsuranceCompany.Application.Services
{
    public class ProposalService : IProposalService
    {
        private readonly IProposalRepository _proposalRepository;

        public ProposalService(IProposalRepository proposalRepository)
        {
            _proposalRepository = proposalRepository;
        }

        public Proposal CreateProposal(Guid clientCompany, List<InsuredGroup> insuredGroups)
        {
            // You might want to add some validation to check if the company and groups are valid
            var proposal = new Proposal
            {
                CompanyId = clientCompany,
                InsuredGroups = insuredGroups,
                TotalPremium = insuredGroups.Sum(group => CalculatePremiumForGroup(group))
            };

            _proposalRepository.Add(proposal);

            return proposal;
        }

        public Proposal GetProposal(Guid proposalId)
        {
            return _proposalRepository.GetById(proposalId);
        }

        public decimal CalculatePremiumForGroup(InsuredGroup group)
        {
            int discountThreshold = 10;
            int discounts = group.NumberOfMembers / discountThreshold;
            int payableMembers = group.NumberOfMembers - discounts;
            return payableMembers * group.Plan.Price;
        }


        public decimal CalculateTotalPremium(Guid proposalId)
        {
            var proposal = _proposalRepository.GetById(proposalId);
            if (proposal == null)
                throw new ArgumentException("Proposal not found.");

            return proposal.InsuredGroups.Sum(group => CalculatePremiumForGroup(group));
        }

        public void AddInsuredGroupToProposal(Guid proposalId, InsuredGroup insuredGroup)
        {
            var proposal = _proposalRepository.GetById(proposalId);
            if (proposal == null)
                throw new InvalidOperationException("Proposal not found.");

            proposal.InsuredGroups.Add(insuredGroup);
            proposal.CalculateTotalPremium();
        }

        public void ApplyDiscount(Guid proposalId, decimal discountPercentage)
        {
            var proposal = _proposalRepository.GetById(proposalId);
            if (proposal == null)
                throw new InvalidOperationException("Proposal not found.");

            foreach (var group in proposal.InsuredGroups)
            {
                var discountAmount = group.TotalGroupPremium * (discountPercentage / 100m);
                group.ApplyDiscount(discountAmount);
            }
            proposal.CalculateTotalPremium();
        }
        public decimal GetTotalPremium(Proposal proposal)
        {
            // Ensure the proposal is valid
            if (proposal == null)
            {
                throw new ArgumentNullException(nameof(proposal));
            }

            return proposal.InsuredGroups.Sum(group => group.Premium);

        }

    }
}
