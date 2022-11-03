using Core.Business.Abstract;
using Entities.Concrete;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface IMessageService : IEntityService<Message>
    {
        List<Message> GetInboxListByWriter(int receiver);
    }
}