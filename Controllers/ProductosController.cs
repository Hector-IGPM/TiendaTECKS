using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TiendaOnline.Data;

namespace TiendaOnline.Controllers
{
    public class ProductosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProductosController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var productos = await _context.Productos
                .Include(p => p.Categoria)
                .Where(p => p.Activo)
                .ToListAsync();

            return View(productos);

        }
    }
}

