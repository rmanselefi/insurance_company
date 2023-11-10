using InsuranceCompany.Application.Interfaces;
using InsuranceCompany.Domain.Entities;
using InsuranceCompany.Domain.ValueObjects;

using System;
using System.Collections.Generic;
using InsuranceCompany.Domain.Interfaces;

namespace InsuranceCompany.Application.Services
{
    public class PlanService : IPlanService
    {
        private readonly IPlanRepository _planRepository;

        public PlanService(IPlanRepository planRepository)
        {
            _planRepository = planRepository;
        }

        public Plan CreatePlan(PlanType type, decimal price)
        {
            var newPlan = new Plan(type, price);
            _planRepository.Add(newPlan);
            return newPlan;
        }

        public IEnumerable<Plan> GetAllPlans()
        {
            return _planRepository.GetAll();
        }

        public Plan GetPlanById(Guid id)
        {
            return _planRepository.GetPlanById(id);
        }

    }
}
