﻿using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Notification : IEntity
    {
        public int NotificationId { get; set; }
        public string Type { get; set; }
        public string TypeSymbol { get; set; }
        public string Detail { get; set; }
        public DateTime Date { get; set; }
        public bool Status { get; set; }
    }
}