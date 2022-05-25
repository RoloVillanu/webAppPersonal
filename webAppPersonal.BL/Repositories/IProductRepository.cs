using System.Threading.Tasks;
using webAppPersonal.BL.Models;

namespace webAppPersonal.BL.Repositories
{
    public interface IProductRepository : IGenericRepository<producto>
    {
        //Task<bool> DeleteCheckOnEntity(int id); // Verificar integridad referencial
    }
}
