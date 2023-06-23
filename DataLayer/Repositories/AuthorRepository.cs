using DataLayer.Interfaces;
using Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Repositories
{
    public class AuthorRepository : IRepository<Author>
    {
        private readonly AppDbContext _context;

        public AuthorRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task Create(Author author)
        {
            await _context.Authors.AddAsync(author);
            await _context.SaveChangesAsync();
        }
        public async Task RemoveById(int id)
        {
            var remove = await _context.Authors.FindAsync(id);
            _context.Authors.Remove(remove);
            await _context.SaveChangesAsync();
        }
    }
}
