using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class NotificationValidator : AbstractValidator<Notification>
    {
        public NotificationValidator()
        {
            RuleFor(x => x.NotificationType).NotEmpty().WithMessage("Bildirim adını boş geçemezsiniz");
            RuleFor(x => x.TypeSymbol).NotEmpty().WithMessage("Bildirim sembolünü boş geçemezsiniz");
            RuleFor(x => x.Detail).NotEmpty().WithMessage("Bildirim detayını boş geçemezsiniz");
        }
    }
}