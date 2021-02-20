using Business.Constants;
using DataAccess.Concrete.EntityFramework.Context;
using Entities.Concrete;
using FluentValidation;
using System.Linq;

namespace Business.ValidationRules.FluentValidation
{
    public class ColorValidator : AbstractValidator<Color>
    {
        public ColorValidator()
        {
            // Rulefor ile baslayarak kurallar yazılır.

            RuleFor(c => c.ColorName).NotEmpty().MinimumLength(2).WithMessage(Messages.ColorNameMinimumLength);
            RuleFor(c => c.ColorName).Must(BeUnique).WithMessage(Messages.DuplicateError);
        }
        private bool BeUnique(string arg)
        {
            // veri tabanindaki verilere bakar. mevcutta var ise false doner 
            using (ReCapProjectContext _context = new ReCapProjectContext())
            {
                int colorName = _context.Colors.Where(c=>c.ColorName == arg).Count();
                if (colorName == 0)
                {
                    return true;
                }
                return false;
            }

        }
    }
}
