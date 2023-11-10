using Xunit;
using InsuranceCompany.Domain.Entities;
using InsuranceCompany.Domain.Interfaces;
using InsuranceCompany.Domain.ValueObjects;
using InsuranceCompany.Infrastructure.Persistence;
using System;
using InsuranceCompany.Application.Services;

namespace InsuranceCompany.UnitTests
{
    public class ProposalTests
    {
        private readonly ProposalService _proposalService;
        private readonly IProposalRepository _proposalRepository;

        public ProposalTests()
        {
            // Initialize the in-memory repository or mock here
            _proposalRepository = new InMemoryProposalRepository();
            _proposalService = new ProposalService(_proposalRepository);
        }

        [Fact]
        public void CreateProposal_Should_CreateNewProposal()
        {
            // Arrange
            var companyId = Guid.NewGuid();
            var plan = new Plan(PlanType.Base, 500m); // Example plan, replace with actual creation logic
            var insuredGroup = new InsuredGroup(100, plan); // Assuming 100 members for this group

            var insuredGroups = new List<InsuredGroup> { insuredGroup };

            // Act
            var proposal = _proposalService.CreateProposal(companyId, insuredGroups);

            // Assert
            Assert.NotNull(proposal);
            Assert.Equal(companyId, proposal.CompanyId);
            Assert.Single(proposal.InsuredGroups);
            Assert.Equal(100, proposal.InsuredGroups.First().NumberOfMembers);
        }
    }
}
