using Core.Business.Abstract;
using Entities.Concrete;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface IMessageService : IEntityService<Message>
    {
        Message GetById(int messageId);
        void Add(Message message);
        void Delete(Message message);
        void Update(Message message);
        List<Message> GetInBoxListByUser(int userId);
        List<Message> GetSendBoxListByUser(int userId);
        List<Message> GetInBoxListByUserWithActiveStatus(int userId);
        List<Message> GetSendBoxListByUserWithActiveStatus(int userId);
    }
}