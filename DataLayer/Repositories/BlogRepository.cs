using DataLayer.Interfaces;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace DataLayer.Repositories
{
    public class BlogRepository : IBlogRepository<Blog>, IRepository<Blog>
    {
        private readonly AppDbContext _context;

        public BlogRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Blog>> GetAll()
        {
            return await _context.Blogs
                .Include(x => x.Author)
                .Include(x => x.Reviews)
                .Include(x => x.Tags)
                .ToListAsync();
        }
        public async Task<Blog> GetBlogById(int id)
        {
            return await _context.Blogs
                .Include(x => x.Author)
                .Include(x => x.Reviews)
                .Include(x => x.Tags)
                .FirstOrDefaultAsync(x => x.BlogId == id);
        }
        public async Task Create(Blog blog)
        {
            await _context.Blogs.AddAsync(blog);
            await _context.SaveChangesAsync();
        }
        public async Task RemoveById(int id)
        {
            var removedBlog = await _context.Blogs.FindAsync(id);
            _context.Blogs.Remove(removedBlog);
            await _context.SaveChangesAsync();
        }
        public async void Update(Blog blog)
        {
            _context.Blogs.Update(blog);
            await _context.SaveChangesAsync();
        }
    }
}
