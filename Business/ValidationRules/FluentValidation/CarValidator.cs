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
        }
    }
}
