using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class MessageValidator : AbstractValidator<Message>
    {
        public MessageValidator()
        {
            RuleFor(x => x.Subject)
                .NotEmpty().WithMessage("Lütfen konuyu giriniz")
                .MinimumLength(5).WithMessage("Lütfen en az 5 karakter giriniz")
                .MaximumLength(50).WithMessage("Lütfen 50 karakterden az giriniz");
            RuleFor(x => x.Detail)
                .NotEmpty().WithMessage("Lütfen mesajınızı giriniz")
                .MinimumLength(5).WithMessage("Lütfen en az 5 karakter giriniz")
                .MaximumLength(250).WithMessage("Lütfen 250 karakterden az giriniz");
        }
    }
}