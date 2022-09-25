using Core.Entities.Abstract;

namespace Entities.Concrete
{
    public class About : IEntity
    {
        public int AboutId { get; set; }
        public string Image { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public bool Status { get; set; }
    }
}