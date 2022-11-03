using Core.Business.Abstract;
using Entities.Concrete;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface IWriterService : IEntityService<User>
    {
        void Add(User writer);
        void Delete(User writer);
        void Update(User writer);
        List<User> GetWriterById(int id);
        User GetById(int id);
    }
}