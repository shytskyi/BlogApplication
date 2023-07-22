using Domain;

namespace ServiceLayer.Interfaces
{
    public interface IService<TEntity>
    {
        bool Create(TEntity entity);
        Task RemoveById(int id);
        void Update(TEntity entity);
        Task<ICollection<TEntity>> GetAll();
        Task<TEntity> GetById(int id);
        bool Exists(int id);
    }
}
