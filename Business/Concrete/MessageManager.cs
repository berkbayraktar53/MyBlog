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
    }
}