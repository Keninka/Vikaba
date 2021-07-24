using System;

namespace Vikaba.Data
{
    public class Comment
    {
        public int Id { get; set; }

        public string UserName { get; set; } = "";

        public string UserText { get; set; } = "";

        public DateTime CreatedAt { get; set; }

        public int ThreadId { get; set; }
        public BoardThread Thread { get; set; } = null!;
    }
}