using Core.Business.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IMessageFkService : IEntityService<Message>
    {
        List<Message> GetInBoxListByWriter(int id);
        List<Message> GetSendBoxListByWriter(int id);
        Message GetById(int id);
        void Add(Message message);
    }
}