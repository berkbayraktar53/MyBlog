using Core.Business.Abstract;
using Entities.Concrete;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface IMessageService : IEntityService<Message>
    {
        Message GetById(int messageId);
        void Add(Message message);
        List<Message> GetInBoxListByUser(int userId);
        List<Message> GetSendBoxListByUser(int userId);
    }
}