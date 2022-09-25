using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class WriterValidator : AbstractValidator<Writer>
    {
        public WriterValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Yazar adı soyadı kısmı boş geçilemez");
            RuleFor(x => x.Email).NotEmpty().WithMessage("Mail adresi boş geçilemez");
            RuleFor(x => x.Password).NotEmpty().WithMessage("Şifre boş geçilemez");
            RuleFor(x => x.Name).MinimumLength(2).WithMessage("Lütfen en az 2 karakter girişi yapın");
            RuleFor(x => x.Name).MaximumLength(50).WithMessage("Lütfen en fazla 50 karakterlik veri girişi yapın");
            RuleFor(x => x.Password).Matches(@"[A-Z]+[a-z]+[0-9]").WithMessage("Şifreniz en az bir büyük harf, bir küçük harf, bir rakam içermelidir");
        }
    }
}