using libreria_BitLab.interfaces;
using Microsoft.EntityFrameworkCore;

namespace libreria_BitLab.implementaciones
{
    public class Conexion : DbContext, IConexion
    {
        public string? StringConexion { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(this.StringConexion!, p => { });
            optionsBuilder.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
        }

        //public DbSet<Pacientes>? Pacientes { get; set; }

        //public DbSet<Enfermedades>? Enfermedades { get; set; }
        
    }
}