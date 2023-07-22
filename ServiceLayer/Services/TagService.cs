using DataLayer.Interfaces;
using Domain;
using ServiceLayer.Interfaces;

namespace ServiceLayer.Services
{
    public class TagService : IService<Tag>, ITagService
    {
        private readonly IGetBlog _tegRepository;
        private readonly IRepository<Tag> _repository;
        public TagService(IGetBlog tegRepository, IRepository<Tag> repository)
        {
            _tegRepository = tegRepository;
            _repository = repository;
        }

        public bool Create(Tag tag)
        {
            var resp = _repository.Create(tag);
            return resp;
        }
        public async Task RemoveById(int id)
        {
            await _repository.RemoveById(id);
        }

        public void Update(Tag entity)
        {
            _repository.Update(entity);
        }

        public async Task<ICollection<Tag>> GetAll()
        {
            return _repository.GetAll().Result.ToList();
        }

        public async Task<Tag> GetById(int id)
        {
            return await _repository.GetById(id);
        }

        public IEnumerable<Blog> GetBlogByTag(string tag)
        {
            return _tegRepository.GetBlogs().Result.Where(bt => bt.BlogTags.Any(x => x.Tag.TagName == tag));
        }

        public bool Exists(int id)
        {
            if (_repository.GetById(id) == null)
                return false;
            return true;
        }
    }
}
