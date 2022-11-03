using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System.Collections.Generic;
using System.Linq;

namespace Business.Concrete
{
    public class MessageFkManager : IMessageService
    {
        private readonly IMessageDal _messageDal;

        public MessageFkManager(IMessageDal messageDal)
        {
            _messageDal = messageDal;
        }

        public void Add(Message message)
        {
            _messageDal.Add(message);
        }

        public Message GetById(int id)
        {
            return _messageDal.GetById(id);
        }

        public List<Message> GetInBoxListByWriter(int id)
        {
            return _messageDal.GetInBoxListWithMessageByWriter(id).Where(x => x.Status == true).OrderByDescending(x => x.Date).ToList();
        }

        public List<Message> GetList()
        {
            return _messageDal.GetList();
        }

        public List<Message> GetSendBoxListByWriter(int id)
        {
            return _messageDal.GetSendBoxListWithMessageByWriter(id).Where(x => x.Status == true).OrderByDescending(x => x.Date).ToList();
        }
    }
}