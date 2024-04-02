using System.ComponentModel.DataAnnotations;
using WarehouseMgmt.Domain.Entities;

namespace WarehouseMgmt.Application.Models.Products
{
    public class ProductRequestModel
    {
        [Required(ErrorMessage = "El nombre es obligatorio")]
        public string Name { get; set; }
        [Required(ErrorMessage = "La descripcion es obligatoria")]
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string SKU { get; set; }
        public int Stock { get; set; }

        [Required(ErrorMessage = "La categoria es obligatoria")]
        public int categoryId { get; set; }

        [Required(ErrorMessage = "El tipo de producto es obligatorio")]
        public int productTypeId { get; set; }

        [Required(ErrorMessage = "La unidad de medida es obligatoria")]
        public int metricUnitId { get; set; }
    }
}
