

using InsuranceCompany.Domain.Entities;
using System;
using System.Collections.Generic;


namespace InsuranceCompany.Application.Interfaces
{
    public interface ICompanyService
    {
        Company CreateCompany(string name);
        Company GetCompanyById(Guid id);
        IEnumerable<Company> GetAllCompanies();
    }
}
