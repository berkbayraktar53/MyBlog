using Core.Entities.Abstract;

namespace Entities.Concrete
{
    public class BlogRating : IEntity
    {
        public int BlogRatingId { get; set; }
        public int BlogId { get; set; }
        public int RatingCount { get; set; }
        public int TotalScore { get; set; }
    }
}