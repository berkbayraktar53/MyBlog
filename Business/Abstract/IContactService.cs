using Core.Business.Abstract;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface IContactService : IEntityService<Contact>
    {
        void Add(Contact contact);
    }
}