using System.Threading.Tasks;
using webAppPersonal.BL.Models;

namespace webAppPersonal.BL.Repositories
{
    public interface IPersonRepository: IGenericRepository<persona>
    {
        //Task<bool> DeleteCheckOnEntity(int id); // Verificar integridad referencial
    }
}
