namespace WarehouseMgmt.Domain.Entities
{
    public class ProductEntity : BaseEntity
    {
        
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string SKU { get; set; }
        public int Stock { get; set; }

        public virtual CategoryEntity Category { get; set; }
        public int categoryId { get; set; }

        public virtual ProductTypeEntity productType { get; set; }
        public int productTypeId { get; set; }

        public virtual MetricUnitEntity metricUnit { get; set; }
        public int metricUnitId { get; set; }
    }
}
