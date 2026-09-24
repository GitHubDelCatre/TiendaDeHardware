CREATE DATABASE db_BitLab;
GO



create table Roles(
    [Id] int primary key identity(1,1) not null,
    [NombreRol] varchar(50) not null,
    [Descripcion] varchar(255) null,
    [SalarioEstimado] decimal(10,2) null,
    [EstadoActivo] bit not null default 1
);

create table Usuarios(
    [Id] int primary key identity(1,1) not null,
    [IdRol] int not null references [Roles]([Id]),
    [NombreCompleto] varchar(150) not null,
    [Cedula] varchar(20) not null unique,
    [Correo] varchar(150) not null unique,
    [Contrasena] varchar(255) not null,
    [FechaRegistro] datetime not null default getdate(),
    [CuentaActiva] bit not null default 1
);


create table Clientes(
    [Id] int primary key identity(1,1) not null,
    [IdUsuario] int not null references [Usuarios]([Id]) unique,
    [NombreCompleto] varchar(150) not null,
    [Telefono] varchar(20) null,
    [DireccionPrincipal] varchar(255) null,
    [FechaNacimiento] date null
);

create table Sucursales(
    [Id] int primary key identity(1,1) not null,
    [NombreSucursal] varchar(100) not null,
    [Direccion] varchar(255) null,
    [Ciudad] varchar(100) null,
    [TelefonoContacto] varchar(20) null,
    [HorarioAtencion] varchar(100) null
);

create table Empleados(
    [Id] int primary key identity(1,1) not null,
    [IdUsuario] int not null references [Usuarios]([Id]) unique,
    [IdSucursal] int not null references [Sucursales]([Id]),
    [CargoPuesto] varchar(100) null,
    [Salario] decimal(10,2) null,
    [FechaContratacion] date null
);

create table Marcas(
    [Id] int primary key identity(1,1) not null,
    [NombreMarca] varchar(100) not null,
    [SitioWeb] varchar(255) null,
    [CorreoSoporte] varchar(150) null,
    [TelefonoContacto] varchar(20) null
);

create table Proveedores(
    [Id] int primary key identity(1,1) not null,
    [NombreEmpresa] varchar(150) not null,
    [NitEmpresa] varchar(30) not null unique,
    [NombreContacto] varchar(100) null,
    [TelefonoPrincipal] varchar(20) null,
    [CorreoVentas] varchar(150) null,
    [DireccionFisica] varchar(255) null
);

create table EmpresaPaqueteria(
    [Id] int primary key identity(1,1) not null,
    [Telefono] varchar(20) null,
    [CorreoElectronico] varchar(150) null,
    [NIT] varchar(30) null,
    [NombrePaqueteria] varchar(100) not null
);

create table Metodos_Pago(
    [Id] int primary key identity(1,1) not null,
    [NombreMetodo] varchar(50) not null,
    [Descripcion] varchar(255) null,
    [RequiereAprobacion] bit not null default 0,
    [Activo] bit not null default 1
);

create table Promociones(
    [Id] int primary key identity(1,1) not null,
    [CodigoCupon] varchar(30) not null unique,
    [Descripcion] varchar(255) null,
    [PorcentajeDescuento] decimal(5,2) null,
    [FechaInicio] datetime null,
    [FechaFin] datetime null,
    [EstadoActiva] bit not null default 1
);

create table Productos(
    [Id] int primary key identity(1,1) not null,
    [IdMarca] int not null references [Marcas]([Id]),
    [NombreProducto] varchar(150) not null,
    [DescripcionLarga] nvarchar(max) null,
    [PrecioVenta] decimal(10,2) not null,
    [NumeroSerie] varchar(50) null,
    [Modelo] varchar(100) null,
    [EspecificacionesTecnicas] nvarchar(max) null
);

create table Inventarios(
    [Id] int primary key identity(1,1) not null,
    [IdProducto] int not null references [Productos]([Id]),
    [IdSucursal] int not null references [Sucursales]([Id]),
    [CantidadDisponible] int not null default 0,
    [StockMinimo] int not null default 0,
    [EstanteriaUbicacion] varchar(50) null,
    [UltimaActualizacion] datetime not null default getdate(),
    [CapacidadBodega] int null
);

create table Compras_Productos(
    [Id] int primary key identity(1,1) not null,
    [IdProveedor] int not null references [Proveedores]([Id]),
    [IdSucursal] int not null references [Sucursales]([Id]),
    [FechaOrden] datetime not null default getdate(),
    [EstadoOrden] varchar(50) null,
    [TotalEstimado] decimal(10,2) null,
    [NotasInternas] nvarchar(max) null
);

create table Detalles_Ordenes_Compras(
    [Id] int primary key identity(1,1) not null,
    [IdComprasProducto] int not null references [Compras_Productos]([Id]),
    [IdProducto] int not null references [Productos]([Id]),
    [CantidadSolicitada] int not null,
    [CostoUnitario] decimal(10,2) not null,
    [SubtotalCosto] decimal(10,2) null
);

create table Ventas(
    [Id] int primary key identity(1,1) not null,
    [IdCliente] int not null references [Clientes]([Id]),
    [IdSucursal] int not null references [Sucursales]([Id]),
    [IdPromocion] int null references [Promociones]([Id]),
    [FechaVenta] datetime not null default getdate(),
    [EstadoVenta] varchar(50) null,
    [TotalPagar] decimal(10,2) null,
    [DireccionEnvio] varchar(255) null
);

create table Detalle_Ventas(
    [Id] int primary key identity(1,1) not null,
    [IdVenta] int not null references [Ventas]([Id]),
    [IdProducto] int not null references [Productos]([Id]),
    [Cantidad] int not null,
    [PrecioUnitarioVenta] decimal(10,2) not null,
    [DescuentoAplicado] decimal(10,2) not null default 0,
    [Subtotal] decimal(10,2) null
);

create table Pagos(
    [Id] int primary key identity(1,1) not null,
    [IdVenta] int not null references [Ventas]([Id]),
    [IdMetodoPago] int not null references [Metodos_Pago]([Id]),
    [MontoPagado] decimal(10,2) not null,
    [FechaPago] datetime not null default getdate(),
    [EstadoTransaccion] varchar(50) null,
    [ReferenciaPasarela] varchar(100) null
);

create table Envios(
    [Id] int primary key identity(1,1) not null,
    [IdVenta] int not null references [Ventas]([Id]),
    [IdEmpresaPaqueteria] int not null references [EmpresaPaqueteria]([Id]),
    [NumeroGuia] varchar(50) null,
    [EstadoEnvio] varchar(50) null,
    [FechaEstimadaEntrega] date null,
    [FechaEntregaReal] date null,
    [CostoEnvio] decimal(10,2) null
);

create table Garantias(
    [Id] int primary key identity(1,1) not null,
    [IdDetalleVenta] int not null references [Detalle_Ventas]([Id]),
    [FechaSolicitud] date null,
    [MotivoFalla] varchar(255) null,
    [EstadoGarantia] varchar(50) null,
    [ResolucionTecnica] varchar(255) null,
    [FechaCierre] date null
);

create table Devoluciones(
    [Id] int primary key identity(1,1) not null,
    [IdVentas] int not null references [Ventas]([Id]),
    [IdMetodoPagoReembolso] int not null references [Metodos_Pago]([Id]),
    [FechaSolicitud] date null,
    [MotivoDevolucion] varchar(255) null,
    [EstadoProceso] varchar(50) null,
    [MontoReembolsado] decimal(10,2) null
);

create table Resenas(
    [Id] int primary key identity(1,1) not null,
    [IdProducto] int not null references [Productos]([Id]),
    [IdCliente] int not null references [Clientes]([Id]),
    [CalificacionEstrellas] int not null check ([CalificacionEstrellas] between 1 and 5),
    [Comentario] nvarchar(max) null,
    [FechaPublicacion] datetime not null default getdate()
);


-- ===================  INSERTS DE PRUEBA  ==================

-- 1. ROLES
insert into Roles (NombreRol, Descripcion, SalarioEstimado, EstadoActivo) values
('Administrador', 'Gestiona el sistema y sucursales', 3500000, 1),
('Vendedor', 'Atiende clientes y gestiona ventas', 1600000, 1),
('Bodeguero', 'Controla el inventario', 1500000, 1),
('Gerente', 'Supervisa la sucursal', 2800000, 1),
('Cliente', 'Rol asignado a usuarios compradores', 0, 1);

-- 2. USUARIOS (1-5 clientes, 6-10 empleados)
insert into Usuarios (IdRol, NombreCompleto, Cedula, Correo, Contrasena, FechaRegistro, CuentaActiva) values
(5, 'Laura Gomez', '1001111111', 'laura.gomez@mail.com', 'hash123', getdate(), 1),
(5, 'Carlos Ruiz', '1002222222', 'carlos.ruiz@mail.com', 'hash123', getdate(), 1),
(5, 'Ana Torres', '1003333333', 'ana.torres@mail.com', 'hash123', getdate(), 1),
(5, 'Diego Pena', '1004444444', 'diego.pena@mail.com', 'hash123', getdate(), 1),
(5, 'Maria Lopez', '1005555555', 'maria.lopez@mail.com', 'hash123', getdate(), 1),
(1, 'Jorge Ramirez', '2001111111', 'jorge.ramirez@tienda.com', 'hash456', getdate(), 1),
(2, 'Sofia Diaz', '2002222222', 'sofia.diaz@tienda.com', 'hash456', getdate(), 1),
(3, 'Andres Mora', '2003333333', 'andres.mora@tienda.com', 'hash456', getdate(), 1),
(4, 'Paula Vargas', '2004444444', 'paula.vargas@tienda.com', 'hash456', getdate(), 1),
(2, 'Felipe Castro', '2005555555', 'felipe.castro@tienda.com', 'hash456', getdate(), 1);

-- 3. CLIENTES
insert into Clientes (IdUsuario, NombreCompleto, Telefono, DireccionPrincipal, FechaNacimiento) values
(1, 'Laura Gomez', '3001234561', 'Calle 10 # 20-30, Medellin', '1995-03-12'),
(2, 'Carlos Ruiz', '3001234562', 'Carrera 45 # 12-08, Bogota', '1990-07-25'),
(3, 'Ana Torres', '3001234563', 'Avenida 80 # 33-10, Cali', '1998-11-02'),
(4, 'Diego Pena', '3001234564', 'Calle 50 # 15-40, Medellin', '1993-05-18'),
(5, 'Maria Lopez', '3001234565', 'Carrera 7 # 45-60, Bogota', '2000-01-30');

-- 4. SUCURSALES
insert into Sucursales (NombreSucursal, Direccion, Ciudad, TelefonoContacto, HorarioAtencion) values
('Sucursal Centro', 'Calle 30 # 20-15', 'Medellin', '6041234567', 'Lun-Sab 8am-7pm'),
('Sucursal Norte', 'Carrera 65 # 90-12', 'Medellin', '6041234568', 'Lun-Sab 9am-8pm'),
('Sucursal Bogota', 'Calle 100 # 15-20', 'Bogota', '6011234567', 'Lun-Sab 9am-8pm'),
('Sucursal Cali', 'Avenida 6 # 25-40', 'Cali', '6021234567', 'Lun-Sab 8am-7pm'),
('Sucursal Barranquilla', 'Calle 72 # 50-10', 'Barranquilla', '6051234567', 'Lun-Sab 9am-7pm');

-- 5. EMPLEADOS
insert into Empleados (IdUsuario, IdSucursal, CargoPuesto, Salario, FechaContratacion) values
(6, 1, 'Administrador de sucursal', 3500000, '2021-02-01'),
(7, 1, 'Vendedor', 1600000, '2022-05-15'),
(8, 2, 'Bodeguero', 1500000, '2022-08-20'),
(9, 3, 'Gerente', 2800000, '2020-11-10'),
(10, 4, 'Vendedor', 1600000, '2023-01-05');

-- 6. MARCAS
insert into Marcas (NombreMarca, SitioWeb, CorreoSoporte, TelefonoContacto) values
('Samsung', 'www.samsung.com', 'soporte@samsung.com', '018000123456'),
('Sony', 'www.sony.com', 'soporte@sony.com', '018000234567'),
('LG', 'www.lg.com', 'soporte@lg.com', '018000345678'),
('HP', 'www.hp.com', 'soporte@hp.com', '018000456789'),
('Xiaomi', 'www.mi.com', 'soporte@mi.com', '018000567890');

-- 7. PROVEEDORES
insert into Proveedores (NombreEmpresa, NitEmpresa, NombreContacto, TelefonoPrincipal, CorreoVentas, DireccionFisica) values
('Distribuciones Andinas SAS', '900111222-1', 'Ricardo Nino', '6011112233', 'ventas@distandinas.com', 'Zona Franca, Bogota'),
('ImportTech Ltda', '900222333-2', 'Camila Ortiz', '6021112233', 'ventas@importtech.com', 'Zona Industrial, Cali'),
('MegaSupply Colombia', '900333444-3', 'Julian Rojas', '6041112233', 'ventas@megasupply.com', 'Zona Industrial, Medellin'),
('Electro Mayoristas SA', '900444555-4', 'Valentina Cruz', '6051112233', 'ventas@electromayoristas.com', 'Barranquilla'),
('TecnoImportaciones SAS', '900555666-5', 'Santiago Leon', '6031112233', 'ventas@tecnoimport.com', 'Pereira');

-- 8. EMPRESA PAQUETERIA
insert into EmpresaPaqueteria (Telefono, CorreoElectronico, NIT, NombrePaqueteria) values
('018000111111', 'contacto@servientrega.com', '860111111-1', 'Servientrega'),
('018000222222', 'contacto@coordinadora.com', '860222222-2', 'Coordinadora'),
('018000333333', 'contacto@tcc.com.co', '860333333-3', 'TCC'),
('018000444444', 'contacto@envia.co', '860444444-4', 'Envia'),
('018000555555', 'contacto@interrapidisimo.com', '860555555-5', 'Interrapidisimo');

-- 9. METODOS_PAGO
insert into Metodos_Pago (NombreMetodo, Descripcion, RequiereAprobacion, Activo) values
('Tarjeta de Credito', 'Pago con tarjeta de credito', 1, 1),
('Tarjeta de Debito', 'Pago con tarjeta debito', 1, 1),
('Efectivo', 'Pago en efectivo contra entrega', 0, 1),
('PSE', 'Pago electronico bancario', 1, 1),
('Nequi', 'Pago mediante billetera digital', 0, 1);

-- 10. PROMOCIONES
insert into Promociones (CodigoCupon, Descripcion, PorcentajeDescuento, FechaInicio, FechaFin, EstadoActiva) values
('BIENVENIDA10', 'Descuento de bienvenida', 10.00, '2026-01-01', '2026-12-31', 1),
('VERANO2026', 'Promocion de verano', 15.00, '2026-06-01', '2026-08-31', 1),
('BLACKFRIDAY', 'Descuento Black Friday', 25.00, '2026-11-20', '2026-11-30', 1),
('NAVIDAD2026', 'Descuento navideno', 20.00, '2026-12-01', '2026-12-25', 1),
('CLIENTEVIP', 'Descuento clientes frecuentes', 5.00, '2026-01-01', '2026-12-31', 1);

-- 11. PRODUCTOS
insert into Productos (IdMarca, NombreProducto, DescripcionLarga, PrecioVenta, NumeroSerie, Modelo, EspecificacionesTecnicas) values
(1, 'Televisor Samsung 55" 4K', 'Smart TV UHD con HDR', 2500000, 'SN-SAM-001', 'UN55AU7000', '{"pantalla":"55 pulgadas","resolucion":"4K"}'),
(2, 'Audifonos Sony WH-1000XM5', 'Audifonos inalambricos con cancelacion de ruido', 1200000, 'SN-SNY-002', 'WH1000XM5', '{"bateria":"30h","bluetooth":"5.2"}'),
(3, 'Nevera LG No Frost', 'Nevera 400L con tecnologia inverter', 2100000, 'SN-LG-003', 'GT41BPP', '{"capacidad":"400L","tipo":"No Frost"}'),
(4, 'Portatil HP Pavilion 15', 'Laptop para uso general y oficina', 3200000, 'SN-HP-004', 'Pavilion15-eg', '{"ram":"16GB","almacenamiento":"512GB SSD"}'),
(5, 'Celular Xiaomi Redmi Note 13', 'Smartphone gama media con buena camara', 950000, 'SN-XMI-005', 'RedmiNote13', '{"ram":"8GB","almacenamiento":"256GB"}');

-- 12. INVENTARIOS
insert into Inventarios (IdProducto, IdSucursal, CantidadDisponible, StockMinimo, EstanteriaUbicacion, UltimaActualizacion, CapacidadBodega) values
(1, 1, 15, 5, 'A1-01', getdate(), 100),
(2, 1, 30, 10, 'A2-05', getdate(), 150),
(3, 2, 8, 3, 'B1-02', getdate(), 60),
(4, 3, 12, 4, 'C1-03', getdate(), 80),
(5, 4, 40, 10, 'D1-01', getdate(), 200);

-- 13. COMPRAS_PRODUCTOS
insert into Compras_Productos (IdProveedor, IdSucursal, FechaOrden, EstadoOrden, TotalEstimado, NotasInternas) values
(1, 1, '2026-08-01', 'Completada', 15000000, 'Pedido regular mensual'),
(2, 2, '2026-08-05', 'Pendiente', 8000000, 'Reposicion de audifonos'),
(3, 3, '2026-08-10', 'Completada', 12000000, 'Pedido de neveras'),
(4, 4, '2026-08-12', 'En transito', 9500000, 'Portatiles para promocion'),
(5, 1, '2026-08-15', 'Completada', 6000000, 'Reposicion de celulares');

-- 14. DETALLES_ORDENES_COMPRAS
insert into Detalles_Ordenes_Compras (IdComprasProducto, IdProducto, CantidadSolicitada, CostoUnitario, SubtotalCosto) values
(1, 1, 10, 1800000, 18000000),
(2, 2, 20, 800000, 16000000),
(3, 3, 8, 1500000, 12000000),
(4, 4, 10, 2400000, 24000000),
(5, 5, 15, 600000, 9000000);

-- 15. VENTAS
insert into Ventas (IdCliente, IdSucursal, IdPromocion, FechaVenta, EstadoVenta, TotalPagar, DireccionEnvio) values
(1, 1, 1, '2026-09-01', 'Completada', 2250000, 'Calle 10 # 20-30, Medellin'),
(2, 1, null, '2026-09-03', 'Completada', 1200000, 'Carrera 45 # 12-08, Bogota'),
(3, 2, 2, '2026-09-05', 'En proceso', 1785000, 'Avenida 80 # 33-10, Cali'),
(4, 3, null, '2026-09-08', 'Completada', 3200000, 'Calle 50 # 15-40, Medellin'),
(5, 4, 5, '2026-09-10', 'Completada', 902500, 'Carrera 7 # 45-60, Bogota');

-- 16. DETALLE_VENTAS
insert into Detalle_Ventas (IdVenta, IdProducto, Cantidad, PrecioUnitarioVenta, DescuentoAplicado, Subtotal) values
(1, 1, 1, 2500000, 250000, 2250000),
(2, 2, 1, 1200000, 0, 1200000),
(3, 3, 1, 2100000, 315000, 1785000),
(4, 4, 1, 3200000, 0, 3200000),
(5, 5, 1, 950000, 47500, 902500);

-- 17. PAGOS
insert into Pagos (IdVenta, IdMetodoPago, MontoPagado, FechaPago, EstadoTransaccion, ReferenciaPasarela) values
(1, 1, 2250000, '2026-09-01', 'Aprobado', 'REF-0001'),
(2, 3, 1200000, '2026-09-03', 'Aprobado', 'REF-0002'),
(3, 4, 1785000, '2026-09-05', 'Pendiente', 'REF-0003'),
(4, 1, 3200000, '2026-09-08', 'Aprobado', 'REF-0004'),
(5, 5, 902500, '2026-09-10', 'Aprobado', 'REF-0005');

-- 18. ENVIOS
insert into Envios (IdVenta, IdEmpresaPaqueteria, NumeroGuia, EstadoEnvio, FechaEstimadaEntrega, FechaEntregaReal, CostoEnvio) values
(1, 1, 'GUIA-0001', 'Entregado', '2026-09-04', '2026-09-03', 15000),
(2, 2, 'GUIA-0002', 'Entregado', '2026-09-06', '2026-09-06', 12000),
(3, 3, 'GUIA-0003', 'En transito', '2026-09-09', null, 18000),
(4, 4, 'GUIA-0004', 'Entregado', '2026-09-11', '2026-09-10', 20000),
(5, 5, 'GUIA-0005', 'Pendiente', '2026-09-13', null, 10000);

-- 19. GARANTIAS
insert into Garantias (IdDetalleVenta, FechaSolicitud, MotivoFalla, EstadoGarantia, ResolucionTecnica, FechaCierre) values
(1, '2026-09-15', 'Pantalla con lineas verticales', 'Cerrada', 'Cambio de panel', '2026-09-20'),
(2, '2026-09-16', 'No enciende', 'En proceso', null, null),
(3, '2026-09-17', 'Ruido en el compresor', 'Cerrada', 'Ajuste de compresor', '2026-09-22'),
(4, '2026-09-18', 'Bateria no carga', 'En proceso', null, null),
(5, '2026-09-19', 'Pantalla tactil no responde', 'Cerrada', 'Cambio de equipo', '2026-09-23');

-- 20. DEVOLUCIONES
insert into Devoluciones (IdVentas, IdMetodoPagoReembolso, FechaSolicitud, MotivoDevolucion, EstadoProceso, MontoReembolsado) values
(1, 1, '2026-09-20', 'Producto defectuoso', 'Aprobada', 2250000),
(2, 3, '2026-09-21', 'Cambio de opinion', 'Rechazada', 0),
(3, 4, '2026-09-22', 'Producto incompleto', 'Aprobada', 1785000),
(4, 1, '2026-09-23', 'Producto no coincide con la descripcion', 'En proceso', 0),
(5, 5, '2026-09-24', 'Producto danado en transporte', 'Aprobada', 902500);

-- 21. RESENAS
insert into Resenas (IdProducto, IdCliente, CalificacionEstrellas, Comentario, FechaPublicacion) values
(1, 1, 5, 'Excelente calidad de imagen, muy recomendado', getdate()),
(2, 2, 4, 'Buen sonido pero la cancelacion de ruido podria mejorar', getdate()),
(3, 3, 5, 'La nevera enfria muy bien y es silenciosa', getdate()),
(4, 4, 4, 'Buen rendimiento para trabajo de oficina', getdate()),
(5, 5, 3, 'Cumple pero la bateria dura menos de lo esperado', getdate());