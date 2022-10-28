using Business.Abstract;
using Business.ValidationRules.FluentValidation;
using DataAccess.Abstract;
using Entities.Concrete;
using FluentValidation.Results;
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
            return _blogDal.GetList().OrderByDescending(x => x.Date).ToList(); ;
        }

        public List<Blog> GetListById(int blogId)
        {
            return _blogDal.GetList(x => x.BlogId == blogId).Where(x => x.Status == true).OrderByDescending(x => x.Date).ToList();
        }

        public List<Blog> GetListWithCategory()
        {
            return _blogDal.GetListWithCategory().Where(x => x.Status == true).OrderByDescending(x => x.Date).ToList();
        }

        public List<Blog> GetListByWriter(int writerId)
        {
            return _blogDal.GetList(x => x.WriterId == writerId).Where(x => x.Status == true).OrderByDescending(x => x.Date).ToList();
        }

        public List<Blog> GetLast3Blog()
        {
            return _blogDal.GetListWithCategory().Where(x => x.Status == true).TakeLast(3).OrderByDescending(x => x.Date).ToList();
        }

        public void Add(Blog blog)
        {
            _blogDal.Add(blog);
        }

        public List<Blog> GetListWithCategoryByWriter(int writerID)
        {
            return _blogDal.GetListWithCategoryByWriter(writerID).Where(x => x.Status == true).OrderByDescending(x => x.Date).ToList();
        }

        public void Delete(Blog blog)
        {
            _blogDal.Delete(blog);
        }

        public Blog GetById(int id)
        {
            return _blogDal.GetById(id);
        }

        public void Update(Blog blog)
        {
            _blogDal.Update(blog);
        }

        public List<Blog> GetListByActiveStatus()
        {
            return _blogDal.GetList().Where(x => x.Status == true).OrderByDescending(x => x.Date).ToList();
        }

        public List<Blog> GetListByMostRead()
        {
            return _blogDal.GetList().Where(x => x.Status == true).TakeLast(3).OrderBy(x => x.TotalViews).ToList();
        }
    }
}