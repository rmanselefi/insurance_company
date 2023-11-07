
using InsuranceCompany.Domain.Entities;


namespace InsuranceCompany.Application.Interfaces
{
    public interface IProposalService
    {
        Proposal CreateProposal(Guid clientCompany, List<InsuredGroup> insuredGroups);
        void AddInsuredGroupToProposal(Guid proposalId, InsuredGroup insuredGroup);
        decimal GetTotalPremium(Proposal proposal);
        void ApplyDiscount(Guid proposalId, decimal discountPercentage);
        Proposal GetProposal(Guid id);
    }
}
