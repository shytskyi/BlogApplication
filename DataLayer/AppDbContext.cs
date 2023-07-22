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
        public DbSet<BlogTag> BlogTags { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) {}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Blog>()  // one-to-one
                .HasOne(a => a.Author)
                .WithOne(b => b.Blog)
                .HasForeignKey<Author>(a => a.AuthorId);

            modelBuilder.Entity<Review>()   //one-to-many
                .HasOne<Author>(a => a.Author)
                .WithMany(r => r.Reviews)
                .HasForeignKey(a => a.AuthorId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Review>()
                .HasOne<Blog>(a => a.Blog)
                .WithMany(r => r.Reviews)
                .HasForeignKey(a => a.BlogId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<BlogTag>()      //many-to-many
                .HasKey(bt => new { bt.BlogId, bt.TagId });
            modelBuilder.Entity<BlogTag>()
                .HasOne(b => b.Blog) 
                .WithMany(bt => bt.BlogTags)
                .HasForeignKey(b => b.BlogId);
            modelBuilder.Entity<BlogTag>()
                .HasOne(t => t.Tag)
                .WithMany(bt => bt.BlogTags)
                .HasForeignKey(t => t.TagId);

            //base.OnModelCreating(modelBuilder);
        }
    }
}
