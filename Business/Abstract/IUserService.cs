using Entities.Concrete;
using Core.Business.Abstract;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface IUserService : IEntityService<User>
    {
        void Add(User user);
        void Delete(User user);
        void Update(User user);
        User GetById(int userId);
        List<User> GetListWithBlog();
    }
}