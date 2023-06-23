using ServiceLayer.DTO;
using static ServiceLayer.Enum.Enum;

namespace ServiceLayer.Interfaces
{
    public interface IBlogService<TEntity>
    {
        Task<List<TEntity>> GetAll(); 
        Task<TEntity?> GetBlogById(int id);
        void Update(TEntity book);
        IQueryable<BlogDTO> SelectBlogToDTO(IQueryable<TEntity> blogs);
        IQueryable<BlogDTO> FilterBlogBy(IQueryable<BlogDTO> blogs, SortFilterBy filterBy, string filterValue);
        IQueryable<BlogDTO> OrderBlogBy(IQueryable<BlogDTO> blogs, FilterTypeToOrder orderByOptions);
        //public IQueryable<T> Page<T>(this IQueryable<T> query, int pageNumZeroStart, int pageSize);
    }
}
