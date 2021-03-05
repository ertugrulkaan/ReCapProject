using Business.Constants;
using DataAccess.Concrete.EntityFramework.Context;
using Entities.Concrete;
using FluentValidation;
using System.Linq;

namespace Business.ValidationRules.FluentValidation
{
    public class CustomerValidator : AbstractValidator<Customer>
    {
        public CustomerValidator()
        {
            // Rulefor ile baslayarak kurallar yazılır.

            RuleFor(c => c.CompanyName).NotEmpty().MinimumLength(2).WithMessage(Messages.EmptyError);
            RuleFor(c => c.UserID).Must(CheckUser).WithMessage(Messages.UserIsNotValid);
        }

        private bool CheckUser(int id)
        {
            // veri tabanindaki verilere bakar. mevcutta var ise false doner 
            using (ReCapProjectContext _context = new ReCapProjectContext())
            {
                var user = _context.Users.Where(u => u.Id == id).FirstOrDefault();
                if (user == null)
                {
                    return false;
                }
                return true;
            }

        }
    }
}
