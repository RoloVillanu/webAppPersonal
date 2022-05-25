using System.Threading.Tasks;
using webAppPersonal.BL.Data;
using webAppPersonal.BL.Models;

namespace webAppPersonal.BL.Repositories.Implements
{
    public class ProductRepository : GenericRepository<producto>, IProductRepository
    {
        private webAppPersonalContext webappPersonalContext;
        public ProductRepository(webAppPersonalContext webappPersonalContext) : base(webappPersonalContext)
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
