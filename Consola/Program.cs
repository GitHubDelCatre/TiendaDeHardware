using libreria_BitLab.implementaciones;
using libreria_BitLab.interfaces;

IConexion conexion = new Conexion()
{
    StringConexion = "Server=(localdb)\\MSSQLLocalDB;Database=db_BitLab;Integrated Security=True;Encrypt=True;TrustServerCertificate=True;"
};
conexion.SaveChanges();

Console.WriteLine("== Roles ==");
var lista_roles = conexion.Roles!.ToList();

foreach (var item in lista_roles)
{
    Console.WriteLine($"NombreRol: {item.NombreRol}, Descripcion: {item.Descripcion}, SalarioEstimado: {item.SalarioEstimado}, EstadoActivo: {item.EstadoActivo}");
}

Console.WriteLine();

Console.WriteLine("== Usuarios ==");
var lista_usuarios = conexion.Usuarios!.ToList();

foreach (var item in lista_usuarios)
{
    Console.WriteLine($"NombreCompleto: {item.NombreCompleto}, Cedula: {item.Cedula}, Correo: {item.Correo}, FechaRegistro: {item.FechaRegistro}, CuentaActiva: {item.CuentaActiva}");
}

Console.WriteLine();

Console.WriteLine("== Clientes ==");
var lista_clientes = conexion.Clientes!.ToList();

foreach (var item in lista_clientes)
{
    Console.WriteLine($"NombreCompleto: {item.NombreCompleto}, Telefono: {item.Telefono}, DireccionPrincipal: {item.DireccionPrincipal}, FechaNacimiento: {item.FechaNacimiento}");
}

Console.WriteLine();

Console.WriteLine("== Sucursales ==");
var lista_sucursales = conexion.Sucursales!.ToList();

foreach (var item in lista_sucursales)
{
    Console.WriteLine($"NombreSucursal: {item.NombreSucursal}, Ciudad: {item.Ciudad}, Direccion: {item.Direccion}, TelefonoContacto: {item.TelefonoContacto}, HorarioAtencion: {item.HorarioAtencion}");
}

Console.WriteLine();

Console.WriteLine("== Empleados ==");
var lista_empleados = conexion.Empleados!.ToList();

foreach (var item in lista_empleados)
{
    Console.WriteLine($"CargoPuesto: {item.CargoPuesto}, Salario: {item.Salario}, FechaContratacion: {item.FechaContratacion}");
}

Console.WriteLine();

Console.WriteLine("== Marcas ==");
var lista_marcas = conexion.Marcas!.ToList();

foreach (var item in lista_marcas)
{
    Console.WriteLine($"NombreMarca: {item.NombreMarca}, SitioWeb: {item.SitioWeb}, CorreoSoporte: {item.CorreoSoporte}, TelefonoContacto: {item.TelefonoContacto}");
}

Console.WriteLine();

Console.WriteLine("== Proveedores ==");
var lista_proveedores = conexion.Proveedores!.ToList();

foreach (var item in lista_proveedores)
{
    Console.WriteLine($"NombreEmpresa: {item.NombreEmpresa}, NitEmpresa: {item.NitEmpresa}, NombreContacto: {item.NombreContacto}, TelefonoPrincipal: {item.TelefonoPrincipal}, CorreoVentas: {item.CorreoVentas}");
}

Console.WriteLine();

Console.WriteLine("== EmpresaPaqueteria ==");
var lista_paqueterias = conexion.EmpresaPaqueteria!.ToList();

foreach (var item in lista_paqueterias)
{
    Console.WriteLine($"NombrePaqueteria: {item.NombrePaqueteria}, Telefono: {item.Telefono}, CorreoElectronico: {item.CorreoElectronico}, NIT: {item.NIT}");
}

Console.WriteLine();

Console.WriteLine("== Metodos_Pago ==");
var lista_metodospago = conexion.Metodos_Pago!.ToList();

foreach (var item in lista_metodospago)
{
    Console.WriteLine($"NombreMetodo: {item.NombreMetodo}, Descripcion: {item.Descripcion}, RequiereAprobacion: {item.RequiereAprobacion}, Activo: {item.Activo}");
}

Console.WriteLine();

Console.WriteLine("== Promociones ==");
var lista_promociones = conexion.Promociones!.ToList();

foreach (var item in lista_promociones)
{
    Console.WriteLine($"CodigoCupon: {item.CodigoCupon}, Descripcion: {item.Descripcion}, PorcentajeDescuento: {item.PorcentajeDescuento}, FechaInicio: {item.FechaInicio}, FechaFin: {item.FechaFin}, EstadoActiva: {item.EstadoActiva}");
}

Console.WriteLine();

Console.WriteLine("== Productos ==");
var lista_productos = conexion.Productos!.ToList();

foreach (var item in lista_productos)
{
    Console.WriteLine($"NombreProducto: {item.NombreProducto}, Marca: {item._Marca?.NombreMarca}, PrecioVenta: {item.PrecioVenta}, Modelo: {item.Modelo}");
}

Console.WriteLine();

Console.WriteLine("== Inventarios ==");
var lista_inventarios = conexion.Inventarios!.ToList();

foreach (var item in lista_inventarios)
{
    Console.WriteLine($"Producto: {item._Producto?.NombreProducto}, Sucursal: {item._Sucursal?.NombreSucursal}, CantidadDisponible: {item.CantidadDisponible}, StockMinimo: {item.StockMinimo}, EstanteriaUbicacion: {item.EstanteriaUbicacion}");
}

Console.WriteLine();

Console.WriteLine("== Compras_Productos ==");
var lista_compras = conexion.Compras_Productos!.ToList();

foreach (var item in lista_compras)
{
    Console.WriteLine($"Proveedor: {item._Proveedor?.NombreEmpresa}, Sucursal: {item._Sucursal?.NombreSucursal}, FechaOrden: {item.FechaOrden}, EstadoOrden: {item.EstadoOrden}, TotalEstimado: {item.TotalEstimado}");
}

Console.WriteLine();

Console.WriteLine("== Detalles_Ordenes_Compras ==");
var lista_detallescompras = conexion.Detalles_Ordenes_Compras!.ToList();

foreach (var item in lista_detallescompras)
{
    Console.WriteLine($"Producto: {item._Producto?.NombreProducto}, CantidadSolicitada: {item.CantidadSolicitada}, CostoUnitario: {item.CostoUnitario}, SubtotalCosto: {item.SubtotalCosto}");
}

Console.WriteLine();

Console.WriteLine("== Ventas ==");
var lista_ventas = conexion.Ventas!.ToList();

foreach (var item in lista_ventas)
{
    Console.WriteLine($"Cliente: {item._Cliente?.NombreCompleto}, Sucursal: {item._Sucursal?.NombreSucursal}, FechaVenta: {item.FechaVenta}, EstadoVenta: {item.EstadoVenta}, TotalPagar: {item.TotalPagar}");
}

Console.WriteLine();

Console.WriteLine("== Detalle_Ventas ==");
var lista_detalleventas = conexion.Detalle_Ventas!.ToList();

foreach (var item in lista_detalleventas)
{
    Console.WriteLine($"Producto: {item._Producto?.NombreProducto}, Cantidad: {item.Cantidad}, PrecioUnitarioVenta: {item.PrecioUnitarioVenta}, DescuentoAplicado: {item.DescuentoAplicado}, Subtotal: {item.Subtotal}");
}

Console.WriteLine();

Console.WriteLine("== Pagos ==");
var lista_pagos = conexion.Pagos!.ToList();

foreach (var item in lista_pagos)
{
    Console.WriteLine($"MetodoPago: {item._MetodoPago?.NombreMetodo}, MontoPagado: {item.MontoPagado}, FechaPago: {item.FechaPago}, EstadoTransaccion: {item.EstadoTransaccion}");
}

Console.WriteLine();

Console.WriteLine("== Envios ==");
var lista_envios = conexion.Envios!.ToList();

foreach (var item in lista_envios)
{
    Console.WriteLine($"EmpresaPaqueteria: {item._EmpresaPaqueteria?.NombrePaqueteria}, NumeroGuia: {item.NumeroGuia}, EstadoEnvio: {item.EstadoEnvio}, FechaEstimadaEntrega: {item.FechaEstimadaEntrega}, CostoEnvio: {item.CostoEnvio}");
}

Console.WriteLine();

Console.WriteLine("== Garantias ==");
var lista_garantias = conexion.Garantias!.ToList();

foreach (var item in lista_garantias)
{
    Console.WriteLine($"FechaSolicitud: {item.FechaSolicitud}, MotivoFalla: {item.MotivoFalla}, EstadoGarantia: {item.EstadoGarantia}, ResolucionTecnica: {item.ResolucionTecnica}");
}

Console.WriteLine();

Console.WriteLine("== Devoluciones ==");
var lista_devoluciones = conexion.Devoluciones!.ToList();

foreach (var item in lista_devoluciones)
{
    Console.WriteLine($"MotivoDevolucion: {item.MotivoDevolucion}, EstadoProceso: {item.EstadoProceso}, MontoReembolsado: {item.MontoReembolsado}");
}

Console.WriteLine();

Console.WriteLine("== Reseñas ==");
var lista_resenas = conexion.Resenas!.ToList();

foreach (var item in lista_resenas)
{
    Console.WriteLine($"Producto: {item._Producto?.NombreProducto}, Cliente: {item._Cliente?.NombreCompleto}, CalificacionEstrellas: {item.CalificacionEstrellas}, Comentario: {item.Comentario}");
}

Console.WriteLine();