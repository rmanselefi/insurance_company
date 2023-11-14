using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InsuranceCompany.Domain.Entities;
using InsuranceCompany.Domain.Interfaces;
using InsuranceCompany.Domain.ValueObjects;

namespace InsuranceCompany.Infrastructure.Persistence
{
    public class InMemoryDiscountRuleRepository : IDiscountRepository
    {
        List<DiscountRule> discountRules = new List<DiscountRule>();
        public DiscountRule CreateDiscount(DiscountRule discountRule)
        {
            discountRules.Add(discountRule);
            return discountRule;
        }

        public DiscountRule GetDiscountByPlan(Plan plan)
        {
            var discount = discountRules.FirstOrDefault(d => d.EligiblePlanType == plan.Type);
            return discount;
        }
    }
}