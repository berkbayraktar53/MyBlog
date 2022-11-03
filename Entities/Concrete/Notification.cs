using System;
using Core.Entities.Abstract;

namespace Entities.Concrete
{
    public class Notification : IEntity
    {
        public int NotificationId { get; set; }
        public string NotificationType { get; set; }
        public string Detail { get; set; }
        public string TypeSymbol { get; set; }
        public DateTime AddedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public bool Status { get; set; }
    }
}