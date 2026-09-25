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
        public DbSet<Usuarios>? Usuarios { get; set; }
        public DbSet<Clientes>? Clientes { get; set; }
        public DbSet<Sucursales>? Sucursales { get; set; }
        public DbSet<Empleados>? Empleados { get; set; }
        public DbSet<Marcas>? Marcas { get; set; }
        public DbSet<Proveedores>? Proveedores { get; set; }
        public DbSet<EmpresaPaqueteria>? EmpresaPaqueteria { get; set; }
        public DbSet<Metodos_Pago>? Metodos_Pago { get; set; }
        public DbSet<Promociones>? Promociones { get; set; }
        public DbSet<Productos>? Productos { get; set; }
        public DbSet<Inventarios>? Inventarios { get; set; }
        public DbSet<Compras_Productos>? Compras_Productos { get; set; }
        public DbSet<Detalles_Ordenes_Compras>? Detalles_Ordenes_Compras { get; set; }
        public DbSet<Ventas>? Ventas { get; set; }
        public DbSet<Detalle_Ventas>? Detalle_Ventas { get; set; }
        public DbSet<Pagos>? Pagos { get; set; }
        public DbSet<Envios>? Envios { get; set; }
        public DbSet<Garantias>? Garantias { get; set; }
        public DbSet<Devoluciones>? Devoluciones { get; set; }
        public DbSet<Resenas>? Resenas { get; set; }
    }
}