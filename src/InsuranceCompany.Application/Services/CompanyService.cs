using InsuranceCompany.Domain.Entities;
using InsuranceCompany.Domain.Interfaces;
using System;
using System.Collections.Generic;

namespace InsuranceCompany.Application.Services
{
    public class CompanyService
    {
        private readonly ICompanyRepository _companyRepository;

        public CompanyService(ICompanyRepository companyRepository)
        {
            _companyRepository = companyRepository;
        }

       public Company CreateCompany(string name)
{
    var company = new Company
    {
        Name = name
    };

    _companyRepository.Add(company);

    return company;
}

        public Company GetCompanyById(Guid id)
{
    return _companyRepository.GetById(id);
}

        // Add other methods as required
    }
}
