using Domain;

namespace ServiceLayer.Interfaces
{
    public interface ITagService
    {
        IEnumerable<Blog> GetBlogByTag(string tag);
    }
}
