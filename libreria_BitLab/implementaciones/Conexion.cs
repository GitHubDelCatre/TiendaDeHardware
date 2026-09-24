using libreria_BitLab.entidades;
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

        public DbSet<Roles>? Roles { get; set; }
        //public DbSet<Enfermedades>? Enfermedades { get; set; }

    }
}