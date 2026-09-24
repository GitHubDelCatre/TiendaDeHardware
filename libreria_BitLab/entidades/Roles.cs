namespace libreria_BitLab.entidades
{
    public class Roles
    {
        public int Id { get; set; }
        public string NombreRol { get; set; } = string.Empty;
        public string? Descripcion { get; set; }
        public decimal? SalarioEstimado { get; set; }
        public bool EstadoActivo { get; set; } = true;
    }
}