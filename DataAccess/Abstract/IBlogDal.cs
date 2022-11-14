using Entities.Concrete;
using Core.DataAccess.Abstract;
using System.Collections.Generic;

namespace DataAccess.Abstract
{
    public interface IBlogDal : IEntityRepository<Blog>
    {
        List<Blog> GetBlogWithCategoryAndComment(int blogId);
        List<Blog> GetListWithCategory();
        List<Blog> GetSearchResult(string query);
        List<Blog> GetListWithCategoryByUser(int userId);
        List<Blog> GetListWithCategoryAndUser();
        List<Blog> GetListWithCategoryAndComment();
    }
}