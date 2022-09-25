using System.Collections.Generic;

namespace Core.Business.Abstract
{
    public interface IEntityService<T>
    {
        List<T> GetList();
    }
}