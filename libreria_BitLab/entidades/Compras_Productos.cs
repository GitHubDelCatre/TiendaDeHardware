using System.ComponentModel.DataAnnotations.Schema;

namespace libreria_BitLab.entidades
{
    public class Compras_Productos
    {
        public int Id { get; set; }
        public int IdProveedor { get; set; }
        public int IdSucursal { get; set; }
        public DateTime FechaOrden { get; set; } = DateTime.Now;
        public string? EstadoOrden { get; set; }
        [Column(TypeName = "decimal(10,2)")] public decimal? TotalEstimado { get; set; }
        public string? NotasInternas { get; set; }
        [ForeignKey("IdProveedor")] public Proveedores? _Proveedor { get; set; }
        [ForeignKey("IdSucursal")] public Sucursales? _Sucursal { get; set; }
    }
}