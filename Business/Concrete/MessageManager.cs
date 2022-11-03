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
            return _messageDal.GetList().Where(x => x.Status == true).OrderByDescending(x => x.Date).ToList();
        }

        public List<Message> GetInboxListByWriter(int receiver)
        {
            return _messageDal.GetList(x => x.ReceiverId == receiver && x.Status == true).OrderByDescending(x => x.Date).ToList();
        }

        public List<Message> GetInBoxListByWriter(int id)
        {
            return _messageDal.GetInBoxListWithMessageByWriter(id).Where(x => x.Status == true).OrderByDescending(x => x.Date).ToList();
        }

        public List<Message> GetSendBoxListByWriter(int id)
        {
            return _messageDal.GetSendBoxListWithMessageByWriter(id).Where(x => x.Status == true).OrderByDescending(x => x.Date).ToList();
        }

        public Message GetById(int id)
        {
            return _messageDal.GetById(id);
        }

        public void Add(Message message)
        {
            _messageDal.Add(message);
        }
    }
}