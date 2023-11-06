namespace InsuranceCompany.Application.Interfaces
{
    public interface ICompanyService
    {
        Company CreateCompany(string name);
        Company GetCompany(Guid id);
        IEnumerable<Company> GetAllCompanies();
        // Additional methods for updating, deleting, etc.
    }
}
