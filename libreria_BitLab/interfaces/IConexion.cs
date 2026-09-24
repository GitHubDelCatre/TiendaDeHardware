using Microsoft.EntityFrameworkCore;

namespace libreria_BitLab.interfaces
{
    public interface IConexion
    {
        string? StringConexion { get; set; }

        //DbSet<Pacientes>? Pacientes { get; set; }
        //DbSet<Enfermedades>? Enfermedades { get; set; }

        int SaveChanges();
    }
}
