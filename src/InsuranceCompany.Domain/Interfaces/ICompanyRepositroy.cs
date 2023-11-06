namespace InsuranceCompany.Domain.Interfaces
{
    public interface ICompanyRepository
    {
        Company Add(Company company);
        Company GetById(Guid id);
        List<Company> GetAll();
    }
}
