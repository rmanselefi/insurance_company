
using InsuranceCompany.Domain.Entities;
using System.Collections.Generic;
using InsuranceCompany.Domain.ValueObjects;

namespace InsuranceCompany.Application.Interfaces
{
    public interface IPlanService
    {
        Plan CreatePlan(PlanType type, decimal price);
        IEnumerable<Plan> GetAllPlans();
        Plan GetPlanById(Guid id);
    }
}
