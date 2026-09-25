using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace libreria_BitLab.entidades
{
    [Index(nameof(Cedula), IsUnique = true)]
    [Index(nameof(Correo), IsUnique = true)]
    public class Usuarios
    {
        public int Id { get; set; }
        public int IdRol { get; set; }
        public string NombreCompleto { get; set; } = string.Empty;
        public string Cedula { get; set; } = string.Empty;
        public string Correo { get; set; } = string.Empty;
        public string Contrasena { get; set; } = string.Empty;
        public DateTime FechaRegistro { get; set; } = DateTime.Now;
        public bool CuentaActiva { get; set; } = true;
        [ForeignKey("IdRol")] public Roles? _Rol { get; set; }
    }
}