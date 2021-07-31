using System;
using System.Collections.Generic;

namespace Vikaba.Data
{
    public class BoardThread
    {
        public int Id { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public string Headline { get; set; } = "";

        public string Content { get; set; } = "";

        public string? Image { get; set; }

        public int BoardId { get; set; }
        public Board Board { get; set; } = null!;

        public List<Comment> Comments { get; set; } = new List<Comment>();
    }
}