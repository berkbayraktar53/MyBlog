using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class ContactValidator : AbstractValidator<Contact>
    {
        public ContactValidator()
        {
            RuleFor(x => x.UserName)
                .NotEmpty().WithMessage("Lütfen adınızı soyadınızı giriniz")
                .MinimumLength(5).WithMessage("Lütfen en az 5 karakter giriniz")
                .MaximumLength(20).WithMessage("Lütfen 20 karakterden az giriniz");
            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Lütfen mail adresinizi giriniz")
                .EmailAddress().WithMessage("Lütfen mail adresinizi geçerli bir formatta giriniz")
                .MinimumLength(5).WithMessage("Lütfen en az 5 karakter giriniz")
                .MaximumLength(50).WithMessage("Lütfen 50 karakterden az giriniz");
            RuleFor(x => x.Subject)
                .NotEmpty().WithMessage("Lütfen konuyu giriniz")
                .MinimumLength(5).WithMessage("Lütfen en az 5 karakter giriniz")
                .MaximumLength(30).WithMessage("Lütfen 30 karakterden az giriniz");
            RuleFor(x => x.Message)
                .NotEmpty().WithMessage("Lütfen mesajınızı giriniz")
                .MinimumLength(5).WithMessage("Lütfen en az 5 karakter giriniz")
                .MaximumLength(200).WithMessage("Lütfen 200 karakterden az giriniz");
        }
    }
}