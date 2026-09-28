using WebAppSignalR.Hubs;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
// 1. Agregar el servicio de SignalR
builder.Services.AddSignalR();

var app = builder.Build();

app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Account}/{action=Login}/{id?}");

// 2. Mapear el endpoint del Hub
app.MapHub<LoginHub>("/loginHub");

app.Run();