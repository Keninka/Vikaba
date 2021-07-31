using System.Collections.Generic;

namespace Vikaba.Data.Database
{
    public static class Boards
    {
        public static readonly IDictionary<string, Board> BoardMap = new Dictionary<string, Board>
        {
            {"b", new Board {Id = 1, Link = "b"}},
            {"c", new Board {Id = 2, Link = "c"}},
            {"vg", new Board {Id = 3, Link = "vg"}},
            {"a", new Board {Id = 4, Link = "a"}},
        };
    }
}