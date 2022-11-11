using Core.Business.Abstract;
using Entities.Concrete;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface ICommentService : IEntityService<Comment>
    {
        List<Comment> GetListWithBlog();
        List<Comment> GetListByBlog(int blogId);
    }
}