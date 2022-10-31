using Core.DataAccess.Concrete.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Contexts;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

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