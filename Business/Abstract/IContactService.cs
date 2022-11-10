﻿using Entities.Concrete;
using Core.Business.Abstract;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface IContactService : IEntityService<Contact>
    {
        void Add(Contact contact);
        void Delete(Contact contact);
        void Update(Contact contact);
        Contact GetById(int id);
        List<Contact> GetLast5ContactMessage();
    }
}