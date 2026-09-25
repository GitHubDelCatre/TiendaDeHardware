using System.ComponentModel.DataAnnotations.Schema;

namespace libreria_BitLab.entidades
{
    public class Inventarios
    {
        public int Id { get; set; }
        public int IdProducto { get; set; }
        public int IdSucursal { get; set; }
        public int CantidadDisponible { get; set; } = 0;
        public int StockMinimo { get; set; } = 0;
        public string? EstanteriaUbicacion { get; set; }
        public DateTime UltimaActualizacion { get; set; } = DateTime.Now;
        public int? CapacidadBodega { get; set; }
        [ForeignKey("IdProducto")] public Productos? _Producto { get; set; }
        [ForeignKey("IdSucursal")] public Sucursales? _Sucursal { get; set; }
    }
}