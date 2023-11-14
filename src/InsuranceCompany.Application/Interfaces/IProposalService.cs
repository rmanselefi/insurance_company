
using InsuranceCompany.Domain.Entities;
using InsuranceCompany.Domain.ValueObjects;


namespace InsuranceCompany.Application.Interfaces
{
    public interface IProposalService
    {
        Proposal CreateProposal(Guid clientCompany, List<InsuredGroup> insuredGroups);
        void AddInsuredGroupToProposal(Guid proposalId, Plan plan, int numberOfMembers);
        decimal GetTotalPremium(Proposal proposal);
        void ApplyDiscount(Guid proposalId, decimal discountPercentage);
        Proposal GetProposal(Guid id);
    }
}
