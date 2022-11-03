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
    public class EfMessageFkDal : EfEntityRepositoryBase<Message, DatabaseContext>, IMessageDal
    {
        public List<Message> GetInBoxListWithMessageByWriter(int id)
        {
            var context = new DatabaseContext();
            return context.Messages.Include(x => x.UserSender).Where(x => x.ReceiverId == id).ToList();
        }

        public List<Message> GetSendBoxListWithMessageByWriter(int id)
        {
            var context = new DatabaseContext();
            return context.Messages.Include(x => x.UserReceiver).Where(x => x.SenderId == id).ToList();
        }
    }
}