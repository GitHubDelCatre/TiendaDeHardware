using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace libreria_BitLab.entidades
{
    [Index(nameof(CodigoCupon), IsUnique = true)]
    public class Promociones
    {
        public int Id { get; set; }
        public string CodigoCupon { get; set; } = string.Empty;
        public string? Descripcion { get; set; }
        [Column(TypeName = "decimal(5,2)")] public decimal? PorcentajeDescuento { get; set; }
        public DateTime? FechaInicio { get; set; }
        public DateTime? FechaFin { get; set; }
        public bool EstadoActiva { get; set; } = true;
    }
}