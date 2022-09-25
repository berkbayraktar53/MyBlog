using Core.Entities.Abstract;
using System.Collections.Generic;

namespace Entities.Concrete
{
    public class Writer : IEntity
    {
        public int WriterId { get; set; }
        public string Image { get; set; }
        public string Name { get; set; }
        public string About { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public List<Blog> Blogs { get; set; }
        public bool Status { get; set; }
    }
}