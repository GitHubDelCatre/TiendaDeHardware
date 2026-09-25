using System.ComponentModel.DataAnnotations.Schema;

namespace libreria_BitLab.entidades
{
    public class Ventas
    {
        public int Id { get; set; }
        public int IdCliente { get; set; }
        public int IdSucursal { get; set; }
        public int? IdPromocion { get; set; }
        public DateTime FechaVenta { get; set; } = DateTime.Now;
        public string? EstadoVenta { get; set; }
        [Column(TypeName = "decimal(10,2)")] public decimal? TotalPagar { get; set; }
        public string? DireccionEnvio { get; set; }
        [ForeignKey("IdCliente")] public Clientes? _Cliente { get; set; }
        [ForeignKey("IdSucursal")] public Sucursales? _Sucursal { get; set; }
        [ForeignKey("IdPromocion")] public Promociones? _Promocion { get; set; }
    }
}