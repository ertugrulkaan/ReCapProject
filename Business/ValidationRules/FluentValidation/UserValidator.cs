using Business.Constants;
using DataAccess.Concrete.EntityFramework.Context;
using Entities.Concrete;
using FluentValidation;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Business.ValidationRules.FluentValidation
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            // Rulefor ile baslayarak kurallar yazılır.

            RuleFor(u => u.FirstName).NotEmpty().MinimumLength(2).WithMessage(Messages.TwoCharError);
            RuleFor(u => u.LastName).NotEmpty().MinimumLength(2).WithMessage(Messages.TwoCharError);
            RuleFor(u => u.Password).NotEmpty().MinimumLength(4).MaximumLength(15).WithMessage(Messages.PasswordLenghtError);
            RuleFor(u => u.Email).NotEmpty().Must(EmailChecker).WithMessage(Messages.EmailError);
        }

        public bool EmailChecker(string email)
        {
            bool isValid = new EmailAddressAttribute().IsValid(email);
            bool isUnique = false;
            using (ReCapProjectContext _context = new ReCapProjectContext())
            {
                int user = _context.Users.Where(u => u.Email == email).Count();
                isUnique = user == 0 ? true : false;
            }
            if (isValid && isUnique)
            {
                return true;
            }
            return false;
        }
    }
}
