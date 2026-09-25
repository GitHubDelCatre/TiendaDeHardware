using System.ComponentModel.DataAnnotations.Schema;

namespace libreria_BitLab.entidades
{
    public class Pagos
    {
        public int Id { get; set; }
        public int IdVenta { get; set; }
        public int IdMetodoPago { get; set; }
        [Column(TypeName = "decimal(10,2)")] public decimal MontoPagado { get; set; }
        public DateTime FechaPago { get; set; } = DateTime.Now;
        public string? EstadoTransaccion { get; set; }
        public string? ReferenciaPasarela { get; set; }
        [ForeignKey("IdVenta")] public Ventas? _Venta { get; set; }
        [ForeignKey("IdMetodoPago")] public Metodos_Pago? _MetodoPago { get; set; }
    }
}