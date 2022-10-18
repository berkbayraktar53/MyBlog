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
        public List<MessageFk> GetListWithMessageByWriter(int id)
        {
            var context = new DatabaseContext();
            return context.MessageFks.Include(x => x.WriterSender).Where(x => x.ReceiverId == id).ToList();
        }
    }
}