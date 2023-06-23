using DataLayer.Interfaces;
using Domain;
using ServiceLayer.Interfaces;

namespace ServiceLayer.Services
{
    public class AuthorService : IService<Author>
    {
        private readonly IRepository<Author> _repository;
        public AuthorService(IRepository<Author> repository)
        {
            _repository = repository;
        }
        public async Task Create(Author author)
        {
            await _repository.Create(author);
        }
        public async Task RemoveById(int id)
        {
            await _repository.RemoveById(id);
        }
    }
}
