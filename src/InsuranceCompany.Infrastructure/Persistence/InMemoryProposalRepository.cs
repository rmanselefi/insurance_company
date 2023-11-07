
namespace InsuranceCompany.Infrastructure.Persistence;

using System;
using System.Collections.Generic;
using System.Linq;
using InsuranceCompany.Domain.Entities;
using InsuranceCompany.Domain.Interfaces;

public class InMemoryProposalRepository : IProposalRepository
{
    private readonly List<Proposal> _proposals = new List<Proposal>();

    public Proposal Add(Proposal proposal)
    {
        _proposals.Add(proposal);
        return proposal;
    }

    public Proposal GetById(Guid id)
    {
        return _proposals.SingleOrDefault(proposal => proposal.Id == id);
    }

    public List<Proposal> GetAll()
    {
        return _proposals;
    }
}
