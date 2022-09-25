using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System.Collections.Generic;

namespace Business.Concrete
{
    public class ContactManager : IContactService
    {
        private readonly IContactDal _contactDal;

        public ContactManager(IContactDal contactDal)
        {
            _contactDal = contactDal;
        }

        public void Add(Contact contact)
        {
            _contactDal.Add(contact);
        }

        public List<Contact> GetList()
        {
            return _contactDal.GetList();
        }
    }
}