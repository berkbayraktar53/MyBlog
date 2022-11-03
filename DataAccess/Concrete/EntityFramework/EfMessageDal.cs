using Core.DataAccess.Concrete.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Contexts;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfMessageDal : EfEntityRepositoryBase<Message, DatabaseContext>, IMessageDal
    {
        public List<Message> GetInBoxListWithMessageByUser(int userId)
        {
            var context = new DatabaseContext();
            return context.Messages.Include(x => x.UserSender).Where(x => x.ReceiverId == userId).ToList();
        }

        public List<Message> GetSendBoxListWithMessageByUser(int userId)
        {
            var context = new DatabaseContext();
            return context.Messages.Include(x => x.UserReceiver).Where(x => x.SenderId == userId).ToList();
        }
    }
}