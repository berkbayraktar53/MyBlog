using Core.Business.Abstract;
using Entities.Concrete;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface ICommentService : IEntityService<Comment>
    {
        void Add(Comment comment);
        void Delete(Comment comment);
        void Update(Comment comment);
        Comment GetById(int id);
        List<Comment> GetListWithBlog();
        List<Comment> GetListByBlog(int blogId);
    }
}