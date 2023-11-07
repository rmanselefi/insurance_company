using InsuranceCompany.Domain.Entities;
using InsuranceCompany.Domain.Interfaces;
using InsuranceCompany.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;

namespace InsuranceCompany.Infrastructure.Repositories
{
    public class InMemoryPlanRepository : IPlanRepository
    {
        private readonly List<Plan> _plans = new List<Plan>();

        public Plan Add(Plan plan)
        {
            _plans.Add(plan);
            return plan;
        }

        public Plan GetPlanById(Guid id)
        {
            return _plans.FirstOrDefault(p => p.Id == id);
        }

        public IEnumerable<Plan> GetAll()
        {
            return _plans;
        }
    }
}
