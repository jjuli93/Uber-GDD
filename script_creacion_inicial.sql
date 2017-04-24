use [GD1C2017]
go

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
id numeric(10,0) primary key identity,
id_usuario numeric(10,0) unique not null references [DDG].Usuarios,
nombre varchar(250) not null,
apellido varchar(250) not null,
fecha_nacimiento date not null,
dni numeric(18,0) unique not null,
direccion varchar(250) not null,
codigo_postal numeric not null,
telefono numeric(18,0) unique not null,
email varchar(250),
habilitado numeric(1,0) not null default 1
)
GO

create table [DDG].Choferes (
id numeric(10,0) primary key identity,
id_usuario numeric(10,0) unique not null references [DDG].Usuarios,
nombre varchar(250) not null,
apellido varchar(250) not null,
fecha_nacimiento datetime not null,
dni numeric(18,0) unique not null,
direccion varchar(250) not null,
telefono numeric(18,0) unique not null,
email varchar(250),
habilitado numeric(1,0) not null default 1
)
GO

create table [DDG].Facturas (
id numeric(18,0) primary key identity,
cliente numeric(10,0) not null references [DDG].Clientes,
numero numeric(18,0) unique not null,
fecha_inicio datetime not null,
fecha_fin datetime not null,
importe decimal(7,2) not null default 0
)
GO


create table [DDG].Turnos (
id numeric(10,0) primary key identity,
hora_inicio time not null,
hora_fin time not null,
descripcion varchar(255),
valor_km decimal(5,2) not null,
precio_base decimal(5,2) not null,
habilitado numeric(1,0) not null default 1
)
GO

create table [DDG].Autos (
id numeric(10,0) primary key identity,
turno numeric(10,0) not null references [DDG].Turnos,
chofer numeric(10,0) not null references [DDG].Choferes,
marca varchar(255) not null,
modelo varchar(255) not null,
patente varchar(10)  not null,
licencia varchar(26) not null,
rodado varchar(10) not null,
habilitado numeric(1,0) not null default 1
)
GO

create table [DDG].Pagos (
id numeric(10,0) primary key identity,
chofer numeric(10,0) not null references [DDG].Choferes,
turno numeric(10,0) not null references [DDG].Turnos,
importe decimal(7,2) not null default 0,
fecha datetime
)
GO

create table [DDG].Viaje (
id numeric(18,0) primary key identity,
chofer numeric(10,0) not null references [DDG].Choferes,
auto numeric(10,0) not null references [DDG].Autos,
turno numeric(10,0) not null references [DDG].Turnos,
cliente numeric(10,0) not null references [DDG].Clientes,
pago numeric(10,0) references [DDG].Pagos,
factura numeric(18,0) references [DDG].Facturas,
cantidad_km numeric(5,0) not null,
fecha_viaje date not null,
hora_inicio time not null,
hora_fin time not null
)
GO

