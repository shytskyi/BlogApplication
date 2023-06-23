using DataLayer.Interfaces;
using Domain;
using System;
namespace DataLayer.Repositories
{
    public class TagRepository : IRepository<Tag>
    {
        private readonly AppDbContext _context;

        public TagRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task Create(Tag tag)
        {
            await _context.Tags.AddAsync(tag);
            await _context.SaveChangesAsync();
        }
        public async Task RemoveById(int id)
        {
            var remove = await _context.Tags.FindAsync(id);
            _context.Tags.Remove(remove);
            await _context.SaveChangesAsync();
        }
    }

}
