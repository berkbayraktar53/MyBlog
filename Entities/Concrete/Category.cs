using Core.Entities.Abstract;
using System.Collections.Generic;

namespace Entities.Concrete
{
    public class Category : IEntity
    {
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<Blog> Blogs { get; set; }
        public bool Status { get; set; }
    }
}