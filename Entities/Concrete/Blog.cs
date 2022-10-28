﻿using Core.Entities.Abstract;
using System;
using System.Collections.Generic;

namespace Entities.Concrete
{
    public class Blog : IEntity
    {
        public int BlogId { get; set; }
        public string Image { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime Date { get; set; }
        public int TotalViews { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public int WriterId { get; set; }
        public Writer Writer { get; set; }
        public List<Comment> Comments { get; set; }
        public bool Status { get; set; }
    }
}