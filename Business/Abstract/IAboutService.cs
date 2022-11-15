using Entities.Concrete;
using Core.Business.Abstract;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface IAboutService : IEntityService<About>
    {
        List<About> GetListByActiveStatus();
    }
}