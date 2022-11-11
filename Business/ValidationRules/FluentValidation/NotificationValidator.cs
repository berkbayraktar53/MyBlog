using Entities.Concrete;
using FluentValidation;

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