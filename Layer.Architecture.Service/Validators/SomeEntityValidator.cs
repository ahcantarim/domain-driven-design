using FluentValidation;
using Layer.Architecture.Domain.Entities;

namespace Layer.Architecture.Service.Validators
{
    public class SomeEntityValidator : AbstractValidator<SomeEntity>
    {
        public SomeEntityValidator()
        {
            RuleFor(c => c.SomeValue)
                .NotEmpty().WithMessage("Please enter the SomeValue.")
                .NotNull().WithMessage("Please enter the SomeValue.");
        }
    }
}
