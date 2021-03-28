using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class CarValidator : AbstractValidator<Car>
    {
        public CarValidator()
        {

            RuleFor(p => p.Name).MinimumLength(2);
            RuleFor(p => p.DailyPrice).GreaterThanOrEqualTo(0);
            RuleFor(p => p.ColorId).NotEmpty();
            RuleFor(p => p.BrandId).NotEmpty();
            RuleFor(p => p.DailyPrice).GreaterThanOrEqualTo(0);
            RuleFor(p => p.ModelYear).GreaterThanOrEqualTo(1950);
            RuleFor(p => p.Name).NotEmpty();
            RuleFor(p => p.Description).NotEmpty().MinimumLength(10);

        }
    }
}
