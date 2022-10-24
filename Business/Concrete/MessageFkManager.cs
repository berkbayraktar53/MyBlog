using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System.Collections.Generic;
using System.Linq;

namespace Business.Concrete
{
    public class MessageFkManager : IMessageFkService
    {
        private readonly IMessageFkDal _messageFkDal;

        public MessageFkManager(IMessageFkDal messageFkDal)
        {
            _messageFkDal = messageFkDal;
        }

        public void Add(MessageFk message)
        {
            _messageFkDal.Add(message);
        }

        public MessageFk GetById(int id)
        {
            return _messageFkDal.GetById(id);
        }

        public List<MessageFk> GetInBoxListByWriter(int id)
        {
            return _messageFkDal.GetInBoxListWithMessageByWriter(id).Where(x => x.Status == true).OrderByDescending(x => x.Date).ToList();
        }

        public List<MessageFk> GetList()
        {
            return _messageFkDal.GetList();
        }

        public List<MessageFk> GetSendBoxListByWriter(int id)
        {
            return _messageFkDal.GetSendBoxListWithMessageByWriter(id).Where(x => x.Status == true).OrderByDescending(x => x.Date).ToList();
        }
    }
}