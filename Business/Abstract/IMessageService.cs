using Core.Business.Abstract;
using Entities.Concrete;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface IMessageService : IEntityService<Message>
    {
        Message GetById(int id);
        void Add(Message message);
        List<Message> GetInBoxListByWriter(int id);
        List<Message> GetSendBoxListByWriter(int id);
    }
}