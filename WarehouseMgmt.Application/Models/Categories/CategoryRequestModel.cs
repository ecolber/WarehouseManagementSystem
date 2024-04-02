using System.ComponentModel.DataAnnotations;

namespace WarehouseMgmt.Application.Models.Categories
{
    public class CategoryRequestModel
    {
        [Required(ErrorMessage = "La descripcion es obligatoria")]
        public string Description { get; set; }
    }
}
