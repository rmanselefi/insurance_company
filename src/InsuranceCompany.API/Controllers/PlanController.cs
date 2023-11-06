[ApiController]
[Route("[controller]")]
public class PlanController : ControllerBase
{
    private readonly IPlanService _companyService;

    public ClientCompaniesController(IPlanService companyService)
    {
        _companyService = companyService;
    }

    // API endpoints using _companyService
}
