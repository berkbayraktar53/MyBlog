using FluentValidation;
using Entities.Concrete;

namespace Business.ValidationRules.FluentValidation
{
    public class AboutValidator : AbstractValidator<About>
    {
        public AboutValidator()
        {
            RuleFor(x => x.Image)
                .NotEmpty().WithMessage("Lütfen resim giriniz")
                .MinimumLength(5).WithMessage("Lütfen en az 5 karakter giriniz")
                .MaximumLength(150).WithMessage("Lütfen 150 karakterden az giriniz");

            RuleFor(x => x.Title)
                .NotEmpty().WithMessage("Lütfen başlık giriniz")
                .MinimumLength(5).WithMessage("Lütfen en az 5 karakter giriniz")
                .MaximumLength(50).WithMessage("Lütfen 50 karakterden az giriniz");

            RuleFor(x => x.Content).NotEmpty().WithMessage("Lütfen açıklama giriniz");
        }
    }
}