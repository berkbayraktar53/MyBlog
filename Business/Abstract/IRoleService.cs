using Entities.Concrete;
using Core.Business.Abstract;

namespace Business.Abstract
{
    public interface IRoleService : IEntityService<Role>
    {
        void AddAsync(Role role);
        void DeleteAsync(Role role);
        void UpdateAsync(Role role);
    }
}