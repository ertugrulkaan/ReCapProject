using Business.Constants;
using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class CarValidator: AbstractValidator<Car>
    {
        public CarValidator()
        {
            // Rulefor ile baslayarak kurallar yazılır.

            RuleFor(c => c.BrandId).NotEmpty().WithMessage(Messages.EmptyError);
            RuleFor(c => c.ColorId).NotEmpty().WithMessage(Messages.EmptyError);
            RuleFor(c => c.DailyPrice).NotEmpty().WithMessage(Messages.EmptyError);
            RuleFor(c => c.DailyPrice).GreaterThan(0).WithMessage(Messages.CarDailyPriceError);
            RuleFor(c => c.ModelYear).GreaterThan(2015);
            RuleFor(c => c.CarName).MinimumLength(2).WithMessage(Messages.TwoCharError);
        }
    }
}
