using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Interfaces
{
    public interface IService<TEntity>
    {
        Task Create(TEntity entity);
        Task RemoveById(int id);
    }
}
