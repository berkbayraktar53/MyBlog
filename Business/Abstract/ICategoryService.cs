using Core.Business.Abstract;
using Entities.Concrete;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface ICategoryService : IEntityService<Category>
    {
        void Add(Category category);
        void Delete(Category category);
        void Update(Category category);
        Category GetById(int id);
        List<Category> GetListByActiveStatus();
        List<Category> GetListWithBlog();
    }
}