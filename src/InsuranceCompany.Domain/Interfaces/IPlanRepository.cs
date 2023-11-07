using InsuranceCompany.Domain.Entities;
using InsuranceCompany.Domain.ValueObjects;
using System;
using System.Collections.Generic;

namespace InsuranceCompany.Domain.Interfaces
{
    public interface IPlanRepository
    {
        Plan Add(Plan plan);
        Plan GetPlanById(Guid id);
        IEnumerable<Plan> GetAll();
    }
}
