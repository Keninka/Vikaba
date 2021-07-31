using System;
using System.Collections.Generic;

namespace Vikaba.Data
{
    public class News
    {
        public int Id { get; set; }

        public DateTime CreatedAt { get; set; }
        
        public DateTime PublishedAt { get; set; }

        public string Headline { get; set; } = "";
        
        public string SubHeadline { get; set; } = "";
        
        public string Content { get; set; } = "";
        
        public List<Tag> Tags { get; set; } = new List<Tag>();
        
    }
}