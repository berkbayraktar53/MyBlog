using Entities.Concrete;
using Core.Business.Abstract;

namespace Business.Abstract
{
    public interface IAboutService : IEntityService<About>
    {
        void Add(About about);
        void Delete(About about);
        void Update(About about);
        About GetById(int id);
    }
}