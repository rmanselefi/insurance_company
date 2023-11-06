namespace InsuranceCompany.Application.Interfaces
{
    public interface IPlanService
    {
        Plan CreatePlan(PlanType type, decimal price);
        Plan GetPlan(PlanType type);
        IEnumerable<Plan> GetAllPlans();
        // Additional methods for plan management
    }
}
