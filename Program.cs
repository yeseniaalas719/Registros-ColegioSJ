using Microsoft.EntityFrameworkCore;
using Registros_ColegioSJ.Data;

var builder = WebApplication.CreateBuilder(args);


// CONTROLADORES Y VISTAS //

builder.Services.AddControllersWithViews();

// INYECCIÓN SQL //

builder.Services.AddDbContext<ColegioSJContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("ConexionSQLite")));

var app = builder.Build();

// REVISION O CREACION DE DB //

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    try
    {
        var context = services.GetRequiredService<ColegioSJContext>();
       
        context.Database.EnsureCreated();
    }
    catch (Exception ex)
    {
        var logger = services.GetRequiredService<ILogger<Program>>();
        logger.LogError(ex, "Ocurrió un error al crear la base de datos.");
    }
}

//CONFIGURACIÓN DEL PIPELINE DE HTTP //

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();