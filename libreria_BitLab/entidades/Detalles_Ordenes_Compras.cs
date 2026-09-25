using System.ComponentModel.DataAnnotations.Schema;

namespace libreria_BitLab.entidades
{
    public class Detalles_Ordenes_Compras
    {
        public int Id { get; set; }
        public int IdComprasProducto { get; set; }
        public int IdProducto { get; set; }
        public int CantidadSolicitada { get; set; }
        [Column(TypeName = "decimal(10,2)")] public decimal CostoUnitario { get; set; }
        [Column(TypeName = "decimal(10,2)")] public decimal? SubtotalCosto { get; set; }
        [ForeignKey("IdComprasProducto")] public Compras_Productos? _ComprasProducto { get; set; }
        [ForeignKey("IdProducto")] public Productos? _Producto { get; set; }
    }
}