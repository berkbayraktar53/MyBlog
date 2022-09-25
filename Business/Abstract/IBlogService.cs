using Core.Business.Abstract;
using Entities.Concrete;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface IBlogService : IEntityService<Blog>
    {
        List<Blog> GetListWithCategory();
        List<Blog> GetListById(int blogId);
        List<Blog> GetListByWriter(int writerId);
        List<Blog> GetLast3Blog();
    }
}