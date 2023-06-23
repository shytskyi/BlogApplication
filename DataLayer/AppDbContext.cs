using Microsoft.EntityFrameworkCore;
using Domain;

namespace DataLayer
{
    public class AppDbContext : DbContext
    {
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Tag> Tags { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) 
        {
            Database.Migrate(); //?
        }
    }
}
