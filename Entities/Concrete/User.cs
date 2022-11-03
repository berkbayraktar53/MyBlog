using Core.Entities.Abstract;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace Entities.Concrete
{
    public class User : IdentityUser<int>, IEntity
    {
        public string FullName { get; set; }
        public string ImageUrl { get; set; }
        public List<Blog> Blogs { get; set; }
        public virtual ICollection<Message> UserSender { get; set; }
        public virtual ICollection<Message> UserReceiver { get; set; }
    }
}