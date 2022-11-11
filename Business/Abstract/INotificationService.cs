using Entities.Concrete;
using Core.Business.Abstract;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface INotificationService : IEntityService<Notification>
    {
        List<Notification> GetListByActiveStatus();
    }
}