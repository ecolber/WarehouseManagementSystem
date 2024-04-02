namespace WarehouseMgmt.Domain.Entities
{
    public class MetricUnitEntity : BaseEntity
    {
        public int Id { get; set; }
        public string Description { get; set; }

        public ICollection<ProductEntity> Products { get; set; }
    }
}
