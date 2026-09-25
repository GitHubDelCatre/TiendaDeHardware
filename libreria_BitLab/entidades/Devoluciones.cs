using System.ComponentModel.DataAnnotations.Schema;

namespace libreria_BitLab.entidades
{
    public class Devoluciones
    {
        public int Id { get; set; }
        public int IdVentas { get; set; }
        public int IdMetodoPagoReembolso { get; set; }
        public DateTime? FechaSolicitud { get; set; }
        public string? MotivoDevolucion { get; set; }
        public string? EstadoProceso { get; set; }
        [Column(TypeName = "decimal(10,2)")] public decimal? MontoReembolsado { get; set; }
        [ForeignKey("IdVentas")] public Ventas? _Venta { get; set; }
        [ForeignKey("IdMetodoPagoReembolso")] public Metodos_Pago? _MetodoPagoReembolso { get; set; }
    }
}