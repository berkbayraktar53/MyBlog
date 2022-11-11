using Core.Business.Abstract;
using Entities.Concrete;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface IMessageService : IEntityService<Message>
    {
        List<Message> GetInBoxListByUser(int userId);
        List<Message> GetSendBoxListByUser(int userId);
        List<Message> GetInBoxListByUserWithActiveStatus(int userId);
        List<Message> GetSendBoxListByUserWithActiveStatus(int userId);
    }
}