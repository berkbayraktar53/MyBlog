using Core.Entities.Abstract;
using Microsoft.AspNetCore.Identity;

namespace Entities.Concrete
{
    public class Role : IdentityRole<int>, IEntity
    {

    }
}