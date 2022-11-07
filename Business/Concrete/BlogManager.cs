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
            return _blogDal.GetList().OrderByDescending(x => x.AddedDate).ToList(); ;
        }

        public List<Blog> GetListById(int blogId)
        {
            return _blogDal.GetList(x => x.BlogId == blogId).Where(x => x.Status == true).OrderByDescending(x => x.AddedDate).ToList();
        }

        public List<Blog> GetListWithCategory()
        {
            return _blogDal.GetListWithCategory().Where(x => x.Status == true).OrderByDescending(x => x.AddedDate).ToList();
        }

        public List<Blog> GetListByUser(int userId)
        {
            return _blogDal.GetList(x => x.UserId == userId).Where(x => x.Status == true).OrderByDescending(x => x.AddedDate).ToList();
        }

        public List<Blog> GetLast3Blog()
        {
            return _blogDal.GetListWithCategory().Where(x => x.Status == true).TakeLast(3).OrderByDescending(x => x.AddedDate).ToList();
        }

        public void Add(Blog blog)
        {
            _blogDal.Add(blog);
        }

        public List<Blog> GetListWithCategoryByUser(int userId)
        {
            return _blogDal.GetListWithCategoryByUser(userId).Where(x => x.Status == true).OrderByDescending(x => x.AddedDate).ToList();
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
            return _blogDal.GetList().Where(x => x.Status == true).OrderByDescending(x => x.AddedDate).ToList();
        }

        public List<Blog> GetListByMostRead()
        {
            return _blogDal.GetListWithCategory().Where(x => x.Status == true).OrderByDescending(x => x.TotalViews).Take(3).ToList();
        }

        public List<Blog> GetSearchResult(string query)
        {
            return _blogDal.GetSearchResult(query);
        }

        public List<Blog> GetListByCategory(int categoryId)
        {
            return _blogDal.GetListWithCategory().Where(x => x.Status == true && x.CategoryId == categoryId).OrderByDescending(x => x.AddedDate).ToList();
        }

        public List<Blog> GetListWithCategoryAndUser()
        {
            return _blogDal.GetListWithCategoryAndUser();
        }
    }
}