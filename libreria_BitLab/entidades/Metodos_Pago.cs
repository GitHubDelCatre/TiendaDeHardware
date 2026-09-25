namespace libreria_BitLab.entidades
{
    public class Metodos_Pago
    {
        public int Id { get; set; }
        public string NombreMetodo { get; set; } = string.Empty;
        public string? Descripcion { get; set; }
        public bool RequiereAprobacion { get; set; } = false;
        public bool Activo { get; set; } = true;
    }
}