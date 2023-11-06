namespace InsuranceCompany.Application.Interfaces
{
    public interface IProposalService
    {
        Proposal CreateProposal(ClientCompany company);
        void AddInsuredGroupToProposal(Proposal proposal, int memberCount, InsurancePlanType planType);
        decimal GetTotalPremium(Proposal proposal);
        void ApplyDiscount(Proposal proposal, int xMembers, InsurancePlanType planType);
    }
}
