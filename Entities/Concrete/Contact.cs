using Core.Entities.Abstract;
using System;

namespace Entities.Concrete
{
    public class Contact : IEntity
    {
        public int ContactId { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }
        public DateTime Date { get; set; }
        public bool Status { get; set; }
    }
}