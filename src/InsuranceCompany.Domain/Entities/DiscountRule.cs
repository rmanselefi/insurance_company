using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InsuranceCompany.Domain.ValueObjects;

namespace InsuranceCompany.Domain.Entities
{
    public class DiscountRule
    {
        public Guid Id { get; set; }
        public int MemberThreshold { get; set; }
        public PlanType EligiblePlanType { get; set; }

        public decimal Percentage { get; set; }

        public DiscountRule(int memberThreshold, PlanType eligiblePlanType, decimal percentage)
        {
            EligiblePlanType = eligiblePlanType;
            MemberThreshold = memberThreshold;
            Percentage = percentage;

        }
    }
}