using Core.DataAccess.Abstract;
using Entities.Concrete;
using System.Collections.Generic;

namespace DataAccess.Abstract
{
    public interface IMessageDal : IEntityRepository<Message>
    {
        List<Message> GetInBoxListWithMessageByWriter(int id);
        List<Message> GetSendBoxListWithMessageByWriter(int id);
    }
}