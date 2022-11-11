using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System.Collections.Generic;
using System.Linq;

namespace Business.Concrete
{
    public class CategoryManager : ICategoryService
    {
        private readonly ICategoryDal _categoryDal;

        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }

        public void Add(Category entity)
        {
            _categoryDal.Add(entity);
        }

        public void Delete(Category entity)
        {
            _categoryDal.Delete(entity);
        }

        public Category GetById(int id)
        {
            return _categoryDal.GetById(id);
        }

        public List<Category> GetList()
        {
            return _categoryDal.GetList().ToList();
        }

        public List<Category> GetListByActiveStatus()
        {
            return _categoryDal.GetList().Where(x => x.Status == true).ToList();
        }

        public List<Category> GetListWithBlog()
        {
            return _categoryDal.GetListWithBlog();
        }

        public void Update(Category entity)
        {
            _categoryDal.Update(entity);
        }
    }
}