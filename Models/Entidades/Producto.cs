using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TiendaOnline.Models.Entidades
{
    public class Producto
    {

        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre del producto es obligatorio")]
        [StringLength(100)]
        public string Nombre { get; set; } = string.Empty;

        [StringLength(500)]
        public string? Descripcion { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Precio { get; set; }

        [Required]
        public string? ImagenUrl { get; set; }

        public  bool Activo { get; set; } = true;

        [Required]
        public int CategoriaId { get; set; }

        public Categoria? Categoria { get; set; }

    }
}
