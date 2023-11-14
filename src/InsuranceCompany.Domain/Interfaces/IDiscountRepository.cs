using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InsuranceCompany.Domain.Entities;
using InsuranceCompany.Domain.ValueObjects;

namespace InsuranceCompany.Domain.Interfaces
{
    public interface IDiscountRepository
    {
        DiscountRule CreateDiscount(DiscountRule discountRule);
        DiscountRule GetDiscountByPlan(Plan plan);
    }
}