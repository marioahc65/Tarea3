using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tarea3UI.Models;
using Tarea3UI.Servicios;

namespace Tarea3UI.Controllers
{
    public class ProveedorController : Controller
    {
        private readonly IServicio_API _servicio;

        public ProveedorController(IServicio_API servicio)
        {
            _servicio = servicio;
        }
        // GET: Proveedor
        public async Task<ActionResult> Index()
        {
            List<Proveedor> modelos = new List<Proveedor>();
            try { 


            modelos = await _servicio.GetProveedores();
            return View(modelos);


            } catch (Exception ex)
            {
                return View();
            }

        }

        // GET: Proveedor/Details/5
        public async Task<ActionResult> Details(long id)
        {
            Proveedor modelo = new Proveedor();
            try
            {
                modelo = await _servicio.GetProvedor(id);
                return View(modelo);
            }
            catch (Exception ex)
            {
                return View(modelo);
            }
        }

        // GET: Proveedor/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Proveedor/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(IFormCollection collection)
        {
            try
            {
                Proveedor proveedor = new Proveedor();

                proveedor.CedJuridica = long.Parse(collection["CedJuridica"]);
                proveedor.Nombre = collection["Nombre"];
                proveedor.Direccion = collection["Direccion"];
                proveedor.Telefono = long.Parse(collection["Telefono"]);

                proveedor = await _servicio.PostProveedor(proveedor);

                return RedirectToAction(nameof(Index));

            }
            catch
            {
                return View();
            }
        }

        // GET: Proveedor/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Proveedor/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
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

        // GET: Proveedor/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Proveedor/Delete/5
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
