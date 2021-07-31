﻿using System.Collections.Generic;

namespace Vikaba.Data
{
    public class Tag
    {
        public int Id { get; set; }

        public string Title { get; set; } = "";
        
        public List<News> News { get; set; } = new List<News>();
    }
}