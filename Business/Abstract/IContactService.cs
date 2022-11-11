using Entities.Concrete;
using Core.Business.Abstract;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface IContactService : IEntityService<Contact>
    {
        List<Contact> GetLast5ContactMessage();
    }
}