using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Vikaba.Data
{
    public class Board
    {
        public int Id { get; set; }
        
        public string Link { get; set; } = "";

        public string Title { get; set; } = "";

        public int CategoryId { get; set; }
        public BoardCategory Category { get; set; } = null!;
    }
}