using Entities.Concrete;
using Core.DataAccess.Abstract;

namespace DataAccess.Abstract
{
    public interface IUserDal : IEntityRepository<User>
    {

    }
}