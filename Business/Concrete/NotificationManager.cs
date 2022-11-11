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

        public void Add(Notification entity)
        {
            _notificationDal.Add(entity);
        }

        public void Delete(Notification entity)
        {
            _notificationDal.Delete(entity);
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

        public void Update(Notification entity)
        {
            _notificationDal.Update(entity);
        }
    }
}