using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using System.Xml.Linq;

namespace Tarea3UI.Models
{
    public partial class Producto
    {
        [Display(Name = "Id")]
        public long ProductoId { get; set; }
        [Display(Name = "Código")]
        public long Codigo { get; set; }
        public string Nombre { get; set; } = null!;
        [Display(Name = "Número de Lote")]
        public long NumeroLote { get; set; }
        public long Cantidad { get; set; }
        public long Precio { get; set; }

        [Display(Name = "Fecha de Ingreso")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        [DataType(DataType.Date)]
        public DateTime FechaIngreso { get; set; }

        [Display(Name = "Fecha de Fabricación")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime FechaFabricacion { get; set; }

        [Display(Name = "Fecha de Caducidad")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        [DataType(DataType.Date)]
        [Remote("ValidateFechaCaducidad", "Producto", ErrorMessage = "La fecha de caducidad debe ser mayor a la fecha de Hoy")]
        public DateTime FechaCaducidad { get; set; }
        public long ProveedorId { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public virtual Proveedor? Proveedor { get; set; }
    }
}
