using Core.Entities.Abstract;
using Microsoft.AspNetCore.Identity;

namespace Entities.Concrete
{
    public class User : IdentityUser<int>, IEntity
    {
        public string FullName { get; set; }
        public string ImageUrl { get; set; }
        //public bool Status { get; set; }
    }
}