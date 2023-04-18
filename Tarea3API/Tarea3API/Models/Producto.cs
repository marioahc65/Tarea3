using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Tarea3API.Models
{
    public partial class Producto
    {
        public long ProductoId { get; set; }
        public long Codigo { get; set; }
        public string Nombre { get; set; } = null!;
        public long NumeroLote { get; set; }
        public long Cantidad { get; set; }
        public long Precio { get; set; }
        public DateTime FechaIngreso { get; set; }
        public DateTime FechaFabricacion { get; set; }
        public DateTime FechaCaducidad { get; set; }
        public long ProveedorId { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public virtual Proveedor? Proveedor { get; set; }
    }
}
