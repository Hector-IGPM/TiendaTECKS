using Microsoft.AspNetCore.Identity; // Manejo de usuarios (login, registro)
using Microsoft.EntityFrameworkCore; // Entity Framework
using TiendaOnline.Data; // Tu DbContext

var builder = WebApplication.CreateBuilder(args);

// 🔗 Obtener cadena de conexión desde appsettings.json
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection")
    ?? throw new InvalidOperationException("No se encontró la cadena de conexión.");

// 🗄️ Configurar conexión a SQL Server
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));

// 🔧 Página de errores para base de datos (solo desarrollo)
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

// 🔐 Configurar sistema de login (Identity)
builder.Services.AddDefaultIdentity<IdentityUser>(options =>
    options.SignIn.RequireConfirmedAccount = false)
    .AddEntityFrameworkStores<ApplicationDbContext>();

// 🎯 Agregar soporte para MVC (controladores + vistas)
builder.Services.AddControllersWithViews();

var app = builder.Build();

// ⚙️ Configuración según entorno
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint(); // Permite usar migraciones en desarrollo
}
else
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection(); // Forzar HTTPS
app.UseRouting(); // Activar rutas

app.UseAuthentication(); // Activar login
app.UseAuthorization(); // Activar permisos

// 🛣️ Ruta principal
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapRazorPages(); // Necesario para Identity

app.Run(); // Ejecuta la app