using System;
using Core.Entities.Abstract;

namespace Entities.Concrete
{
    public class Contact : IEntity
    {
        public int ContactId { get; set; }
        public string NameSurname { get; set; }
        public string Email { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }
        public DateTime AddedDate { get; set; }
        public bool Status { get; set; }
    }
}