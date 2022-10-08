using Core.Entities.Abstract;
using System;

namespace Entities.Concrete
{
    public class Comment : IEntity
    {
        public int CommentId { get; set; }
        public string UserName { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }
        public DateTime Date { get; set; }
        public int BlogScore { get; set; }
        public int BlogId { get; set; }
        public Blog Blog { get; set; }
        public bool Status { get; set; }
    }
}