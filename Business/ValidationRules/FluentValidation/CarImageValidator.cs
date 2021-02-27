using Business.Constants;
using DataAccess.Concrete.EntityFramework.Context;
using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class CarImageValidator : AbstractValidator<CarImage>
    {
        public CarImageValidator()
        {
            RuleFor(i => i.CarId).NotEmpty().WithMessage(Messages.CarImageCarIdEmpty);
            RuleFor(i => i.CarId).Must(CarMustExits).WithMessage(Messages.CarImageCarNotFound);
        }
        public bool CarMustExits(int CarId)
        {
            // Araba sistemde yoksa eklemez
            using (ReCapProjectContext _context = new ReCapProjectContext())
            {
                int carCount = _context.Cars.Where(c => c.ID == CarId).Count();
                if (carCount == 1)
                {
                    return true;
                }
                return false;
            }
        }
    }
}
