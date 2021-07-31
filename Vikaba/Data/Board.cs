using System.Collections.Generic;

namespace Vikaba.Data
{
    public class Board
    {
        public int Id { get; set; }

        public string Link { get; set; } = "";

        public string Title { get; set; } = "";

        public int CategoryId { get; set; }
        public BoardCategory Category { get; set; } = null!;

        public List<BoardThread> BoardThreads { get; set; } = new List<BoardThread>();
    }
}