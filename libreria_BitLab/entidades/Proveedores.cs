using Microsoft.EntityFrameworkCore;

namespace libreria_BitLab.entidades
{
    [Index(nameof(NitEmpresa), IsUnique = true)]
    public class Proveedores
    {
        public int Id { get; set; }
        public string NombreEmpresa { get; set; } = string.Empty;
        public string NitEmpresa { get; set; } = string.Empty;
        public string? NombreContacto { get; set; }
        public string? TelefonoPrincipal { get; set; }
        public string? CorreoVentas { get; set; }
        public string? DireccionFisica { get; set; }
    }
}