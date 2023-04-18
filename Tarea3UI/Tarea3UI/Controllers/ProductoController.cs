using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;
using Tarea3UI.Models;
using Tarea3UI.Servicios;

namespace Tarea3UI.Controllers
{
    public class ProductoController : Controller
    {
        private readonly IServicio_API _servicio;

        public ProductoController(IServicio_API servicio)
        {
            _servicio = servicio;
        }
        // GET: Producto
        public async  Task<ActionResult> Index()
        {
            List<Producto> modelos = new List<Producto>();
            try
            {


                modelos = await _servicio.GetProductos();
                return View(modelos);


            }
            catch (Exception ex)
            {
                return View();
            }

            return View();
        }

        // GET: Producto/Details/5
        public async Task<ActionResult> Details(long id)
        {

            Producto modelo = new Producto();
            try
            {
                modelo = await _servicio.GetProductoByNumeroLote(id);
                return View(modelo);
            }
            catch (Exception ex)
            {
                return View(modelo);
            }
        }

        // GET: Producto/Create
        public async Task<ActionResult> Create()
        {
            List<Proveedor> proveedores = new List<Proveedor>();
            
            try
            {
                proveedores = await _servicio.GetProveedores();
                ViewBag.Proveedores = proveedores;
            }
            catch (Exception ex)
            {
                ViewBag.Proveedores = proveedores;
            }

            return View();
        }

        // POST: Producto/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(IFormCollection collection)
        {
            try
            {
                Producto producto = new Producto();

                producto.Nombre = collection["Nombre"];
                producto.Codigo = long.Parse(collection["Codigo"]);
                producto.NumeroLote = long.Parse(collection["NumeroLote"]);
                producto.Cantidad = long.Parse(collection["Cantidad"]);
                producto.Precio = long.Parse(collection["Precio"]);
                producto.FechaFabricacion = Convert.ToDateTime(collection["FechaFabricacion"]);
                producto.FechaIngreso = DateTime.Now;
                producto.FechaCaducidad = Convert.ToDateTime(collection["FechaCaducidad"]);
                producto.ProveedorId = long.Parse(collection["ProveedorId"]);

                producto = await _servicio.PostProducto(producto);

                return RedirectToAction(nameof(Index));
          
            }
            catch
            {
                return View();
            }
        }

        public JsonResult ValidateFechaCaducidad(DateTime FechaCaducidad)
        {
            var esValido = FechaCaducidad.CompareTo(DateTime.Now) > 0;
            return Json(esValido);
        }

        public ActionResult TipoBusqueda()
        {
            return View();
        }

        // GET: Producto/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            List<Proveedor> proveedores = new List<Proveedor>();
            Producto modelo = new Producto();
            try
            {
                modelo = await _servicio.GetProductoByNumeroLote(id);
                proveedores = await _servicio.GetProveedores();
                ViewBag.Proveedores = proveedores;
                return View(modelo);
            }
            catch (Exception ex)
            {
                ViewBag.Proveedores = proveedores;
                return View(modelo);
            }
        }

        // POST: Producto/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int ProductoId, IFormCollection collection)
        {
            Producto producto = new Producto();

            producto.ProductoId = long.Parse(collection["ProductoId"].ToString());
            producto.Nombre = collection["Nombre"];
            producto.Codigo = long.Parse(collection["Codigo"]);
            producto.NumeroLote = long.Parse(collection["NumeroLote"]);
            producto.Cantidad = long.Parse(collection["Cantidad"]);
            producto.Precio = long.Parse(collection["Precio"]);
            producto.FechaFabricacion = Convert.ToDateTime(collection["FechaFabricacion"]);
            producto.FechaCaducidad = Convert.ToDateTime(collection["FechaCaducidad"]);
            producto.ProveedorId = long.Parse(collection["ProveedorId"]);


            try
            {
                producto = await _servicio.PutProducto(ProductoId, producto);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Producto/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Producto/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
