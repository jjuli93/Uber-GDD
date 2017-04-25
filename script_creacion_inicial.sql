use [GD1C2017]
go

					/* Creacion de tablas*/

create schema [DDG] authorization [gd]
go


create table [DDG].Funcionalidades(
funcionalidad_ID numeric(10,0) primary key identity,
funcionalidad_descripcion varchar(255) not null,
)
GO

create table [DDG].Roles(
rol_ID numeric(10,0) primary key identity,
rol_nombre varchar(255) not null,
rol_habilitado bit default 1
)
GO

create table [DDG].RolesXFuncionalidades(
rolXFuncionalidad_ID numeric(10,0) primary key identity,
rolXFuncionalidad_rol numeric(10,0) not null references [DDG].Roles,
rolXFuncionalidad_funcionalidad numeric(10,0) not null references [DDG].Funcionalidades ,
)
GO

create table [DDG].Usuarios(
usuario_ID numeric(10,0) primary key identity,
usuario_username varchar(255) unique not null,
usuario_password varchar(255) not null,
usuario_intentosFallidos int default 0,
)
GO

create table [DDG].UsuariosXRoles(
usuarioXRol_ID numeric(10,0) primary key identity,
usuarioXRol_usuario numeric(10,0) not null references [DDG].Usuarios,
usuarioXRol_rol numeric(10,0) not null references [DDG].Roles,
)
GO

create table [DDG].Clientes (
cliente_id numeric(10,0) primary key identity,
cliente_usuario numeric(10,0) unique not null references [DDG].Usuarios,
cliente_nombre varchar(250) not null,
cliente_apellido varchar(250) not null,
cliente_fecha_nacimiento date not null,
cliente_dni numeric(18,0) unique not null,
cliente_direccion varchar(250) not null,
cliente_codigo_postal numeric not null,
cliente_telefono numeric(18,0) unique not null,
cliente_email varchar(250),
cliente_habilitado numeric(1,0) not null default 1
)
GO

create table [DDG].Choferes (
chofer_id numeric(10,0) primary key identity,
chofer_usuario numeric(10,0) unique not null references [DDG].Usuarios,
chofer_nombre varchar(250) not null,
chofer_apellido varchar(250) not null,
chofer_fecha_nacimiento datetime not null,
chofer_dni numeric(18,0) unique not null,
chofer_direccion varchar(250) not null,
chofer_telefono numeric(18,0) unique not null,
chofer_email varchar(250),
chofer_habilitado numeric(1,0) not null default 1
)
GO

create table [DDG].Facturas (
factura_id numeric(18,0) primary key identity,
factura_cliente numeric(10,0) not null references [DDG].Clientes,
factura_numero numeric(18,0) unique not null,
factura_fecha_inicio datetime not null,
factura_fecha_fin datetime not null,
factura_importe decimal(7,2) not null default 0
)
GO


create table [DDG].Turnos (
turno_id numeric(10,0) primary key identity,
turno_hora_inicio time not null,
turno_hora_fin time not null,
turno_descripcion varchar(255),
turno_valor_km decimal(5,2) not null,
turno_precio_base decimal(5,2) not null,
turno_habilitado numeric(1,0) not null default 1
)
GO

create table [DDG].Autos (
auto_id numeric(10,0) primary key identity,
auto_turno numeric(10,0) not null references [DDG].Turnos,
auto_chofer numeric(10,0) not null references [DDG].Choferes,
auto_marca varchar(255) not null,
auto_modelo varchar(255) not null,
auto_patente varchar(10)  not null,
auto_licencia varchar(26) not null,
auto_rodado varchar(10) not null,
auto_habilitado numeric(1,0) not null default 1
)
GO

create table [DDG].Pagos (
pago_id numeric(10,0) primary key identity,
pago_chofer numeric(10,0) not null references [DDG].Choferes,
pago_turno numeric(10,0) not null references [DDG].Turnos,
pago_importe decimal(7,2) not null default 0,
pago_fecha datetime
)
GO

create table [DDG].Viajes (
viaje_id numeric(18,0) primary key identity,
viaje_chofer numeric(10,0) not null references [DDG].Choferes,
viaje_auto numeric(10,0) not null references [DDG].Autos,
viaje_turno numeric(10,0) not null references [DDG].Turnos,
viaje_cliente numeric(10,0) not null references [DDG].Clientes,
viaje_pago numeric(10,0) references [DDG].Pagos,
viaje_factura numeric(18,0) references [DDG].Facturas,
viaje_cantidad_km numeric(5,0) not null,
viaje_fecha_viaje date not null,
viaje_hora_inicio time not null,
viaje_hora_fin time not null
)
GO

				/* Carga de datos*/

	/*Roles*/
insert into [DDG].Roles (rol_nombre) values
('Administrativo'), 
('Chofer'), 
('Cliente');

	/*Funciones*/

	/*Usuarios*/

/*Usuario pedido*/
insert into DDG.Usuarios (usuario_username, usuario_password) values
('admin',HASHBYTES('SHA2_256','w23e'))

/*usuarios clientes*/
insert into DDG.Usuarios (usuario_username, usuario_password)
select distinct cast(Cliente_Dni as varchar(255)), HASHBYTES('SHA2_256',cast(Cliente_Dni as varchar(255)))
from gd_esquema.Maestra
where Cliente_Dni is not null
order by cast(Cliente_Dni as varchar(255))

/*Usuarios choferes*/
insert into DDG.Usuarios (usuario_username, usuario_password)
select distinct cast(Chofer_Dni as varchar(255)), HASHBYTES('SHA2_256',cast(Chofer_Dni as varchar(255)))
from gd_esquema.Maestra
where Chofer_Dni is not null
order by cast(Chofer_Dni as varchar(255))
