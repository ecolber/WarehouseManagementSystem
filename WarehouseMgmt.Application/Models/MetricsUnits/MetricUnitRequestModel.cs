using System.ComponentModel.DataAnnotations;

namespace WarehouseMgmt.Application.Models.MetricsUnits
{
    public class MetricUnitRequestModel
    {
        [Required(ErrorMessage = "La descripcion es obligatoria")]
        public string Description { get; set; }
    }
}
