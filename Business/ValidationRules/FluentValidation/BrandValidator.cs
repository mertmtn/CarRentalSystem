using Business.Constants.Validation;
using Entities.Concrete;
using FluentValidation; 

namespace Business.ValidationRules.FluentValidation
{
    public class BrandValidator:AbstractValidator<Brand>
    {
        public BrandValidator()
        {
            RuleFor(b => b.Name).NotEmpty().WithMessage(BrandValidationMessage.BrandNameNotEmpty);
            RuleFor(b => b.Name).Length(2, 100).WithMessage(BrandValidationMessage.BrandNameLength(2, 100));
        }
    }
}
