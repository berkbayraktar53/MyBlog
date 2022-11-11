using Core.Business.Abstract;
using Entities.Concrete;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface ICategoryService : IEntityService<Category>
    {
        List<Category> GetListWithBlog();
        List<Category> GetListByActiveStatus();
    }
}