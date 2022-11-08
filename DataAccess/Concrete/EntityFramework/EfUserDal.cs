using System.Linq;
using Entities.Concrete;
using DataAccess.Abstract;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Core.DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.EntityFramework.Contexts;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfUserDal : EfEntityRepositoryBase<User, DatabaseContext>, IUserDal
    {
        public List<User> GetListWithBlog()
        {
            var context = new DatabaseContext();
            return context.Users.Include(x => x.Blogs).ToList();
        }
    }
}