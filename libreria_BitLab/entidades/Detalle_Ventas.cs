using System.ComponentModel.DataAnnotations.Schema;

namespace libreria_BitLab.entidades
{
    public class Detalle_Ventas
    {
        public int Id { get; set; }
        public int IdVenta { get; set; }
        public int IdProducto { get; set; }
        public int Cantidad { get; set; }
        [Column(TypeName = "decimal(10,2)")] public decimal PrecioUnitarioVenta { get; set; }
        [Column(TypeName = "decimal(10,2)")] public decimal DescuentoAplicado { get; set; } = 0;
        [Column(TypeName = "decimal(10,2)")] public decimal? Subtotal { get; set; }
        [ForeignKey("IdVenta")] public Ventas? _Venta { get; set; }
        [ForeignKey("IdProducto")] public Productos? _Producto { get; set; }
    }
}