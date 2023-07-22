using DataLayer.Interfaces;
using Domain;
using ServiceLayer.Interfaces;

namespace ServiceLayer.Services
{
    public class ReviewService : IService<Review>
    {
        private readonly IRepository<Review> _repository;
        public ReviewService(IRepository<Review> repository)
        {
            _repository = repository;
        }

        public bool Create(Review review)
        {
            var resp = _repository.Create(review);
            return resp;
        }

        public async Task RemoveById(int id)
        {
            await _repository.RemoveById(id);
        }

        public void Update(Review entity)
        {
            _repository.Update(entity);
        }

        public Task<ICollection<Review>> GetAll()
        {
            return _repository.GetAll();
        }

        public Task<Review> GetById(int id)
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
