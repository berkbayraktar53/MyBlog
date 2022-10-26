using Core.DataAccess.Concrete.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Contexts;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCommentDal : EfEntityRepositoryBase<Comment, DatabaseContext>, ICommentDal
    {
        public List<Comment> GetListWithBlog()
        {
            var context = new DatabaseContext();
            return context.Comments.Include(x => x.Blog).ToList();
        }
    }
}