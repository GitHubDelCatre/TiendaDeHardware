using libreria_BitLab.entidades;
using Microsoft.EntityFrameworkCore;

namespace libreria_BitLab.interfaces
{
    public interface IConexion
    {
        string? StringConexion { get; set; }

        DbSet<Roles>? Roles { get; set; }
        //DbSet<Enfermedades>? Enfermedades { get; set; }

        int SaveChanges();
    }
}
