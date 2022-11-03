using System;
using Core.Entities.Abstract;

namespace Entities.Concrete
{
    public class Comment : IEntity
    {
        public int CommentId { get; set; }
        public int BlogId { get; set; }
        public Blog Blog { get; set; }
        public string NameSurname { get; set; }
        public string Email { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }
        public int BlogScore { get; set; }
        public DateTime AddedDate { get; set; }
        public bool Status { get; set; }
    }
}