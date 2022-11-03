using Entities.Concrete;
using Core.DataAccess.Abstract;

namespace DataAccess.Abstract
{
    public interface IContactDal : IEntityRepository<Contact>
    {

    }
}