using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class WriterValidator : AbstractValidator<User>
    {
        public WriterValidator()
        {
            RuleFor(x => x.FullName).NotEmpty().WithMessage("Adı Soyadı boş geçilemez");
            RuleFor(x => x.Email).NotEmpty().WithMessage("Mail Adresi boş geçilemez");
            RuleFor(x => x.PasswordHash).NotEmpty().WithMessage("Şifre boş geçilemez");
            RuleFor(x => x.ImageUrl).NotEmpty().WithMessage("Profil Resmi boş geçilemez");
            RuleFor(x => x.FullName).MinimumLength(2).WithMessage("Lütfen en az 2 karakter girişi yapın");
            RuleFor(x => x.FullName).MaximumLength(50).WithMessage("Lütfen en fazla 50 karakterlik veri girişi yapın");
            RuleFor(x => x.PasswordHash).Matches(@"[A-Z]+[a-z]+[0-9]").WithMessage("Şifreniz en az bir büyük harf, bir küçük harf, bir rakam içermelidir");
        }
    }
}