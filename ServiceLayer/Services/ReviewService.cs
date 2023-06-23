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
        public async Task Create(Review review)
        {
            await _repository.Create(review);
        }
        public async Task RemoveById(int id)
        {
            await _repository.RemoveById(id);
        }
    }
}
