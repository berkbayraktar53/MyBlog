using Entities.Concrete;
using Core.DataAccess.Abstract;
using System.Collections.Generic;

namespace DataAccess.Abstract
{
    public interface IMessageDal : IEntityRepository<Message>
    {
        List<Message> GetInBoxListWithMessageByUser(int messageId);
        List<Message> GetSendBoxListWithMessageByUser(int messageId);
    }
}