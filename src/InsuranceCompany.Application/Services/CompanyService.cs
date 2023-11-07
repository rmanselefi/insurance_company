using InsuranceCompany.Domain.Entities;
using InsuranceCompany.Domain.Interfaces;
using InsuranceCompany.Application.Interfaces;
using System;
using System.Collections.Generic;

namespace InsuranceCompany.Application.Services
{
    public class CompanyService: ICompanyService
    {
        private readonly ICompanyRepository _companyRepository;

        public CompanyService(ICompanyRepository companyRepository)
        {
            _companyRepository = companyRepository;
        }

       public Company CreateCompany(string name)
        {
            var company = new Company(name);

            _companyRepository.Add(company);

            return company;
        }

        public Company GetCompanyById(Guid id)
        {
            return _companyRepository.GetById(id);
        }

        public IEnumerable<Company> GetAllCompanies()
        {
            return _companyRepository.GetAll();
        }
    }
}
