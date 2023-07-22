using DataLayer.Interfaces;
using Domain;
using ServiceLayer.Interfaces;

namespace ServiceLayer.Services
{
    public class AuthorService : IService<Author>, IAuthorService
    {
        private readonly IGetBlog _authorRepository;
        private readonly IRepository<Author> _repository;
        public AuthorService(IGetBlog authorRepository, IRepository<Author> repository)
        {
            _authorRepository = authorRepository;
            _repository = repository;
        }

        public bool Create(Author author)
        {
            var resp = _repository.Create(author);
            return resp;
        }

        public async Task RemoveById(int id)
        {
            await _repository.RemoveById(id);
        }

        public void Update(Author entity)
        {
            _repository.Update(entity);
        }

        public Blog? GetBlogByAuthorName(string name)
        {
            return _authorRepository.GetBlogs().Result.Where(bn => bn.Author.FirstName + " " + bn.Author.LastName == name).FirstOrDefault();
        }

        public Task<ICollection<Author>> GetAll()
        {
            return _repository.GetAll();
        }

        public Task<Author> GetById(int id)
        {
            return _repository.GetById(id);
        }

        public bool Exists(int id)
        {
            if (_repository.GetById(id) == null)
                return false;
            return true;
        }
    }
}
