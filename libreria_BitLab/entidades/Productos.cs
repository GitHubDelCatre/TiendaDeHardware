using System.ComponentModel.DataAnnotations.Schema;

namespace libreria_BitLab.entidades
{
    public class Productos
    {
        public int Id { get; set; }
        public int IdMarca { get; set; }
        public string NombreProducto { get; set; } = string.Empty;
        public string? DescripcionLarga { get; set; }
        [Column(TypeName = "decimal(10,2)")] public decimal PrecioVenta { get; set; }
        public string? NumeroSerie { get; set; }
        public string? Modelo { get; set; }
        public string? EspecificacionesTecnicas { get; set; }
        [ForeignKey("IdMarca")] public Marcas? _Marca { get; set; }
    }
}