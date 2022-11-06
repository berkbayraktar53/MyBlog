using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System.Collections.Generic;
using System.Linq;

namespace Business.Concrete
{
    public class NotificationManager : INotificationService
    {
        private readonly INotificationDal _notificationDal;

        public NotificationManager(INotificationDal notificationDal)
        {
            _notificationDal = notificationDal;
        }

        public void Add(Notification notification)
        {
            _notificationDal.Add(notification);
        }

        public void Delete(Notification notification)
        {
            _notificationDal.Delete(notification);
        }

        public Notification GetById(int notificationId)
        {
            return _notificationDal.GetById(notificationId);
        }

        public List<Notification> GetList()
        {
            return _notificationDal.GetList();
        }

        public List<Notification> GetListByActiveStatus()
        {
            return _notificationDal.GetList().Where(x => x.Status == true).OrderByDescending(x => x.ModifiedDate).ToList();
        }

        public void Update(Notification notification)
        {
            _notificationDal.Update(notification);
        }
    }
}