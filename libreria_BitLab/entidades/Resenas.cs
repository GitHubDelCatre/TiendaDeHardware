using System.ComponentModel.DataAnnotations.Schema;

namespace libreria_BitLab.entidades
{
    public class Resenas
    {
        public int Id { get; set; }
        public int IdProducto { get; set; }
        public int IdCliente { get; set; }
        public int CalificacionEstrellas { get; set; }
        public string? Comentario { get; set; }
        public DateTime FechaPublicacion { get; set; } = DateTime.Now;
        [ForeignKey("IdProducto")] public Productos? _Producto { get; set; }
        [ForeignKey("IdCliente")] public Clientes? _Cliente { get; set; }
    }
}