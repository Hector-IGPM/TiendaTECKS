using Microsoft.AspNetCore.Identity.EntityFrameworkCore; 
using Microsoft.EntityFrameworkCore; 
using TiendaOnline.Models.Entidades;
using TiendaOnline.Models;

namespace TiendaOnline.Data 
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Producto> Productos { get; set; }

        public DbSet<Categoria> Categorias { get; set; }
    }
}