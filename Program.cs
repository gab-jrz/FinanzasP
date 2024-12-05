using FinanzasPersonales.Models;
using FinanzasPersonales.Mappings;
using FinanzasPersonales.Repositories;
using Microsoft.EntityFrameworkCore;



var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


// Add services to the container.
builder.Services.AddAutoMapper(typeof(GastoProfile));
builder.Services.AddScoped<IGastoRepository, GastoRepository>();

builder.Services.AddControllersWithViews();

//agregar Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "API v1");
        c.RoutePrefix = string.Empty; // Swagger en la raíz
    });
}


// Configuración de la aplicación
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts(); // Habilitar HSTS solo en producción
}

using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    try
    {
        // Prueba la conexión a la base de datos
        context.Database.CanConnect();
        Console.WriteLine("¡Conexión a la base de datos exitosa!");
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Error al conectar con la base de datos: {ex.Message}");
    }
}




// Configure the HTTP request pipeline.
/*if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}*/

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
