using Proyecto1MVC.Services;

/*Fundamentos de Programacion WEB 
 Proyecto #1
 Andrés Céspedes Siles
 Ced:3-0367-0974

 Referencias usadas en este proyecto

 Documento MVC https://aprende.uned.ac.cr/pluginfile.php/2476283/mod_label/intro/Gu%C3%ADa%20Mvc.pdf
 Video         https://aprende.uned.ac.cr/course/view.php?id=9103&section=1#tabs-tree-start
 Lara,Roger  I sesion Virtual https://www.youtube.com/watch?v=kVigSjlXogE
 Inteligencia Artificial en segmentos identificados en el proyecto y para crear los services y views
*/

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Servicios de cada uno de los registros
//builder.Services.AddSingleton<IEmpleadoServices, EmpleadoService>();//
builder.Services.AddSingleton<IClienteServices, ClienteService>();
builder.Services.AddSingleton<IEmpleadoService, EmpleadoService>();
builder.Services.AddSingleton<IHabitacionServices, HabitacionService>();
builder.Services.AddSingleton<IReservacionServices, ReservacionService>();


var app = builder.Build();

// Configuración de Formato fecha (Costa Rica → dd/MM/yyyy)
var cultureInfo = new System.Globalization.CultureInfo("es-CR");
System.Globalization.CultureInfo.DefaultThreadCurrentCulture = cultureInfo;
System.Globalization.CultureInfo.DefaultThreadCurrentUICulture = cultureInfo;    //esta parte utilize IA (chat GPT) para cambiar formato fecha

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}

app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "Emprendimiento de pareja en Guanacaste",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();

app.Run();
