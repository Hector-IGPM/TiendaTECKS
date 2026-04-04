using TiendaOnline.Models.Entidades;

namespace TiendaOnline.Models
{
    public class HomeViewModel
    {
        public List<Producto> UltimosProductos { get; set; } = new List<Producto>();
    }
}
