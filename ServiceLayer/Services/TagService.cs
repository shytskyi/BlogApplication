using DataLayer.Interfaces;
using Domain;
using ServiceLayer.Interfaces;

namespace ServiceLayer.Services
{
    public class TagService : IService<Tag>
    {
        private readonly IRepository<Tag> _repository;
        public TagService(IRepository<Tag> repository)
        {
            _repository = repository;
        }
        public async Task Create(Tag tag)
        {
            await _repository.Create(tag);
        }
        public async Task RemoveById(int id)
        {
            await _repository.RemoveById(id);
        }
    }

}
