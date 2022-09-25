using Core.Entities.Abstract;

namespace Entities.Concrete
{
    public class Newsletter : IEntity
    {
        public int NewsletterId { get; set; }
        public string Email { get; set; }
        public bool Status { get; set; }
    }
}