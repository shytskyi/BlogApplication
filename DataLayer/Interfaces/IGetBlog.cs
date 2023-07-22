using Domain;

namespace DataLayer.Interfaces
{
    public interface IGetBlog
    {
        Task<ICollection<Blog>> GetBlogs();

    }
}
