using System.Collections.Generic;
using System.Threading.Tasks;

namespace webAppPersonal.BL.Repositories
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        // Metodos asincronos
        Task<IEnumerable<TEntity>> GetAll();
        Task<TEntity> GetById(int id);
        Task<TEntity> Insert(TEntity entity);
        Task<TEntity> Update(TEntity entity);
        Task Delete(int id);
    }
}
