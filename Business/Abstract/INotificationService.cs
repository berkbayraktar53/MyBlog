using Entities.Concrete;
using Core.Business.Abstract;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface INotificationService : IEntityService<Notification>
    {
        void Add(Notification notification);
        void Delete(Notification notification);
        void Update(Notification notification);
        Notification GetById(int notificationId);
        List<Notification> GetListByActiveStatus();
    }
}