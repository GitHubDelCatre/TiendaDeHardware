using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace libreria_BitLab.entidades
{
    [Index(nameof(IdUsuario), IsUnique = true)]
    public class Empleados
    {
        public int Id { get; set; }
        public int IdUsuario { get; set; }
        public int IdSucursal { get; set; }
        public string? CargoPuesto { get; set; }
        [Column(TypeName = "decimal(10,2)")] public decimal? Salario { get; set; }
        public DateTime? FechaContratacion { get; set; }
        [ForeignKey("IdUsuario")] public Usuarios? _Usuario { get; set; }
        [ForeignKey("IdSucursal")] public Sucursales? _Sucursal { get; set; }
    }
}