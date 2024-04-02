using WarehouseMgmt.Domain.Entities;
using WarehouseMgmt.Domain.Repositories;
using WarehouseMgmt.Infrastructure.Data.Data;

namespace WarehouseMgmt.Infrastructure.Data.Repositories
{
    public class ProductTypeRepository : GenericRepository<ProductTypeEntity>, IProductTypeRepository
    {
        public ProductTypeRepository(DataContext context) : base(context)
        {
        }
    }
}
