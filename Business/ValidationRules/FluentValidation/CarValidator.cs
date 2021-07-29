using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class CarValidator:AbstractValidator<Car>
    {
        public CarValidator()
        {
            RuleFor(c => c.CarName).NotEmpty();
            RuleFor(c => c.CarName).MinimumLength(2);
            RuleFor(c => c.DailyPrice).NotEmpty();
            RuleFor(c => c.DailyPrice).GreaterThanOrEqualTo(0);
            RuleFor(c => c.CarName).Must(StartWithA).When(c => c.BrandId == 1).WithMessage("Araba isimleri A harfi ile başlamalıdır");

        }

        private bool StartWithA(string arg)
        {
            return arg.StartsWith("A");
        }
    }
}
