namespace libreria_BitLab.entidades
{
    public class Sucursales
    {
        public int Id { get; set; }
        public string NombreSucursal { get; set; } = string.Empty;
        public string? Direccion { get; set; }
        public string? Ciudad { get; set; }
        public string? TelefonoContacto { get; set; }
        public string? HorarioAtencion { get; set; }
    }
}