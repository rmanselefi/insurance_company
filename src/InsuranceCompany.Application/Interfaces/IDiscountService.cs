using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InsuranceCompany.Domain.Entities;

namespace InsuranceCompany.Application.Interfaces
{
    public interface IDiscountService
    {
        DiscountRule CreateDiscount(DiscountRule discountRule);
    }
}