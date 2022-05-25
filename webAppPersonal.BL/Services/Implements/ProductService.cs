using webAppPersonal.BL.Models;
using webAppPersonal.BL.Repositories;

namespace webAppPersonal.BL.Services.Implements
{
    public class ProductService : GenericService<producto>, IProductService
    {
        public ProductService(IProductRepository productRepository) : base(productRepository)
        {


        }
    }
}
