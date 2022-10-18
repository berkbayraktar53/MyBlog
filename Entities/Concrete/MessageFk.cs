using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    //Two foreign key from same table
    public class MessageFk : IEntity
    {
        public int MessageFkId { get; set; }
        public int? SenderId { get; set; }
        public int? ReceiverId { get; set; }
        public string Subject { get; set; }
        public string Detail { get; set; }
        public DateTime Date { get; set; }
        public bool Status { get; set; }
        public Writer WriterReceiver { get; set; }
        public Writer WriterSender { get; set; }
    }
}