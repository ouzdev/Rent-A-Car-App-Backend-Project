using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class CarImageValidator : AbstractValidator<CarImage>
    {
        public CarImageValidator()
        {
            RuleFor(p => p.CarId).NotEmpty();
            RuleFor(p => p.Date).NotEmpty();
            RuleFor(p => p.Id).NotEmpty();
            RuleFor(p => p.ImagePath).NotEmpty();
        }
    }
}
