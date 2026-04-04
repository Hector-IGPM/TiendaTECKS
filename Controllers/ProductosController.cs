using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TiendaOnline.Data;
using TiendaOnline.Models.Entidades;

namespace TiendaOnline.Controllers
{
    public class ProductosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProductosController(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Detalle(int id)
        {
            var producto = await _context.Productos
                .Include(p => p.Categoria)
                .FirstOrDefaultAsync(p => p.Id == id && p.Activo);

            if (producto == null)
            {
                return NotFound();
            }

            return Content($"Detalle del producto: {producto.Nombre}");
        }
        public async Task<IActionResult> Index()
        {
            var productos = await _context.Productos
                .Where(p => p.Activo)
                .Include(p => p.Categoria)
                .ToListAsync();

            return View(productos);
        }
    }
}