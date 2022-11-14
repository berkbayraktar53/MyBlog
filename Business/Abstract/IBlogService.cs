using Entities.Concrete;
using Core.Business.Abstract;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface IBlogService : IEntityService<Blog>
    {
        List<Blog> GetBlogWithCategoryAndComment(int blogId);
        List<Blog> GetListWithCategory();
        List<Blog> GetListById(int blogId);
        List<Blog> GetListByUser(int userId);
        List<Blog> GetListByActiveStatus();
        List<Blog> GetLast3Blog();
        List<Blog> GetListByMostRead();
        List<Blog> GetListWithCategoryByUser(int userId);
        List<Blog> GetSearchResult(string query);
        List<Blog> GetListByCategory(int categoryId);
        List<Blog> GetListWithCategoryAndUser();
        List<Blog> GetListWithCategoryAndComment();

    }
}