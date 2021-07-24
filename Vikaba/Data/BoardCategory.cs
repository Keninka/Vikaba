﻿using System.Collections.Generic;

namespace Vikaba.Data
{
    public class BoardCategory
    {
        public int Id { get; set; }
        
        public string Title { get; set; } = "";
        
        // 1:N
        public List<Board> Boards { get; set; } = new List<Board>();
    }
}