using WarehouseMgmt.Application.Models.Categories;
using WarehouseMgmt.Application.Models.MetricsUnits;
using WarehouseMgmt.Application.Models.ProductsTypes;

namespace WarehouseMgmt.Application.Models.Products
{
    public class ProductResponseModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string SKU { get; set; }
        public int Stock { get; set; }

        public int CategoryId { get; set; }

        public int productTypeId { get; set; }

        public int metricUnitId { get; set; }
    }
}
