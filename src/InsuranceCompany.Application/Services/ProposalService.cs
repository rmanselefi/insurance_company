using InsuranceCompany.Domain.Entities;
using InsuranceCompany.Domain.Interfaces;
using InsuranceCompany.Application.Interfaces;
using System;
using System.Collections.Generic;
using InsuranceCompany.Domain.ValueObjects;


namespace InsuranceCompany.Application.Services
{
    public class ProposalService : IProposalService
    {
        private readonly IProposalRepository _proposalRepository;
        private readonly IDiscountRepository _discountRepositroy;

        public ProposalService(IProposalRepository proposalRepository, IDiscountRepository discountRepository)
        {
            _proposalRepository = proposalRepository;
            _discountRepositroy = discountRepository;
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

        public void AddInsuredGroupToProposal(Guid proposalId, Plan plan, int numberOfMembers)
        {
            var proposal = _proposalRepository.GetById(proposalId);
            if (proposal == null)
                throw new InvalidOperationException("Proposal not found.");

            var discount = _discountRepositroy.GetDiscountByPlan(plan);
            var insuredGroup = new InsuredGroup(numberOfMembers, plan);
            var discountPercentage = discount.Percentage;
            var selectedPlan = discount.EligiblePlanType;
            proposal.InsuredGroups.Add(insuredGroup);
            var proposalInsuredGroups = proposal.InsuredGroups;
            
            for (int i = 0; i < proposalInsuredGroups.Count; i++)
            {
                var item = proposalInsuredGroups[i];
                if (item.NumberOfMembers > 50 && item.Plan.Type == selectedPlan)
                {
                    proposal.TotalPremium = numberOfMembers * plan.Price * discountPercentage / 100;
                }
            }
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
