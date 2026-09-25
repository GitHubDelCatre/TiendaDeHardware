namespace libreria_BitLab.entidades
{
    public class EmpresaPaqueteria
    {
        public int Id { get; set; }
        public string? Telefono { get; set; }
        public string? CorreoElectronico { get; set; }
        public string? NIT { get; set; }
        public string NombrePaqueteria { get; set; } = string.Empty;
    }
}