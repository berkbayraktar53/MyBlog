using System.Linq;
using Entities.Concrete;
using DataAccess.Abstract;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Core.DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.EntityFramework.Contexts;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCategoryDal : EfEntityRepositoryBase<Category, DatabaseContext>, ICategoryDal
    {
        public List<Category> GetListWithBlog()
        {
            var context = new DatabaseContext();
            return context.Categories.Include(x => x.Blogs).Where(x => x.Status == true).ToList();
        }
    }
}