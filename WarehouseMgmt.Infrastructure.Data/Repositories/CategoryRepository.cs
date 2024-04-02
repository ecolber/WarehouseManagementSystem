using WarehouseMgmt.Domain.Entities;
using WarehouseMgmt.Domain.Repositories;
using WarehouseMgmt.Infrastructure.Data.Data;

namespace WarehouseMgmt.Infrastructure.Data.Repositories
{
    public class CategoryRepository : GenericRepository<CategoryEntity>, ICategoryRepository
    {
        public CategoryRepository(DataContext context) : base(context)
        {
        }
    }
}
