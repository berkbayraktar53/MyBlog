using Entities.Concrete;
using Core.DataAccess.Abstract;
using System.Collections.Generic;

namespace DataAccess.Abstract
{
    public interface IUserDal : IEntityRepository<User>
    {
        List<User> GetListWithBlog();
    }
}