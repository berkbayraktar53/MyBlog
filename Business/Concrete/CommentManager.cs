using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System.Collections.Generic;

namespace Business.Concrete
{
    public class CommentManager : ICommentService
    {
        private readonly ICommentDal _commentDal;

        public CommentManager(ICommentDal commentDal)
        {
            _commentDal = commentDal;
        }

        public void Add(Comment comment)
        {
            _commentDal.Add(comment);
        }

        public List<Comment> GetList()
        {
            return _commentDal.GetList();
        }

        public List<Comment> GetListByBlog(int blogId)
        {
            return _commentDal.GetList(x => x.BlogId == blogId);
        }

        public List<Comment> GetListWithBlog()
        {
            return _commentDal.GetListWithBlog();
        }
    }
}