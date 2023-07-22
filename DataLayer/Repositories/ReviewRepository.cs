using DataLayer.Interfaces;
using Domain;
using Microsoft.EntityFrameworkCore;
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

        public bool Create(Review review)
        {
            _context.Reviews.AddAsync(review);
            return Seve();
        }
        public async Task RemoveById(int id)
        {
            var remove = await _context.Reviews.FindAsync(id);
            _context.Reviews.Remove(remove);
            await _context.SaveChangesAsync();
        }
        public async void Update(Review entity)
        {
            _context.Reviews.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<ICollection<Review>> GetAll()
        {
            return await _context.Reviews
                .ToListAsync();
        }
        public async Task<Review> GetById(int id)
        {
            return await _context.Reviews
                .Where(x => x.ReviewId == id)
                .FirstOrDefaultAsync();
        }

        public bool Seve()
        {
            var seved = _context.SaveChanges();
            return seved > 0 ? true : false;
        }
    }

}
