using Entities.Concrete;
using Core.Business.Abstract;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface IUserService : IEntityService<User>
    {
        void AddAsync(User user);
        void DeleteAsync(User user);
        void UpdateAsync(User user);
        List<User> GetListWithBlog();
        List<User> GetLast10UserList();
    }
}