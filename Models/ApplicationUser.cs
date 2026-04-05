using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TiendaOnline.Models
{
    public class ApplicationUser : IdentityUser
    {
        [Required]
        [StringLength(100)]
        public string Nombres { get; set; } = string.Empty;

        [Required]
        [StringLength(100)]
        public string Apellidos { get; set; } = string.Empty;

        [StringLength(25)]
        public string? TelefonoContacto { get; set; }

        [StringLength(250)]
        public string? Direccion { get; set; }

        [NotMapped]
        public string PrimerNombre
        {
            get
            {
                if (string.IsNullOrWhiteSpace(Nombres))
                    return string.Empty;

                return Nombres.Trim().Split(' ', StringSplitOptions.RemoveEmptyEntries)[0];
            }
        }

        [NotMapped]
        public string NombreCompleto => $"{Nombres} {Apellidos}".Trim();
    }
}