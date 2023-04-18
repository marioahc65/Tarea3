using Newtonsoft.Json;
using System.Text;
using Tarea3UI.Models;

namespace Tarea3UI.Servicios
{
    public class Servicio_API : IServicio_API
    {
        private static string _baseUrl;

        public Servicio_API()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();

            _baseUrl = builder.GetSection("ApiSettings:baseUrl").Value;
        }
        public async Task<Producto> GetProductoByCodigo(long codigo)
        {
            Producto producto = new Producto();
            var cliente = new HttpClient();
            cliente.BaseAddress = new Uri(_baseUrl);
            var response = await cliente.GetAsync("Producto/Codigo/" + codigo);

            if(response.IsSuccessStatusCode)
            {
                var json_respuesta = await response.Content.ReadAsStringAsync();
                var resultado = JsonConvert.DeserializeObject<Producto>(json_respuesta);
                producto = resultado;
            }

            return producto;
        }

        public async Task<Producto> GetProductoByNumeroLote(long numeroLote)
        {
            Producto producto = new Producto();
            var cliente = new HttpClient();
            cliente.BaseAddress = new Uri(_baseUrl);
            var response = await cliente.GetAsync("Producto/NumeroLote/" + numeroLote);

            if (response.IsSuccessStatusCode)
            {
                var json_respuesta = await response.Content.ReadAsStringAsync();
                var resultado = JsonConvert.DeserializeObject<Producto>(json_respuesta);
                producto = resultado;
            }

            return producto;
        }

        public async Task<List<Producto>> GetProductos()
        {
            List<Producto> productos = new List<Producto>();

            var cliente = new HttpClient();
            cliente.BaseAddress = new Uri(_baseUrl);
            var response = await cliente.GetAsync("Producto/");

            if (response.IsSuccessStatusCode)
            {
                var json_respuesta = await response.Content.ReadAsStringAsync();
                var resultado = JsonConvert.DeserializeObject<List<Producto>>(json_respuesta);
                productos = resultado.ToList();
            }

            return productos;
        }

        public async Task<Proveedor> GetProvedor(long proveedorId)
        {
            Proveedor proveedor = new Proveedor();
            var cliente = new HttpClient();
            cliente.BaseAddress = new Uri(_baseUrl);
            var response = await cliente.GetAsync("Proveedor/" + proveedorId);

            if (response.IsSuccessStatusCode)
            {
                var json_respuesta = await response.Content.ReadAsStringAsync();
                var resultado = JsonConvert.DeserializeObject<Proveedor>(json_respuesta);
                proveedor = resultado;
            }

            return proveedor;
        }

        public async Task<List<Proveedor>> GetProveedores()
        {
            List<Proveedor> proveedores = new List<Proveedor>();

            var cliente = new HttpClient();
            cliente.BaseAddress = new Uri(_baseUrl);
            var response = await cliente.GetAsync("Proveedor/");

            if (response.IsSuccessStatusCode)
            {
                var json_respuesta = await response.Content.ReadAsStringAsync();
                var resultado = JsonConvert.DeserializeObject<List<Proveedor>>(json_respuesta);
                proveedores = resultado.ToList();
            }

            return proveedores;
        }

        public async Task<Producto> PostProducto(Producto objeto)
        {
            Producto producto = new Producto();
            var cliente = new HttpClient();
            cliente.BaseAddress = new Uri(_baseUrl);

            var content = new StringContent(JsonConvert.SerializeObject(objeto), Encoding.UTF8, "application/json");

            var response = await cliente.PostAsync("Producto/", content);

            if (response.IsSuccessStatusCode)
            {
                var json_respuesta = await response.Content.ReadAsStringAsync();
                var resultado = JsonConvert.DeserializeObject<Producto>(json_respuesta);
                producto = resultado;
            }

            return producto;

        }

        public async Task<Proveedor> PostProveedor(Proveedor objeto)
        {
            Proveedor proveedor = new Proveedor();
            var cliente = new HttpClient();
            cliente.BaseAddress = new Uri(_baseUrl);

            var content = new StringContent(JsonConvert.SerializeObject(objeto), Encoding.UTF8, "application/json");

            var response = await cliente.PostAsync("Proveedor/", content);

            if (response.IsSuccessStatusCode)
            {
                var json_respuesta = await response.Content.ReadAsStringAsync();
                var resultado = JsonConvert.DeserializeObject<Proveedor>(json_respuesta);
                proveedor = resultado;
            }

            return proveedor;

        }

        public async Task<Producto> PutProducto(long productoId, Producto objeto)
        {
            Producto producto = new Producto();
            var cliente = new HttpClient();
            cliente.BaseAddress = new Uri(_baseUrl);

            var content = new StringContent(JsonConvert.SerializeObject(objeto), Encoding.UTF8, "application/json");

            var response = await cliente.PutAsync($"Producto/{productoId}", content);

            if(response.IsSuccessStatusCode)
            {
                var json_respuesta = await response.Content.ReadAsStringAsync();
                var resultado = JsonConvert.DeserializeObject<Producto>(json_respuesta);
                producto = resultado;
            }

            return producto;
        }

        public async Task<Proveedor> PutProveedor(long proveedorId, Proveedor objeto)
        {
            Proveedor proveedor = new Proveedor();
            var cliente = new HttpClient();
            cliente.BaseAddress = new Uri(_baseUrl);

            var content = new StringContent(JsonConvert.SerializeObject(objeto), Encoding.UTF8, "application/json");

            var response = await cliente.PutAsync($"Proveedor/{proveedorId}", content);

            if (response.IsSuccessStatusCode)
            {
                var json_respuesta = await response.Content.ReadAsStringAsync();
                var resultado = JsonConvert.DeserializeObject<Proveedor>(json_respuesta);
                proveedor = resultado;
            }

            return proveedor;
        }
    }

}
