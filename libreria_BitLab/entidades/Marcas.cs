namespace libreria_BitLab.entidades
{
    public class Marcas
    {
        public int Id { get; set; }
        public string NombreMarca { get; set; } = string.Empty;
        public string? SitioWeb { get; set; }
        public string? CorreoSoporte { get; set; }
        public string? TelefonoContacto { get; set; }
    }
}