using DataLayer.Interfaces;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace DataLayer.Repositories
{
    public class AuthorRepository : IRepository<Author>, IGetBlog
    {
        private readonly AppDbContext _context;

        public AuthorRepository(AppDbContext context)
        {
            _context = context;
        }

        public bool Create(Author author)
        {
            _context.Authors.Add(author);
            return Seve();
        }
        public async Task RemoveById(int id)
        {
            var remove = await _context.Authors.FindAsync(id);
            _context.Authors.Remove(remove);
            await _context.SaveChangesAsync();
        }
        public async void Update(Author entity)
        {
            _context.Authors.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<ICollection<Author>> GetAll()
        {
            return await _context.Authors.ToListAsync();
        }
        public async Task<Author> GetById(int id)
        {
            return await _context.Authors
                .Where(x => x.AuthorId == id)
                .FirstOrDefaultAsync();
        }

        public async Task<ICollection<Blog>> GetBlogs()
        {
            return _context.Blogs.ToList();
        }

        public bool Seve()
        {
            var seved = _context.SaveChanges();
            return seved > 0 ? true : false;
        }
    }
}
