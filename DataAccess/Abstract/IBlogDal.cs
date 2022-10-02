using Core.DataAccess.Abstract;
using Entities.Concrete;
using System.Collections.Generic;

namespace DataAccess.Abstract
{
    public interface IBlogDal : IEntityRepository<Blog>
    {
        List<Blog> GetListWithCategory();
        List<Blog> GetListWithCategoryByWriter(int writerId);
    }
}