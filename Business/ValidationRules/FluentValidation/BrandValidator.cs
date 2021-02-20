using Business.Constants;
using DataAccess.Concrete.EntityFramework.Context;
using Entities.Concrete;
using FluentValidation;
using System;
using System.Linq;

namespace Business.ValidationRules.FluentValidation
{
    public class BrandValidator : AbstractValidator<Brand>
    {
        public BrandValidator()
        {
            // Rulefor ile baslayarak kurallar yazılır.

            RuleFor(c => c.BrandName).NotEmpty().MinimumLength(2).WithMessage(Messages.BrandNameMinimumLength);
            RuleFor(c => c.BrandName).Must(BeUnique).WithMessage(Messages.DuplicateError);
        }

        private bool BeUnique(string arg)
        {
            // veri tabanindaki verilere bakar. mevcutta var ise false doner 
            using (ReCapProjectContext _context = new ReCapProjectContext())
            {
                int brandName = _context.Brands.Where(b => b.BrandName == arg).Count();
                if (brandName == 0)
                {
                    return true;
                }
                return false;
            }
            
        }
    }
}
