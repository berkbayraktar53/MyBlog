using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System.Collections.Generic;

namespace Business.Concrete
{
    public class MessageFkManager : IMessageFkService
    {
        private readonly IMessageFkDal _messageFkDal;

        public MessageFkManager(IMessageFkDal messageFkDal)
        {
            _messageFkDal = messageFkDal;
        }

        public MessageFk GetById(int id)
        {
            return _messageFkDal.GetById(id);
        }

        public List<MessageFk> GetInboxListByWriter(int id)
        {
            return _messageFkDal.GetListWithMessageByWriter(id);
        }

        public List<MessageFk> GetList()
        {
            return _messageFkDal.GetList();
        }
    }
}