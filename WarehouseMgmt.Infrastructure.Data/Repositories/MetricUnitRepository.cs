using WarehouseMgmt.Domain.Entities;
using WarehouseMgmt.Domain.Repositories;
using WarehouseMgmt.Infrastructure.Data.Data;

namespace WarehouseMgmt.Infrastructure.Data.Repositories
{
    public class MetricUnitRepository : GenericRepository<MetricUnitEntity>, IMetricUnitRepository
    {
        public MetricUnitRepository(DataContext context) : base(context)
        {
        }
    }
}
