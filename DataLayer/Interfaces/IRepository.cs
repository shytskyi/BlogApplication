using Domain;

namespace DataLayer.Interfaces
{
    public interface IRepository<TEntity>
    {
        bool Create(TEntity entity);
        Task RemoveById(int id);
        void Update(TEntity entity);
        Task<ICollection<TEntity>> GetAll();
        Task<TEntity> GetById(int id);
        bool Seve();
    }
}
