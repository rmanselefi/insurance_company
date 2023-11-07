namespace InsuranceCompany.Application.Dtos;


using System;
using System.Collections.Generic;
using InsuranceCompany.Application.Dtos;
using InsuranceCompany.Domain.Entities;

public class CreateProposalDto
{
    public Guid CompanyId { get; set; }
    public List<InsuredGroup> InsuredGroups { get; set; }
}
