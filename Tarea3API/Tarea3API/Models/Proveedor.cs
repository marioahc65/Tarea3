using System;
using System.Text.Json.Serialization;

namespace Tarea3API.Models
{
    public partial class Proveedor
    {
        public long ProveedorId { get; set; }
        public long CedJuridica { get; set; }
        public string Nombre { get; set; } = null!;
        public string Direccion { get; set; } = null!;
        public long Telefono { get; set; }

        [JsonIgnore]
        public virtual List<Producto>? Productos { get; set; }

    }
}
