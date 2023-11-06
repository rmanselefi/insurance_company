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
    }
}
