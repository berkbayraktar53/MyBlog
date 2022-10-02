using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class BlogValidator : AbstractValidator<Blog>
    {
        public BlogValidator()
        {
            RuleFor(x => x.Title).NotEmpty().WithMessage("Blog başlığını boş geçemezsiniz");
            RuleFor(x => x.Content).NotEmpty().WithMessage("Blog içeriğini boş geçemezsiniz");
            RuleFor(x => x.Image).NotEmpty().WithMessage("Blog görselini boş geçemezsiniz");
            RuleFor(x => x.Title).MaximumLength(150).WithMessage("Lütfen 150 karakterden daha az veri girişi yapın");
            RuleFor(x => x.Title).MinimumLength(5).WithMessage("Lütfen 5 karakterden daha az veri girişi yapın");
        }
    }
}