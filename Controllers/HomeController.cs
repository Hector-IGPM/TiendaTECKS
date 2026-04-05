using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System.Diagnostics;
using TiendaOnline.Models;
using TiendaOnline.Models.Entidades;

namespace TiendaOnline.Controllers
{
    public class HomeController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly SignInManager<ApplicationUser> _signInManager;

        // ✅ CONSTRUCTOR CORREGIDO (AQUÍ ESTABA EL ERROR)
        public HomeController(
            IConfiguration configuration,
            SignInManager<ApplicationUser> signInManager)
        {
            _configuration = configuration;
            _signInManager = signInManager;
        }

        public IActionResult Index()
        {
            var vm = new HomeViewModel();

            string? connectionString = _configuration.GetConnectionString("DefaultConnection");

            if (string.IsNullOrWhiteSpace(connectionString))
            {
                throw new Exception("La cadena de conexión 'DefaultConnection' no está configurada.");
            }

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                string query = @"
                    SELECT TOP 5
                        Id,
                        Nombre,
                        Descripcion,
                        Precio,
                        ImagenUrl,
                        Activo,
                        CategoriaId,
                        Stock
                    FROM Productos
                    WHERE Activo = 1
                    ORDER BY Id DESC;";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        vm.UltimosProductos.Add(new Producto
                        {
                            Id = Convert.ToInt32(dr["Id"]),
                            Nombre = dr["Nombre"]?.ToString() ?? "",
                            Descripcion = dr["Descripcion"] == DBNull.Value ? null : dr["Descripcion"].ToString(),
                            Precio = Convert.ToDecimal(dr["Precio"]),
                            ImagenUrl = dr["ImagenUrl"]?.ToString() ?? "",
                            Activo = Convert.ToBoolean(dr["Activo"]),
                            CategoriaId = Convert.ToInt32(dr["CategoriaId"]),
                            Stock = dr["Stock"] == DBNull.Value ? null : Convert.ToInt32(dr["Stock"])
                        });
                    }
                }
            }

            return View(vm);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        // ✅ LOGOUT FUNCIONANDO
        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel
            {
                RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
            });
        }
    }
}   