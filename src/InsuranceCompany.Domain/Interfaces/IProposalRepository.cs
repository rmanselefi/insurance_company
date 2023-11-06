namespace InsuranceCompany.Domain.Interfaces
{
    public interface IProposalRepository
    {
        Proposal Add(Proposal proposal);
        Proposal GetById(Guid id);
        List<Proposal> GetAll();
    }
}
