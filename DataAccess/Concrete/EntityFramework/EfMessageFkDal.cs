using Core.DataAccess.Concrete.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Contexts;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfMessageFkDal : EfEntityRepositoryBase<MessageFk, DatabaseContext>, IMessageFkDal
    {
        public List<MessageFk> GetInBoxListWithMessageByWriter(int id)
        {
            var context = new DatabaseContext();
            return context.MessageFks.Include(x => x.WriterSender).Where(x => x.ReceiverId == id).ToList();
        }

        public List<MessageFk> GetSendBoxListWithMessageByWriter(int id)
        {
            var context = new DatabaseContext();
            return context.MessageFks.Include(x => x.WriterReceiver).Where(x => x.SenderId == id).ToList();
        }
    }
}