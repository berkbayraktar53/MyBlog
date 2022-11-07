using System.Linq;
using Entities.Concrete;
using DataAccess.Abstract;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Core.DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.EntityFramework.Contexts;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfBlogDal : EfEntityRepositoryBase<Blog, DatabaseContext>, IBlogDal
    {
        public List<Blog> GetListWithCategory()
        {
            var context = new DatabaseContext();
            return context.Blogs.Include(x => x.Category).ToList();
        }

        public List<Blog> GetListWithCategoryAndUser()
        {
            var context = new DatabaseContext();
            return context.Blogs.Include(x => x.Category).Include(y => y.User).ToList();
        }

        public List<Blog> GetListWithCategoryByUser(int userId)
        {
            var context = new DatabaseContext();
            return context.Blogs.Include(x => x.Category).Where(x => x.UserId == userId).ToList();
        }

        public List<Blog> GetSearchResult(string query)
        {
            var context = new DatabaseContext();
            var result = context.Blogs.Where(x => x.Title.ToLower().Contains(query) || x.Content.ToLower().Contains(query)).AsQueryable();
            return result.ToList();
        }
    }
}