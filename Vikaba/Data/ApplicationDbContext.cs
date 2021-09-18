using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Vikaba.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<Board> Boards { get; set; }

        public DbSet<BoardCategory> Categories { get; set; }

        public DbSet<BoardThread> Threads { get; set; }

        public DbSet<Comment> Comments { get; set; }

        public DbSet<News> News { get; set; }

        public DbSet<Tag> Tags { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
    }
}