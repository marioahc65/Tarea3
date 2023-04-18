using Microsoft.EntityFrameworkCore;
using Tarea3API.Data;
using Tarea3API.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



var connectionString = builder.Configuration.GetConnectionString("SQLServerConnection");
builder.Services.AddDbContext<ContextDb>(options => options.UseSqlServer(connectionString));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();




app.MapGet("Producto/NumeroLote/{NumeroLote:long}", async (long NumeroLote, ContextDb context) =>
{
    var productos = await context.Productos.Where(x => x.NumeroLote == NumeroLote).Include(x=> x.Proveedor).FirstOrDefaultAsync();
    if (productos == null)
    {
        return Results.NotFound();
    }
    return Results.Ok(productos);
});

app.MapGet("Producto/Codigo/{Codigo:long}", async (long Codigo, ContextDb context) =>
{
    var productos = await context.Productos.Where(x=> x.Codigo == Codigo).ToListAsync();
    if (productos == null)
    {
        return Results.NotFound();
    }
    return Results.Ok(productos);
});

app.MapGet("Producto/", async (ContextDb context) =>
{
    var productos = await context.Productos.Include(x=>x.Proveedor).ToListAsync();
    return Results.Ok(productos);
});

app.MapPost("Producto/", async (Producto producto, ContextDb context) =>
{
    try { 
    context.Productos.Add(producto);
    await context.SaveChangesAsync();
    return Results.Created($"/Producto/{producto.NumeroLote}", producto);
    }catch (Exception ex)
    {
        return Results.BadRequest(ex);
    }
});

app.MapPut("Producto/{ProductoId:long}", async (long ProductoId, Producto producto, ContextDb context) =>
{
    if (ProductoId != producto.ProductoId)
    {
        return Results.BadRequest();
    }
    var productoResult = await context.Productos.FindAsync(ProductoId);

    if (productoResult is null) return Results.NotFound();

    productoResult.Codigo = producto.Codigo;
    productoResult.Nombre = producto.Nombre;
    productoResult.NumeroLote = producto.NumeroLote;
    productoResult.Cantidad = producto.Cantidad;
    productoResult.Precio = producto.Precio;
    productoResult.FechaFabricacion = producto.FechaFabricacion;
    productoResult.FechaCaducidad = producto.FechaCaducidad;
    productoResult.ProveedorId = producto.ProveedorId;

    await context.SaveChangesAsync();

    return Results.Ok(productoResult);

});



app.MapGet("Proveedor/{ProveedorId:long}", async (long ProveedorId, ContextDb context) =>
{
    var proveedor = await context.Proveedores.FindAsync(ProveedorId);
    if (proveedor == null)
    {
        return Results.NotFound();
    }
    return Results.Ok(proveedor);
});

app.MapGet("Proveedor/", async (ContextDb context) =>
{
    var proveedores = await context.Proveedores.ToListAsync();
    return Results.Ok(proveedores);
});

app.MapPost("Proveedor/", async (Proveedor proveedor, ContextDb context) =>
{
    context.Proveedores.Add(proveedor);
    await context.SaveChangesAsync();
    return Results.Created($"/Proveedor/{proveedor.ProveedorId}", proveedor);
});

app.MapPut("Proveedor/{ProveedorId:long}", async (long ProveedorId, Proveedor proveedor, ContextDb context) =>
{
    if (ProveedorId != proveedor.ProveedorId)
    {
        return Results.BadRequest();
    }
    var proveedorResult = await context.Proveedores.FindAsync(ProveedorId);

    if (proveedorResult is null) return Results.NotFound();

    proveedorResult.CedJuridica = proveedor.CedJuridica;
    proveedorResult.Nombre = proveedor.Nombre;
    proveedorResult.Direccion = proveedor.Direccion;
    proveedorResult.Telefono = proveedor.Telefono;


    await context.SaveChangesAsync();

    return Results.Ok(proveedorResult);
});

app.Run();
