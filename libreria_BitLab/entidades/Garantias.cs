using System.ComponentModel.DataAnnotations.Schema;

namespace libreria_BitLab.entidades
{
    public class Garantias
    {
        public int Id { get; set; }
        public int IdDetalleVenta { get; set; }
        public DateTime? FechaSolicitud { get; set; }
        public string? MotivoFalla { get; set; }
        public string? EstadoGarantia { get; set; }
        public string? ResolucionTecnica { get; set; }
        public DateTime? FechaCierre { get; set; }
        [ForeignKey("IdDetalleVenta")] public Detalle_Ventas? _DetalleVenta { get; set; }
    }
}