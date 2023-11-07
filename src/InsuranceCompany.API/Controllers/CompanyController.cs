
using InsuranceCompany.Application.Services;
using InsuranceCompany.Application.Interfaces;
using InsuranceCompany.Domain.Interfaces;
using InsuranceCompany.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


[ApiController]
[Route("[controller]")]
public class CompaniesController : ControllerBase
{
    private readonly ICompanyService _companyService;

    public CompaniesController(ICompanyService companyService)
    {
        _companyService = companyService;
    }
    // POST: /companies
    [HttpPost]
    public ActionResult<Company> CreateCompany(string name)
    {
        var company = _companyService.CreateCompany(name);
        return CreatedAtAction(nameof(GetCompany), new { id = company.Id }, company);
    }

    // GET /companies
    [HttpGet]
    public ActionResult<IEnumerable<Company>> GetCompanies()
    {
        return _companyService.GetAllCompanies().ToList();
    }

    // GET: /companies/{id}
    [HttpGet("{id}")]
    public ActionResult<Company> GetCompany(Guid id)
    {
        var company = _companyService.GetCompanyById(id);

        if (company == null)
        {
            return NotFound();
        }

        return company;
    }

}
