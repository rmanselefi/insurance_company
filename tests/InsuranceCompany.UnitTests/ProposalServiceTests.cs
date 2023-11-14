
using InsuranceCompany.Domain.Entities;
using InsuranceCompany.Domain.Interfaces;
using InsuranceCompany.Domain.ValueObjects;
using InsuranceCompany.Infrastructure.Persistence;
using InsuranceCompany.Application.Services;
using Xunit;


public class ProposalServiceTests
{
    private readonly ProposalService _proposalService;
    private readonly DiscountService _discountService;
    private readonly InMemoryProposalRepository _proposalRepository; // Assuming this is set up
    private readonly InMemoryCompanyRepository _companyRepository; // Assuming this is set up
    private readonly IDiscountRepository _discountRuleRepository;

    public ProposalServiceTests()
    {
        _proposalRepository = new InMemoryProposalRepository();
        _companyRepository = new InMemoryCompanyRepository();
        _discountRuleRepository = new InMemoryDiscountRuleRepository();
        _discountService = new DiscountService(_discountRuleRepository);
        _proposalService = new ProposalService(_proposalRepository, _discountRuleRepository);
    }

    [Fact]
    public void AddInsuredGroupToProposal_ShouldAddGroupToProposal()
    {
        // Arrange
        var company = _companyRepository.Add(new Company("Test Company"));
        var proposalClass = new Proposal
        {
            CompanyId = company.Id,
        };
        var proposal = _proposalRepository.Add(proposalClass);
        var insuredGroup = new InsuredGroup(50, new Plan(PlanType.Base, 500M));

        // Act
        _proposalService.AddInsuredGroupToProposal(proposal.Id, insuredGroup.Plan, insuredGroup.NumberOfMembers);

        // Assert
        var updatedProposal = _proposalRepository.GetById(proposal.Id);
        Assert.Contains(insuredGroup, updatedProposal.InsuredGroups);
    }

    [Fact]
    public void CalculateTotalPremium_ShouldReturnCorrectAmount()
    {
        // Arrange
        var basePlan = new Plan(PlanType.Base, 500m);
        var company = _companyRepository.Add(new Company("Test Company"));
        var proposalClass = new Proposal
        {
            CompanyId = company.Id,
        };
        var proposal = _proposalRepository.Add(proposalClass);

        var insuredGroup = new InsuredGroup(150, basePlan);

        _proposalService.AddInsuredGroupToProposal(proposal.Id, insuredGroup.Plan, insuredGroup.NumberOfMembers);
        decimal expectedTotal = 67500m;

        // Act
        var totalPremium = _proposalService.CalculateTotalPremium(proposal.Id);

        // Assert
        Assert.Equal(expectedTotal, totalPremium);
    }

    [Fact]
    public void ApplyDiscount_ShouldReduceTotalPremium()
    {
        // Arrange

        var discountRule = new DiscountRule(50, PlanType.Base, 50);

        var discount = _discountService.CreateDiscount(discountRule);

        var company = _companyRepository.Add(new Company("Test Company"));
        var proposalClass = new Proposal
        {
            CompanyId = company.Id,
        };

        var plan = new Plan(PlanType.Base, 500M);
        var insuredGroup = new InsuredGroup(100, plan);
        var insuredGroups = new List<InsuredGroup>{
            insuredGroup
        };
        var proposal = _proposalService.CreateProposal(company.Id, insuredGroups);

        var discountPercentage = discount.Percentage;
        var initialTotal = _proposalService.CalculateTotalPremium(proposal.Id);
        var expectedTotalAfterDiscount = initialTotal - (initialTotal * (discountPercentage / 100));

        // Act
        _proposalService.AddInsuredGroupToProposal(proposal.Id, insuredGroup.Plan, insuredGroup.NumberOfMembers);

        // Assert
        var totalPremiumAfterDiscount = _proposalService.CalculateTotalPremium(proposal.Id);
        Assert.Equal(expectedTotalAfterDiscount, totalPremiumAfterDiscount);
    }

    [Fact]
    public void CreateDiscount_ShouldCreateDiscount()
    {

        //Arrange
        var discountRule = new DiscountRule(50, PlanType.Base, 50);
        //Act
        var discount = _discountService.CreateDiscount(discountRule);

        //Assert
        Assert.NotNull(discount);

    }




}
