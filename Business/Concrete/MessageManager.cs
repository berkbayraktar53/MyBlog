using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System.Collections.Generic;
using System.Linq;

namespace Business.Concrete
{
    public class MessageManager : IMessageService
    {
        private readonly IMessageDal _messageDal;

        public MessageManager(IMessageDal messageDal)
        {
            _messageDal = messageDal;
        }

        public List<Message> GetList()
        {
            return _messageDal.GetList().Where(x => x.Status == true).OrderByDescending(x => x.AddedDate).ToList();
        }

        public List<Message> GetInBoxListByUser(int userId)
        {
            return _messageDal.GetInBoxListWithMessageByUser(userId).OrderByDescending(x => x.ModifiedDate).ToList();
        }

        public List<Message> GetSendBoxListByUser(int userId)
        {
            return _messageDal.GetSendBoxListWithMessageByUser(userId).OrderByDescending(x => x.ModifiedDate).ToList();
        }

        public Message GetById(int messageId)
        {
            return _messageDal.GetById(messageId);
        }

        public void Add(Message entity)
        {
            _messageDal.Add(entity);
        }

        public void Delete(Message entity)
        {
            _messageDal.Delete(entity);
        }

        public void Update(Message entity)
        {
            _messageDal.Update(entity);
        }

        public List<Message> GetInBoxListByUserWithActiveStatus(int userId)
        {
            return _messageDal.GetInBoxListWithMessageByUser(userId).Where(x => x.Status == true).OrderByDescending(x => x.ModifiedDate).ToList();
        }

        public List<Message> GetSendBoxListByUserWithActiveStatus(int userId)
        {
            return _messageDal.GetSendBoxListWithMessageByUser(userId).Where(x => x.Status == true).OrderByDescending(x => x.ModifiedDate).ToList();
        }
    }
}