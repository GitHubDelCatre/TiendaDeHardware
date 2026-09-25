using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace libreria_BitLab.entidades
{
    [Index(nameof(IdUsuario), IsUnique = true)]
    public class Clientes
    {
        public int Id { get; set; }
        public int IdUsuario { get; set; }
        public string NombreCompleto { get; set; } = string.Empty;
        public string? Telefono { get; set; }
        public string? DireccionPrincipal { get; set; }
        public DateTime? FechaNacimiento { get; set; }
        [ForeignKey("IdUsuario")] public Usuarios? _Usuario { get; set; }
    }
}