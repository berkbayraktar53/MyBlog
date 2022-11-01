using Core.Business.Abstract;
using Entities.Concrete;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface IBlogService : IEntityService<Blog>
    {
        void Add(Blog blog);
        void Delete(Blog blog);
        void Update(Blog blog);
        Blog GetById(int id);
        List<Blog> GetListWithCategory();
        List<Blog> GetListById(int blogId);
        List<Blog> GetListByWriter(int writerId);
        List<Blog> GetListByActiveStatus();
        List<Blog> GetLast3Blog();
        List<Blog> GetListByMostRead();
        List<Blog> GetListWithCategoryByWriter(int writerID);
        List<Blog> GetSearchResult(string query);
        List<Blog> GetListByCategory(int categoryId);

    }
}