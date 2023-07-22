using Domain;
using DataLayer.Interfaces;
using ServiceLayer.Interfaces;

namespace ServiceLayer.Services
{
    public class BlogService : IBlogService<Blog>, IService<Blog>
    {
        private readonly IRepository<Blog> _repository;
        public BlogService(IRepository<Blog> repository )
        {
            _repository = repository;
        }

        //void EditBlogContent(int id, string newContent)
        //{
        //    var x = _blogRepository.GetById(id).Result.content;
        //    x.Replace(x, newContent);

        //    _repository.Update();
        //}

        public ICollection<Blog> SortByTitle()
        {
            return _repository.GetAll().Result.OrderBy(b => b.Title).ToList();
        }

        public ICollection<Blog> SortByPublished()
        {
            return _repository.GetAll().Result.OrderBy(b => b.PublishedOn).ToList();
        }

        public ICollection<Blog> SortByAuthorName()
        {
            return _repository.GetAll().Result.OrderBy(b => b.Author.FirstName + " " + b.Author.LastName).ToList();
        }

        public bool Exists (int id)
        {
            if (_repository.GetById(id) == null)
                return false;
            return true; 
        }

        public decimal GetBlogRating(int id)
        {
            var rating = _repository.GetById(id);
            if (rating.Result.Reviews.Count() <= 0)
                return 0;
            return (decimal) rating.Result.Reviews.Sum(r => r.NumStars) / rating.Result.Reviews.Count();
        }

        public Task<ICollection<Blog>> GetAll()
        {
            return _repository.GetAll();
        }
        public Task<Blog> GetById(int id)
        {
            return _repository.GetById(id);
        }
        public void Update(Blog blog)
        {
            _repository.Update(blog);
        }

        public bool Create(Blog blog)
        {
            var resp = _repository.Create(blog);
            return resp;
        }
        public async Task RemoveById(int id)
        {
            await _repository.RemoveById(id);
        }   
    }
}
