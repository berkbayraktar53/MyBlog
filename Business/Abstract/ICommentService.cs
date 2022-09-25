using Core.Business.Abstract;
using Entities.Concrete;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface ICommentService : IEntityService<Comment>
    {
        void Add(Comment comment);
        List<Comment> GetListByBlog(int blogId);
    }
}