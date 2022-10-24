using Core.Business.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IMessageFkService : IEntityService<MessageFk>
    {
        List<MessageFk> GetInBoxListByWriter(int id);
        List<MessageFk> GetSendBoxListByWriter(int id);
        MessageFk GetById(int id);
        void Add(MessageFk message);
    }
}