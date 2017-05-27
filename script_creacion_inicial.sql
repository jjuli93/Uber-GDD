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
cliente_codigo_postal numeric  /*not null*/,		/*saco el not null porque en la base de datos ningun cliente tiene cod postal)*/
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

create table [DDG].FacturasDetalle (
facturaDetalle_id numeric(18,0) primary key identity,
facturaDetalle_factura numeric(18,0) not null references [DDG].Facturas
)
GO

create table [DDG].Turnos (
turno_id numeric(10,0) primary key identity,
turno_hora_inicio numeric(18,0) not null,
turno_hora_fin numeric(18,0) not null,
turno_descripcion varchar(255),
turno_valor_km decimal(5,2) not null,
turno_precio_base decimal(5,2) not null,
turno_habilitado numeric(1,0) not null default 1
)
GO

create table [DDG].Marcas (
marca_id numeric(10,0) primary key identity,
marca_descripcion varchar(255) not null
)
GO

create table [DDG].Modelos (
modelo_id numeric(10,0) primary key identity,
modelo_descripcion varchar(255) not null,
modelo_marca numeric(10,0) not null references [DDG].Marcas
)
GO

create table [DDG].Autos (
auto_id numeric(10,0) primary key identity,
auto_chofer numeric(10,0) not null references [DDG].Choferes,
auto_modelo numeric(10,0) not null references [DDG].Modelos,
auto_patente varchar(10)  not null unique,
auto_licencia varchar(26) not null,
auto_rodado varchar(10) not null,
auto_habilitado numeric(1,0) not null default 1
)
GO

create table [DDG].AutosXTurnos (
autoXTurno_id numeric(10,0) primary key identity,
autoXTurno_auto numeric(10,0) not null references [DDG].Autos,
autoXTurno_turno numeric(10,0) not null references [DDG].Turnos
)
GO

create table [DDG].Porcentajes(
porcentaje_id numeric(10,0) primary key identity,
porcentaje_valor numeric(10,0) not null,
porcentaje_fecha date not null,
porcentaje_impuestoPor numeric(10,0)  references [DDG].Usuarios
)
GO

create table [DDG].Rendiciones (
rendicion_id numeric(10,0) primary key identity,
rendicion_chofer numeric(10,0) not null references [DDG].Choferes,
rendicion_turno numeric(10,0) not null references [DDG].Turnos,
rendicion_importe decimal(7,2) not null default 0,
rendicion_numero numeric(18,0) not null,
rendicion_porcentaje numeric(10,0) not null references [DDG].Porcentajes,
rendicion_fecha datetime
)
GO

create table [DDG].RendicionesDetalle (
rendicionDetalle_id numeric(10,0) primary key identity,
rendicionDetalle_rendicion numeric(10,0) not null references [DDG].Rendiciones
)
GO

create table [DDG].Viajes (
viaje_id numeric(18,0) primary key identity,
viaje_chofer numeric(10,0) not null references [DDG].Choferes,
viaje_auto numeric(10,0) not null references [DDG].Autos,
viaje_turno numeric(10,0) not null references [DDG].Turnos,
viaje_cliente numeric(10,0) not null references [DDG].Clientes,
viaje_rendicion numeric(10,0) references [DDG].RendicionesDetalle,
viaje_factura numeric(18,0) references [DDG].FacturasDetalle,
viaje_cantidad_km numeric(5,0) not null,
viaje_fecha_viaje datetime not null,
viaje_hora_inicio time /*not null*/,
viaje_hora_fin time /*not null*/		/*Datos en la base no tienen estos campos*/
)
GO




												/* Carga de datos*/

					/*Roles*/
insert into [DDG].Roles (rol_nombre) values
('Administrativo'), 
('Chofer'), 
('Cliente');

					/*Funcionalidades*/
insert into DDG.Funcionalidades (funcionalidad_descripcion) values
('ABM de Rol'),
('Registro de usuarios'),
('ABM de Clientes'),
('ABM de Automoviles'),
('ABM de turnos'),
('ABM de choferes'),
('Registro de viajes'),
('Rendicion de viajes'),
('Facturacion de clientes'),
('Listado estadistico');

					/*RolesXFuncionalidades*/
insert into [DDG].RolesXFuncionalidades (rolXFuncionalidad_rol, rolXFuncionalidad_funcionalidad) values
(1,1), (1,2), (1,3), (1,4),(1,5),(1,6),(1,7),(2,8),(3,9),(1,10),(2,10),(3,10);

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

					/*Clientes*/
insert into DDG.Clientes (cliente_nombre, cliente_apellido,cliente_dni, cliente_telefono,cliente_direccion,cliente_email,cliente_fecha_nacimiento, cliente_usuario)
select distinct m.Cliente_Nombre, m.Cliente_Apellido, m.Cliente_Dni, m.Cliente_Telefono, m.Cliente_Direccion, m.Cliente_Mail, m.Cliente_Fecha_Nac, u.usuario_ID
from gd_esquema.Maestra m, DDG.Usuarios u
where  cast( m.Cliente_Dni as varchar(255)) = u.usuario_username
order by usuario_ID

					/*Choferes*/
insert into DDG.Choferes(chofer_nombre, chofer_apellido,chofer_dni, chofer_telefono,chofer_direccion,chofer_email,chofer_fecha_nacimiento, chofer_usuario)
select distinct m.chofer_Nombre, m.chofer_Apellido, m.chofer_Dni, m.chofer_Telefono, m.chofer_Direccion, m.chofer_Mail, m.chofer_Fecha_Nac, u.usuario_ID
from gd_esquema.Maestra m, DDG.Usuarios u
where  cast( m.chofer_Dni as varchar(255)) = u.usuario_username
order by usuario_ID

					/*UsuariosXRoles*/
/*usuariosXClientes*/
insert into [DDG].UsuariosXRoles( usuarioXRol_usuario, usuarioXRol_rol)
select distinct u.usuario_ID, r.rol_ID
from DDG.Usuarios u, DDG.Clientes c, DDG.Roles r
where u.usuario_username = cast(c.cliente_dni as varchar(255))
and r.rol_nombre = ('Cliente')

/*usuariosXChoferes*/
insert into [DDG].UsuariosXRoles( usuarioXRol_usuario, usuarioXRol_rol)
select distinct u.usuario_ID, r.rol_ID
from DDG.Usuarios u, DDG.Choferes c, DDG.Roles r
where u.usuario_username = cast(c.chofer_dni as varchar(255))
and r.rol_nombre = ('Chofer')

					/*Turnos*/
insert into DDG.Turnos(turno_descripcion, turno_hora_fin, turno_hora_inicio, turno_precio_base, turno_valor_km)
select distinct Turno_Descripcion, Turno_Hora_Fin, Turno_Hora_Inicio, Turno_Precio_Base, Turno_Valor_Kilometro
from gd_esquema.Maestra
order by Turno_Hora_Inicio

/*Sobreescribo descripcion turno mañana porque está mal escrita*/
update DDG.Turnos
set turno_descripcion = 'Turno Mañana'
where turno_descripcion = 'Turno Mañna'

					/*Porcentajes*/
insert into [DDG].Porcentajes (porcentaje_fecha, porcentaje_valor)
values(convert(date, getDate()), 30)

					/*Rendiciones*/  
insert into [DDG].Rendiciones  ( rendicion_chofer, rendicion_fecha, rendicion_importe, rendicion_numero, rendicion_turno, rendicion_porcentaje)
select distinct c.chofer_id, m.Rendicion_Fecha, sum(m.Rendicion_Importe), m.Rendicion_Nro, t.turno_id, 1
from gd_esquema.Maestra m, DDG.Choferes c, DDG.Turnos t
where m.Rendicion_Fecha is not null
and m.Chofer_Dni = c.chofer_dni
and m.Turno_Hora_Inicio = t.turno_hora_inicio
group by Rendicion_Nro, c.chofer_id, t.turno_id, m.Rendicion_Fecha
order by Rendicion_Nro

					/*RendicionesDetalle*/
insert into [DDG].RendicionesDetalle (rendicionDetalle_rendicion)
select distinct r.rendicion_id
from [DDG].Rendiciones r


					/*Marcas*/
insert into [DDG].Marcas (marca_descripcion)
select distinct Auto_Marca
from gd_esquema.Maestra

					/*Modelos*/
insert into [DDG].Modelos (modelo_descripcion, modelo_marca)
select distinct m.Auto_Modelo, ma.marca_id
from gd_esquema.Maestra m, [DDG].Marcas ma
where m.Auto_Marca = ma.marca_descripcion

					/*Autos*/
insert into DDG.Autos (auto_licencia, auto_modelo, auto_patente, auto_rodado, auto_chofer)
select distinct m.Auto_Licencia, mo.modelo_id, m.Auto_Patente, m.Auto_Rodado, c.chofer_id
from gd_esquema.Maestra m, DDG.Choferes c, [DDG].Modelos mo
where m.Auto_Patente is not null
and m.Chofer_Dni = c.chofer_dni
and m.Auto_Modelo = mo.modelo_descripcion

					/*AutosXTurnos*/
insert into DDG.AutosXTurnos (autoXTurno_auto, autoXTurno_turno)
select distinct  a.auto_id, t.turno_id
from gd_esquema.Maestra m, DDG.Autos a, ddg.Turnos t
where m.Auto_Patente = a.auto_patente
and m.Turno_Hora_Inicio = t.turno_hora_inicio

					/*Facturas*/
insert into DDG.Facturas (factura_cliente, factura_fecha_inicio, factura_fecha_fin, factura_numero, factura_importe)
select distinct c.cliente_id, m.Factura_Fecha_Inicio, m.Factura_Fecha_Fin, m.Factura_Nro, ( select sum(m2.Turno_Precio_Base + ( m2.Viaje_Cant_Kilometros * m2.Turno_Valor_Kilometro))   
																							 from gd_esquema.Maestra m2
																							where m2.Factura_Nro = m.Factura_Nro)
from DDG.Clientes c, gd_esquema.Maestra m
where Factura_Nro is not null
and c.cliente_dni = m.Cliente_Dni
order by Factura_Nro

					/*FacturasDetalle*/
insert into [DDG].FacturasDetalle(facturaDetalle_factura)
select distinct f.factura_id
from [DDG].Facturas f

					/*Viajes*/
insert into DDG.Viajes (viaje_auto, viaje_chofer, viaje_cliente, viaje_rendicion, viaje_turno, viaje_cantidad_km, viaje_fecha_viaje, viaje_factura)
select distinct  a.auto_id, ch.chofer_id, cl.cliente_id, rd.rendicionDetalle_rendicion, t.turno_id, m.Viaje_Cant_Kilometros, m.Viaje_Fecha, fd.facturaDetalle_factura
from ddg.Autos a, DDG.Choferes ch, DDG.Clientes cl, DDG.Rendiciones r, DDG.Turnos t, gd_esquema.Maestra m, gd_esquema.Maestra m2, DDG.Facturas f, DDG.FacturasDetalle fd, DDG.RendicionesDetalle rd
where m.Viaje_Cant_Kilometros is not null
and m.Auto_Patente = a.auto_patente
and m.Chofer_Dni = ch.chofer_dni
and m.Cliente_Dni = cl.cliente_dni
and m.Rendicion_Nro = r.rendicion_numero
and m.Turno_Hora_Inicio = t.turno_hora_inicio
and m.Chofer_Dni = m2.Chofer_Dni
and m.Cliente_Dni = m2.Cliente_Dni
and m.Viaje_Fecha = m2.Viaje_Fecha
and m2.Factura_Nro = f.factura_numero
and f.factura_id = fd.facturaDetalle_factura
and r.rendicion_id = rd.rendicionDetalle_rendicion
order by m.Viaje_Fecha