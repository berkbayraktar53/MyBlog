using Core.Business.Abstract;
using Entities.Concrete;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface IWriterService : IEntityService<Writer>
    {
        void Add(Writer writer);
        void Delete(Writer writer);
        void Update(Writer writer);
        List<Writer> GetWriterById(int id);
        Writer GetById(int id);
    }
}