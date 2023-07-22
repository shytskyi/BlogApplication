using DataLayer.Interfaces;
using Domain;
using Microsoft.EntityFrameworkCore;
using System;
namespace DataLayer.Repositories
{
    public class TagRepository : IRepository<Tag>, IGetBlog
    {
        private readonly AppDbContext _context;

        public TagRepository(AppDbContext context)
        {
            _context = context;
        }

        public bool Create(Tag tag)
        {
            _context.Tags.AddAsync(tag);
            return Seve();
        }
        public async Task RemoveById(int id)
        {
            var remove = await _context.Tags.FindAsync(id);
            _context.Tags.Remove(remove);
            await _context.SaveChangesAsync();
        }
        public async void Update(Tag entity)
        {
            _context.Tags.Update(entity);
            await _context.SaveChangesAsync();
        }
        public async Task<ICollection<Tag>> GetAll()
        {
            return _context.Tags.ToList();
        }

        public async Task<Tag> GetById(int id)
        {
            return await _context.Tags
                .Where(x => x.TagId == id)
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
