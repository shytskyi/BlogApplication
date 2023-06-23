using DataLayer.Interfaces;
using Domain;
using System;
namespace DataLayer.Repositories
{
    public class ReviewRepository : IRepository<Review>
    {
        private readonly AppDbContext _context;

        public ReviewRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task Create(Review review)
        {
            await _context.Reviews.AddAsync(review);
            await _context.SaveChangesAsync();
        }
        public async Task RemoveById(int id)
        {
            var remove = await _context.Reviews.FindAsync(id);
            _context.Reviews.Remove(remove);
            await _context.SaveChangesAsync();
        }
    }

}
