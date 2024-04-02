using System.ComponentModel.DataAnnotations;

namespace WarehouseMgmt.Application.Models.ProductsTypes
{
    public class ProductTypeRequestModel
    {
        [Required(ErrorMessage = "La descripcion es obligatoria")]
        public string Description { get; set; }
    }
}
