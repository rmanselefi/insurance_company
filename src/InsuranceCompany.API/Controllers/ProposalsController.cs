using InsuranceCompany.Application.Interfaces;
using InsuranceCompany.Domain.Entities;
using InsuranceCompany.Domain.ValueObjects;
using InsuranceCompany.Application.Dtos;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace InsuranceCompany.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProposalsController : ControllerBase
    {
        private readonly IProposalService _proposalService;

        public ProposalsController(IProposalService proposalService)
        {
            _proposalService = proposalService;
        }


        // POST: /proposals
        [HttpPost]
        public ActionResult<Proposal> CreateProposal([FromBody] CreateProposalDto createProposalDto)
        {
            var insuredGroups = createProposalDto.InsuredGroups;

            var proposal = _proposalService.CreateProposal(createProposalDto.CompanyId, insuredGroups);

            return CreatedAtAction(nameof(GetProposal), new { id = proposal.Id }, proposal);
        }

        // GET:id /proposal
        [HttpGet("{id}")]
        public ActionResult<Proposal> GetProposal(Guid id)
        {
            var proposal = _proposalService.GetProposal(id);

            if (proposal == null)
            {
                return NotFound();
            }

            return proposal;
        }




    }
}
