using libreria_BitLab.entidades;
using Microsoft.EntityFrameworkCore;

namespace libreria_BitLab.interfaces
{
    public interface IConexion
    {
        string? StringConexion { get; set; }

        DbSet<Roles>? Roles { get; set; }
        DbSet<Usuarios>? Usuarios { get; set; }
        DbSet<Clientes>? Clientes { get; set; }
        DbSet<Sucursales>? Sucursales { get; set; }
        DbSet<Empleados>? Empleados { get; set; }
        DbSet<Marcas>? Marcas { get; set; }
        DbSet<Proveedores>? Proveedores { get; set; }
        DbSet<EmpresaPaqueteria>? EmpresaPaqueteria { get; set; }
        DbSet<Metodos_Pago>? Metodos_Pago { get; set; }
        DbSet<Promociones>? Promociones { get; set; }
        DbSet<Productos>? Productos { get; set; }
        DbSet<Inventarios>? Inventarios { get; set; }
        DbSet<Compras_Productos>? Compras_Productos { get; set; }
        DbSet<Detalles_Ordenes_Compras>? Detalles_Ordenes_Compras { get; set; }
        DbSet<Ventas>? Ventas { get; set; }
        DbSet<Detalle_Ventas>? Detalle_Ventas { get; set; }
        DbSet<Pagos>? Pagos { get; set; }
        DbSet<Envios>? Envios { get; set; }
        DbSet<Garantias>? Garantias { get; set; }
        DbSet<Devoluciones>? Devoluciones { get; set; }
        DbSet<Resenas>? Resenas { get; set; }

        int SaveChanges();
    }
}
