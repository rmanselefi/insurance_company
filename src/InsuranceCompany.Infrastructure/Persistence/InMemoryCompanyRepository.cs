
using System;
using System.Collections.Generic;
using System.Linq;
using InsuranceCompany.Application.Interfaces;
using InsuranceCompany.Domain.Entities;
using InsuranceCompany.Domain.Interfaces;


public class InMemoryCompanyRepository : ICompanyRepository
{
    private readonly List<Company> _companies = new List<Company>();

    public Company Add(Company company)
    {
        company.Id = Guid.NewGuid(); // Ensure the company has a unique ID
        _companies.Add(company);
        return company;
    }

    public Company GetById(Guid id)
    {
        return _companies.SingleOrDefault(company => company.Id == id);
    }

    public List<Company> GetAll()
    {
        return _companies;
    }
}
