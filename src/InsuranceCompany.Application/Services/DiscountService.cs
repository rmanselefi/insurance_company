using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InsuranceCompany.Application.Interfaces;
using InsuranceCompany.Domain.Entities;
using InsuranceCompany.Domain.Interfaces;

namespace InsuranceCompany.Application.Services
{
    public class DiscountService : IDiscountService
    {
        private readonly IDiscountRepository _discountRepository;

        public DiscountService(IDiscountRepository discountRepository)
        {
            _discountRepository = discountRepository;
        }
        public DiscountRule CreateDiscount(DiscountRule discountRule)
        {
            var discount = _discountRepository.CreateDiscount(discountRule);
            return discount;
        }

    }
}