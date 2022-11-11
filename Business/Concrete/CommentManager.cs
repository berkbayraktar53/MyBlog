using Business.Abstract;
using Entities.Concrete;
using DataAccess.Abstract;
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

        public void Add(Comment entity)
        {
            _commentDal.Add(entity);
        }

        public void Delete(Comment entity)
        {
            _commentDal.Delete(entity);
        }

        public Comment GetById(int id)
        {
            return _commentDal.GetById(id);
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

        public void Update(Comment entity)
        {
            _commentDal.Update(entity);
        }
    }
}