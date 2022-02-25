using System.Threading.Tasks;
using webAppPersonal.BL.Data;
using webAppPersonal.BL.Models;

namespace webAppPersonal.BL.Repositories.Implements
{
    public class PersonRepository: GenericRepository<persona>, IPersonRepository
    {
        private webAppPersonalContext webappPersonalContext;
        public PersonRepository(webAppPersonalContext webappPersonalContext): base(webappPersonalContext)
        {
            //this.webappPersonalContext = webappPersonalContext;
        }

        /*
        public async Task<bool> DeleteCheckOnEntity(int id)
        {
            var flag = webappPersonalContext
        }*/
    }
}
