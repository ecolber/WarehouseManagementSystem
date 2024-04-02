using WarehouseMgmt.Domain.Entities;
using WarehouseMgmt.Domain.Repositories;
using WarehouseMgmt.Infrastructure.Data.Data;

namespace WarehouseMgmt.Infrastructure.Data.Repositories
{
    public class ProductRepository : GenericRepository<ProductEntity>, IProductRepository
    {
        public ProductRepository(DataContext context) : base(context)
        {
        }
    }
}
