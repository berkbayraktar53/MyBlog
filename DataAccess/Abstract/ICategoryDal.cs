using Entities.Concrete;
using Core.DataAccess.Abstract;
using System.Collections.Generic;

namespace DataAccess.Abstract
{
    public interface ICategoryDal : IEntityRepository<Category>
    {
        List<Category> GetListWithBlog();
    }
}