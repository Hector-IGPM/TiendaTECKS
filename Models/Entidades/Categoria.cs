using System.ComponentModel.DataAnnotations;

namespace TiendaOnline.Models.Entidades
{
    public class Categoria
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "El nombre de la categoría es obligatorio")]
        [StringLength(100)]
        public string Nombre { get; set; } = string.Empty;

        public List<Producto>  Productos { get; set; } = new List<Producto>();

    }
}
