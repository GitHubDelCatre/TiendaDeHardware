using System.ComponentModel.DataAnnotations.Schema;

namespace libreria_BitLab.entidades
{
    public class Envios
    {
        public int Id { get; set; }
        public int IdVenta { get; set; }
        public int IdEmpresaPaqueteria { get; set; }
        public string? NumeroGuia { get; set; }
        public string? EstadoEnvio { get; set; }
        public DateTime? FechaEstimadaEntrega { get; set; }
        public DateTime? FechaEntregaReal { get; set; }
        [Column(TypeName = "decimal(10,2)")] public decimal? CostoEnvio { get; set; }
        [ForeignKey("IdVenta")] public Ventas? _Venta { get; set; }
        [ForeignKey("IdEmpresaPaqueteria")] public EmpresaPaqueteria? _EmpresaPaqueteria { get; set; }
    }
}