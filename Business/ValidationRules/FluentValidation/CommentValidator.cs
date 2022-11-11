using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class CommentValidator : AbstractValidator<Comment>
    {
        public CommentValidator()
        {
            RuleFor(x => x.NameSurname)
                .NotEmpty().WithMessage("Lütfen adı soyadı giriniz")
                .MinimumLength(5).WithMessage("Lütfen en az 5 karakter giriniz")
                .MaximumLength(20).WithMessage("Lütfen 20 karakterden az giriniz");
            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Lütfen mail adresi giriniz")
                .EmailAddress().WithMessage("Lütfen mail adresini geçerli bir formatta giriniz")
                .MinimumLength(5).WithMessage("Lütfen en az 5 karakter giriniz")
                .MaximumLength(50).WithMessage("Lütfen 50 karakterden az giriniz");
            RuleFor(x => x.Subject)
                .NotEmpty().WithMessage("Lütfen konuyu giriniz")
                .MinimumLength(5).WithMessage("Lütfen en az 5 karakter giriniz")
                .MaximumLength(30).WithMessage("Lütfen 30 karakterden az giriniz");
            RuleFor(x => x.Message)
                .NotEmpty().WithMessage("Lütfen mesajı giriniz")
                .MinimumLength(5).WithMessage("Lütfen en az 5 karakter giriniz")
                .MaximumLength(200).WithMessage("Lütfen 200 karakterden az giriniz");
        }
    }
}