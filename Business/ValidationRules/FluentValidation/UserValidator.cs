using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(x => x.NameSurname)
                .NotEmpty().WithMessage("Lütfen adınızı soyadınızı giriniz")
                .MinimumLength(5).WithMessage("Lütfen en az 5 karakter giriniz")
                .MaximumLength(20).WithMessage("Lütfen 20 karakterden az giriniz");
            RuleFor(x => x.UserName)
                .NotEmpty().WithMessage("Kullanıcı adı boş geçilemez")
                .MinimumLength(5).WithMessage("Lütfen en az 5 karakter giriniz")
                .MaximumLength(20).WithMessage("Lütfen 20 karakterden az giriniz");
            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Lütfen mail adresinizi giriniz")
                .EmailAddress().WithMessage("Lütfen mail adresinizi geçerli bir formatta giriniz")
                .MinimumLength(5).WithMessage("Lütfen en az 5 karakter giriniz")
                .MaximumLength(50).WithMessage("Lütfen 50 karakterden az giriniz");
            RuleFor(x => x.PasswordHash)
                .NotEmpty().WithMessage("Lütfen şifrenizi giriniz")
                .MinimumLength(5).WithMessage("Lütfen en az 5 karakter giriniz")
                .MaximumLength(50).WithMessage("Lütfen 50 karakterden az giriniz")
                .Matches(@"[A-Z]+[a-z]+[0-9]").WithMessage("Şifreniz en az bir büyük harf, bir küçük harf, bir rakam içermelidir");
        }
    }
}