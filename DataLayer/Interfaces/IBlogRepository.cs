namespace DataLayer.Interfaces
{
    public interface IBlogRepository<TEntity>
    {
        Task<List<TEntity>> GetAll(); //why list?
        Task<TEntity?> GetBlogById(int id);
        void Update(TEntity book);
    }
}
