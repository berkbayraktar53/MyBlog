using Core.Entities.Abstract;
using System;

namespace Entities.Concrete
{
    public class Message : IEntity
    {
        public int MessageId { get; set; }
        public string Sender { get; set; }
        public string Receiver { get; set; }
        public string Subject { get; set; }
        public string Detail { get; set; }
        public DateTime Date { get; set; }
        public bool Status { get; set; }
    }
}