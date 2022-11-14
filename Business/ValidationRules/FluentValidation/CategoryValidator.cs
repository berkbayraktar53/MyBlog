using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class CategoryValidator : AbstractValidator<Category>
    {
        public CategoryValidator()
        {
            RuleFor(x => x.CategoryName).NotEmpty().WithMessage("Kategori adını boş geçemezsiniz");
            RuleFor(x => x.CategoryName).MinimumLength(5).WithMessage("Lütfen en az 5 karakter giriniz");
            RuleFor(x => x.CategoryName).MaximumLength(12).WithMessage("Lütfen 12 karakterden az giriniz");
            RuleFor(x => x.Description).NotEmpty().WithMessage("Açıklamayı boş geçemezsiniz");
            RuleFor(x => x.Description).MinimumLength(5).WithMessage("Lütfen en az 5 karakter giriniz");
            RuleFor(x => x.Description).MaximumLength(50).WithMessage("Lütfen 50 karakterden az giriniz");
        }
    }
}