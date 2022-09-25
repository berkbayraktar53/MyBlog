using Core.Business.Abstract;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface IWriterService : IEntityService<Writer>
    {
        void Add(Writer writer);
    }
}