using Business.Constants;
using DataAccess.Concrete.EntityFramework.Context;
using Entities.Concrete;
using FluentValidation;
using System;
using System.Linq;

namespace Business.ValidationRules.FluentValidation
{
    public class RentalValidator : AbstractValidator<Rental>
    {
        public RentalValidator()
        {
            // Rulefor ile baslayarak kurallar yazılır.

            RuleFor(r => r.CustomerID).NotEmpty().Must(CheckUser).WithMessage(Messages.UserIsNotValid);
            RuleFor(r => r.CarID).NotEmpty().Must(CheckCar).WithMessage(Messages.CarNotValid);
            RuleFor(r => r.RentDate).NotEmpty();

        }

        private bool CheckCar(int id)
        {
            using (ReCapProjectContext _context = new ReCapProjectContext())
            {
                int car = _context.Cars.Where(c => c.ID == id).Count();
                if (car == 0)
                {
                    return false;
                }
                return true;
            }
        }

        private bool CheckUser(int id)
        {
            using (ReCapProjectContext _context = new ReCapProjectContext())
            {
                int user = _context.Users.Where(u => u.Id == id).Count();
                if (user == 0)
                {
                    return false;
                }
                return true;
            }
        }
    }
}
