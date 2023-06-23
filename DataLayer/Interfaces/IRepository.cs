namespace DataLayer.Interfaces
{
    public interface IRepository<TEntity>
    {
        Task Create(TEntity entity);
        Task RemoveById(int id);
    }
}
