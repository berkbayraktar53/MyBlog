using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(x => x.ImageUrl)
                .NotEmpty().WithMessage("Lütfen yazar resmi giriniz")
                .MinimumLength(5).WithMessage("Lütfen en az 5 karakter giriniz")
                .MaximumLength(150).WithMessage("Lütfen 150 karakterden az giriniz");
            RuleFor(x => x.NameSurname)
                .NotEmpty().WithMessage("Lütfen adı soyadı giriniz")
                .MinimumLength(5).WithMessage("Lütfen en az 5 karakter giriniz")
                .MaximumLength(20).WithMessage("Lütfen 20 karakterden az giriniz");
            RuleFor(x => x.UserName)
                .NotEmpty().WithMessage("Lütfen kullanıcı adı giriniz")
                .MinimumLength(5).WithMessage("Lütfen en az 5 karakter giriniz")
                .MaximumLength(20).WithMessage("Lütfen 20 karakterden az giriniz");
            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Lütfen mail adresi giriniz")
                .EmailAddress().WithMessage("Lütfen mail adresini geçerli bir formatta giriniz")
                .MinimumLength(5).WithMessage("Lütfen en az 5 karakter giriniz")
                .MaximumLength(50).WithMessage("Lütfen 50 karakterden az giriniz");
            RuleFor(x => x.PasswordHash)
                .NotEmpty().WithMessage("Lütfen şifre giriniz")
                .MinimumLength(5).WithMessage("Lütfen en az 5 karakter giriniz")
                .MaximumLength(150).WithMessage("Lütfen 150 karakterden az giriniz")
                .Matches(@"[A-Z]+[a-z]+[0-9]").WithMessage("Şifre en az bir büyük harf, bir küçük harf, bir rakam içermelidir");
        }
    }
}