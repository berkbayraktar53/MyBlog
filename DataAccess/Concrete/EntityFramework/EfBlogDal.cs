using Core.DataAccess.Concrete.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Contexts;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfBlogDal : EfEntityRepositoryBase<Blog, DatabaseContext>, IBlogDal
    {
        public List<Blog> GetListWithCategory()
        {
            var context = new DatabaseContext();
            return context.Blogs.Include(x => x.Category).ToList();
        }
    }
}