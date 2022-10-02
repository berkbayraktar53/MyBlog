using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System.Collections.Generic;
using System.Linq;

namespace Business.Concrete
{
    public class BlogManager : IBlogService
    {
        private readonly IBlogDal _blogDal;

        public BlogManager(IBlogDal blogDal)
        {
            _blogDal = blogDal;
        }

        public List<Blog> GetList()
        {
            return _blogDal.GetList();
        }

        public List<Blog> GetListById(int blogId)
        {
            return _blogDal.GetList(x => x.BlogId == blogId);
        }

        public List<Blog> GetListWithCategory()
        {
            return _blogDal.GetListWithCategory();
        }

        public List<Blog> GetListByWriter(int writerId)
        {
            return _blogDal.GetList(x => x.WriterId == writerId);
        }

        public List<Blog> GetLast3Blog()
        {
            return _blogDal.GetList().TakeLast(3).ToList();
        }

        public void Add(Blog blog)
        {
            _blogDal.Add(blog);
        }

        public List<Blog> GetListWithCategoryByWriter(int writerID)
        {
            return _blogDal.GetListWithCategoryByWriter(writerID);
        }
    }
}