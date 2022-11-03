using Entities.Concrete;
using Core.DataAccess.Abstract;
using System.Collections.Generic;

namespace DataAccess.Abstract
{
    public interface ICommentDal : IEntityRepository<Comment>
    {
        List<Comment> GetListWithBlog();
    }
}