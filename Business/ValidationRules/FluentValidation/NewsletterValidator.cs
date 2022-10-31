using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class NewsletterValidator : AbstractValidator<Newsletter>
    {
        public NewsletterValidator()
        {
            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Lütfen mail adresinizi giriniz")
                .EmailAddress().WithMessage("Lütfen mail adresinizi geçerli bir formatta giriniz")
                .MinimumLength(5).WithMessage("Lütfen en az 5 karakter giriniz")
                .MaximumLength(50).WithMessage("Lütfen 50 karakterden az giriniz");
        }
    }
}