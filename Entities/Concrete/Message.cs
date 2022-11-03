using System;
using Core.Entities.Abstract;

namespace Entities.Concrete
{
    public class Message : IEntity
    {
        public int MessageId { get; set; }
        public int? ReceiverId { get; set; }
        public int? SenderId { get; set; }
        public string Subject { get; set; }
        public string Detail { get; set; }
        public DateTime AddedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public bool Status { get; set; }
        public User UserReceiver { get; set; }
        public User UserSender { get; set; }
    }
}