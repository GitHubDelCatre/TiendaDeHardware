using libreria_BitLab.implementaciones;
using libreria_BitLab.interfaces;

IConexion conexion = new Conexion()
{
    StringConexion = "Server=(localdb)\\MSSQLLocalDB;Database=db_BitLab;Integrated Security=True;Encrypt=True;TrustServerCertificate=True;"
};
conexion.SaveChanges();
var lista_roles = conexion.Roles!.ToList();

foreach (var item in lista_roles)
{
    Console.WriteLine($"Id: {item.Id} NombreRol: {item.NombreRol} Descripcion: {item.Descripcion} SalarioEstimado: {item.SalarioEstimado} EstadoActivo: {item.EstadoActivo}");
}