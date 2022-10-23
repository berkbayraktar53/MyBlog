using Core.Business.Abstract;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface IUserService : IEntityService<User>
    {
        User GetById(int id);
    }
}