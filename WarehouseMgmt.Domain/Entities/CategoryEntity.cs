﻿namespace WarehouseMgmt.Domain.Entities
{
    public class CategoryEntity : BaseEntity
    {
        public int Id { get; set; }
        public string Description  { get; set; }

        public ICollection<ProductEntity> Products { get; set; }
    }
}
