using DataLayer.Interfaces;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace DataLayer.Repositories
{
    public class BlogRepository : IRepository<Blog>
    {
        private readonly AppDbContext _context;

        public BlogRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<ICollection<Blog>> GetAll()
        {
            return await _context.Blogs
                .OrderBy(x => x.Title)
                .Include(x => x.Author)
                .Include(x => x.Reviews)
                .Include(x => x.BlogTags).ThenInclude(x => x.Tag)
                .ToListAsync();
        }
        public async Task<Blog> GetById(int id)
        {
            return await _context.Blogs
                .Include(x => x.Author)
                .Include(x => x.Reviews)
                .Include(x => x.BlogTags).ThenInclude(x => x.Tag)
                .Where(x => x.BlogId == id)
                .FirstOrDefaultAsync();
        }

        public bool Create(Blog blog)
        {
            _context.Blogs.Add(blog);
            return Seve();
        }
        public async Task RemoveById(int id)
        {
            var removedBlog = await _context.Blogs.FindAsync(id);
            _context.Blogs.Remove(removedBlog);
            await _context.SaveChangesAsync();
        }
        public async void Update(Blog entity)
        {
            _context.Blogs.Update(entity);
            await _context.SaveChangesAsync();
        }

        public bool Seve()
        {
            var seved = _context.SaveChanges();
            return seved > 0 ? true : false;
        }
    }
}
