using Domain;
using DataLayer.Interfaces;
using ServiceLayer.Interfaces;
using ServiceLayer.DTO;
using static ServiceLayer.Enum.Enum;

namespace ServiceLayer.Services
{
    public class BlogService : IBlogService<Blog>, IService<Blog>
    {
        private readonly IBlogRepository<Blog> _blogRepository;
        private readonly IRepository<Blog> _repository;
        public BlogService(IBlogRepository<Blog> blogRepository, IRepository<Blog> repository )
        {
            _blogRepository = blogRepository;
            _repository = repository;
        }

        //public static IQueryable<BlogDTO> Page<T>(this IQueryable<BlogDTO> query, int pageNumZeroStart, int pageSize)
        //{
        //    if (pageSize == 0)
        //        throw new ArgumentOutOfRangeException
        //            (nameof(pageSize), "pageSize cannot be zero.");

        //    if (pageNumZeroStart != 0)
        //        query = query
        //            .Skip(pageNumZeroStart * pageSize);

        //    return query.Take(pageSize);
        //}

        public IQueryable<BlogDTO> OrderBlogBy(IQueryable<BlogDTO> blogs, FilterTypeToOrder orderByOptions)
        {
            switch (orderByOptions)
            {
                case FilterTypeToOrder.SimpleOrder:
                    return blogs.OrderByDescending(b => b.BlogId);
                case FilterTypeToOrder.ByVotes:
                    return blogs.OrderByDescending(b => b.ReviewsAverageStars);
                case FilterTypeToOrder.ByPublicationDate:
                    return blogs.OrderByDescending(b => b.PublishedOn);
                default:
                    throw new ArgumentOutOfRangeException(nameof(orderByOptions), orderByOptions, null);
            }
        }

        public IQueryable<BlogDTO> SelectBlogToDTO(IQueryable<Blog> blogs)
        {
            return blogs.Select(blog => new BlogDTO
            {
                BlogId = blog.BlogId,
                Title = blog.Title,
                PublishedOn = blog.PublishedOn,
                Author = blog.Author.FirstName + " " + blog.Author.LastName,
                content = blog.content,
                ReviewsAverageStars = blog.Reviews.Select(review => (double?)review.NumStars).Average(),
                ReviewsCount = blog.Reviews.Count(),
                TagStrings = blog.Tags.Select(t => t.TagId).ToArray()
            });
        }

        public IQueryable<BlogDTO> FilterBlogBy(IQueryable<BlogDTO> blogs, SortFilterBy filterBy, string filterValue)
        {
            if (string.IsNullOrEmpty(filterValue))
                return blogs;

            switch (filterBy)
            {
                case SortFilterBy.NoFilter:
                    return blogs;
                case SortFilterBy.ByAverageStars:
                    var filterVote = int.Parse(filterValue);
                    return blogs.Where(b => b.ReviewsAverageStars > filterVote);
                case SortFilterBy.ByTags:
                    return blogs.Where(b => b.TagStrings.Any(a => a == filterValue));
                case SortFilterBy.ByPublicationYear:
                    var filterYear = int.Parse(filterValue);
                    return blogs.Where(b => b.PublishedOn.Year == filterYear && b.PublishedOn <= DateTime.UtcNow);
                default:
                    throw new ArgumentOutOfRangeException(nameof(filterBy), filterBy, null);
            }
        }

        public Task<List<Blog>> GetAll()
        {
            return _blogRepository.GetAll();
        }
        public Task<Blog?> GetBlogById(int id)
        {
            return _blogRepository.GetBlogById(id);
        }
        public void Update(Blog blog)
        {
            _blogRepository.Update(blog);
        }
        public async Task Create(Blog blog)
        {
            await _repository.Create(blog);
        }
        public async Task RemoveById(int id)
        {
            await _repository.RemoveById(id);
        }
    }
}
