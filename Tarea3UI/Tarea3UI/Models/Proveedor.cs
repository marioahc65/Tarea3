using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using System.Xml.Linq;

namespace Tarea3UI.Models
{
    public partial class Proveedor
    {
        [Display(Name = "Id")]
        public long ProveedorId { get; set; }
        [Display(Name = "Cédula Jurídica")]
        public long CedJuridica { get; set; }
        public string Nombre { get; set; } = null!;
        public string Direccion { get; set; } = null!;
        public long Telefono { get; set; }

        [JsonIgnore]
        public virtual Producto? Producto { get; set; }

    }
}
