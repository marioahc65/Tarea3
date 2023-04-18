using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Tarea3UI.Models;
using Tarea3UI.Servicios;

namespace Tarea3UI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IServicio_API _servicioApi;

        public HomeController(ILogger<HomeController> logger, IServicio_API servicioApi)
        {
            _servicioApi = servicioApi;
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}