using Domain;
using ServiceLayer.DTO;

namespace ServiceLayer.Interfaces
{
    public interface IAuthorService
    {
        Blog? GetBlogByAuthorName(string name);
    }
}
