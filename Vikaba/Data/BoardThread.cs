using System;
using System.Collections.Generic;

namespace Vikaba.Data
{
    public class BoardThread
    {
        public int Id { get; set; }

        public string Subject { get; set; } = "";

        public string UserText { get; set; } = "";

        public DateTime CreatedAt { get; set; }

        public int BoardId { get; set; }
        public Board Board { get; set; } = null!;

        public List<Comment> Comments { get; set; } = new List<Comment>();
    }
}