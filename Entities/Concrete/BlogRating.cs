using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class BlogRating : IEntity
    {
        public int BlogRatingId { get; set; }
        public int BlogId { get; set; }
        public int TotalScore { get; set; }
        public int RatingCount { get; set; }
        public bool Status { get; set; }
    }
}