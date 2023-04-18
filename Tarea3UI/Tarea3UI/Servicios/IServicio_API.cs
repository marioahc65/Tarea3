using Tarea3UI.Models;

namespace Tarea3UI.Servicios
{
    public interface IServicio_API
    {
        Task<List<Producto>> GetProductos();
        Task<Producto> GetProductoByNumeroLote(long numeroLote);
        Task<Producto> GetProductoByCodigo(long codigo);
        Task<Producto> PostProducto(Producto objeto);
        Task<Producto> PutProducto(long productoId, Producto objeto);

        Task<List<Proveedor>> GetProveedores();
        Task<Proveedor> GetProvedor(long proveedorId);
        Task<Proveedor> PostProveedor(Proveedor objeto);
        Task<Proveedor> PutProveedor(long proveedorId, Proveedor objeto);


    }
}
