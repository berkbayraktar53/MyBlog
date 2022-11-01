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

        public List<Blog> GetListWithCategoryByWriter(int writerId)
        {
            var context = new DatabaseContext();
            return context.Blogs.Include(x => x.Category).Where(x => x.WriterId == writerId).ToList();
        }

        public List<Blog> GetSearchResult(string query)
        {
            var context = new DatabaseContext();
            var result = context.Blogs.Where(x => x.Title.ToLower().Contains(query) || x.Content.ToLower().Contains(query)).AsQueryable();
            return result.ToList();
        }
    }
}