using InsuranceCompany.Application.Interfaces;

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

        // Define your API endpoints here using _proposalService

        // POST: /proposals
        [HttpPost]
        public ActionResult<Proposal> CreateProposal(ClientCompany company)
        {
            var proposal = _proposalService.CreateProposal(company);
            return CreatedAtAction(nameof(GetProposal), new { id = proposal.Id }, proposal);
        }

        // GET: /proposals/{id}
        [HttpGet("{id}")]
        public ActionResult<Proposal> GetProposal(int id)
        {
            var proposal = _proposalService.GetProposal(id);

            if (proposal == null)
            {
                return NotFound();
            }

            return proposal;
        }

        // PUT: /proposals/{id}
        [HttpPut("{id}")]
        public IActionResult UpdateProposal(int id, Proposal proposal)
        {
            if (id != proposal.Id)
            {
                return BadRequest();
            }

            _proposalService.UpdateProposal(proposal);

            return NoContent();
        }
    }
}
