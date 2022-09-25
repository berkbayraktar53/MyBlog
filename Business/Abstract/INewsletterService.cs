using Core.Business.Abstract;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface INewsletterService : IEntityService<Newsletter>
    {
        void Add(Newsletter newsletter);
    }
}