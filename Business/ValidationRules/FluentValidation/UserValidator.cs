using Core.Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(p => p.FirstName).NotEmpty().MinimumLength(2);
            RuleFor(p => p.LastName).NotEmpty().MinimumLength(2);
            RuleFor(p => p.Email).NotEmpty().EmailAddress();
            RuleFor(p => p.PasswordHash).NotEmpty();
        }
    }
}
