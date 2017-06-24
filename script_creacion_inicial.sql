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
rol_nombre varchar(255) not null unique,
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
porcentaje_valor numeric(10,4) not null,
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
(1,1), (1,2), (1,3), (1,4),(1,5),(1,6),(1,7),(1,8),(1,9),(2,9),(3,9);

					/*Usuarios*/
/*Usuario pedido*/
insert into DDG.Usuarios (usuario_username, usuario_password) values
('admin',HASHBYTES('SHA2_256','w23e'))

insert into ddg.UsuariosXRoles (usuarioXRol_usuario, usuarioXRol_rol) values
(1,1)

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

/*Sobreescribo descripcion turno ma�ana porque est� mal escrita*/
update DDG.Turnos
set turno_descripcion = 'Turno Ma�ana'
where turno_descripcion = 'Turno Ma�na'

					/*Porcentajes*/
insert into [DDG].Porcentajes (porcentaje_fecha, porcentaje_valor)
values(convert(date, getDate()), 0.30)

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



													/*Listados estadisticos*/


--=============================================================================================================
--TIPO		: Stored procedure
--NOMBRE	: sp_get_choferes_con_mayor_recaudacion
--OBJETIVO  : obtener choferes con mayor recaudacion dado un a�o y un trimestre                                   
--=============================================================================================================

IF EXISTS (SELECT name FROM sysobjects WHERE name='sp_get_choferes_con_mayor_recaudacion' AND type='p')
	DROP PROCEDURE [DDG].sp_get_choferes_con_mayor_recaudacion
GO

create procedure [DDG].[sp_get_choferes_con_mayor_recaudacion] (@a�o int, @trimestre int)
as

begin
select top 5 c.*, isnull(sum(r.rendicion_importe),0) as cantidad_recaudada
from DDG.Choferes c left join DDG.Rendiciones r on c.chofer_id = r.rendicion_chofer
where year(r.rendicion_fecha) = @a�o
and DDG.getTrimestre(month(r.rendicion_fecha)) = @trimestre
group by c.chofer_apellido,c.chofer_direccion,c.chofer_dni,c.chofer_email,c.chofer_fecha_nacimiento,c.chofer_fecha_nacimiento,c.chofer_habilitado,c.chofer_id,c.chofer_nombre,c.chofer_telefono,c.chofer_usuario
order by isnull(sum(r.rendicion_importe),0) desc
end

GO


--=============================================================================================================
--TIPO		: Stored procedure
--NOMBRE	: sp_get_choferes_con_viaje_mas_largo
--OBJETIVO  : obtener choferes con viajes mas largos dado un a�o y un trimestre                                   
--=============================================================================================================

IF EXISTS (SELECT name FROM sysobjects WHERE name='sp_get_choferes_con_viaje_mas_largo' AND type='p')
	DROP PROCEDURE [DDG].sp_get_choferes_con_viaje_mas_largo
GO

create procedure [DDG].[sp_get_choferes_con_viaje_mas_largo] (@a�o int, @trimestre int)
as

begin
select top 5 c.*, isnull(sum(v.viaje_cantidad_km),0) as cantidad_de_km
from DDG.Choferes c  left join DDG.Viajes v on c.chofer_id = v.viaje_chofer
where year(v.viaje_fecha_viaje) = @a�o
and DDG.getTrimestre(month(v.viaje_fecha_viaje)) = @trimestre
group by c.chofer_apellido,c.chofer_direccion,c.chofer_dni,c.chofer_email,c.chofer_fecha_nacimiento,c.chofer_fecha_nacimiento,c.chofer_habilitado,c.chofer_id,c.chofer_nombre,c.chofer_telefono,c.chofer_usuario
order by isnull(sum(v.viaje_cantidad_km),0) desc
end

GO


--=============================================================================================================
--TIPO		: Stored procedure
--NOMBRE	: sp_get_clientes_con_mayor_consumo
--OBJETIVO  : obtener clientes con mayor consumo dado un a�o y un trimestre                                   
--=============================================================================================================

IF EXISTS (SELECT name FROM sysobjects WHERE name='sp_get_clientes_con_mayor_consumo' AND type='p')
	DROP PROCEDURE [DDG].sp_get_clientes_con_mayor_consumo
GO

create procedure [DDG].[sp_get_clientes_con_mayor_consumo] (@a�o int, @trimestre int)
as

begin
select top 5 c.*, isnull(sum(f.factura_importe),0) as importe_total
from DDG.Clientes c  left join DDG.Facturas f on c.cliente_id = f.factura_cliente
where year(f.factura_fecha_inicio) = @a�o
and DDG.getTrimestre(month(f.factura_fecha_inicio)) = @trimestre
group by c.cliente_apellido,c.cliente_codigo_postal,c.cliente_direccion,c.cliente_dni,c.cliente_email,c.cliente_fecha_nacimiento,c.cliente_habilitado,c.cliente_id,c.cliente_nombre,c.cliente_telefono,c.cliente_usuario
order by isnull(sum(f.factura_importe),0) desc
end

GO


--=============================================================================================================
--TIPO		: Stored procedure
--NOMBRE	: sp_get_clientes_mayor_uso_mismo_auto
--OBJETIVO  : obtener clientes con mayor uso de un mismo automovil dado un a�o y un trimestre                                   
--=============================================================================================================

IF EXISTS (SELECT name FROM sysobjects WHERE name='sp_get_clientes_mayor_uso_mismo_auto' AND type='p')
	DROP PROCEDURE [DDG].sp_get_clientes_mayor_uso_mismo_auto
GO

create procedure [DDG].[sp_get_clientes_mayor_uso_mismo_auto] (@a�o int, @trimestre int)
as

begin
select top 5 c.*, a.*, isnull(count(a.auto_id),0) as cantidad_veces_utilizado
from DDG.Clientes c  left join Viajes v on c.cliente_id = v.viaje_cliente
left join DDG.Autos a on v.viaje_auto = a.auto_id
where year(v.viaje_fecha_viaje) = @a�o
and DDG.getTrimestre(month(v.viaje_fecha_viaje)) = @trimestre
group by c.cliente_apellido,c.cliente_codigo_postal,c.cliente_direccion,c.cliente_dni,c.cliente_email,c.cliente_fecha_nacimiento,c.cliente_habilitado,c.cliente_id,c.cliente_nombre,c.cliente_telefono,c.cliente_usuario,a.auto_chofer,a.auto_habilitado,a.auto_id,a.auto_licencia,a.auto_modelo,a.auto_patente,a.auto_patente,a.auto_rodado
order by isnull(count(a.auto_id),0) desc
end

GO



													/*Triggers*/


--=============================================================================================================
--TIPO		: Trigger
--NOMBRE	: tr_baja_rol						
--OBJETIVO  : al dar de baja un rol se da de baja la relacion de usuarios con ese rol                                 
--=============================================================================================================
IF EXISTS (SELECT name FROM sysobjects WHERE name='tr_baja_rol')
DROP TRIGGER tr_baja_rol
GO

create trigger [DDG].tr_baja_rol on [DDG].Roles for update
as
begin
if UPDATE(rol_habilitado)
	delete from [DDG].UsuariosXRoles
	where usuarioXRol_rol in (select i.rol_ID
							  from inserted i
							  where i.rol_habilitado = 0)
end

													/* Stored procedures*/
	/*ABM ROL*/

--=============================================================================================================
--TIPO		: Stored procedure
--NOMBRE	: sp_alta_rol						------------TODO falta pasarle la lista de funcionalidades---------------
--OBJETIVO  : dar de alta un rol                                 
--=============================================================================================================
IF EXISTS (SELECT name FROM sysobjects WHERE name='sp_alta_rol' AND type='p')
	DROP PROCEDURE [DDG].sp_alta_rol
GO

create procedure [DDG].sp_alta_rol (@nombre varchar(255), @habilitado  bit)
as
begin

insert into DDG.Roles (rol_nombre, rol_habilitado)
values(@nombre, @habilitado)

end
GO


--=============================================================================================================
--TIPO		: Stored procedure
--NOMBRE	: sp_baja_rol						
--OBJETIVO  : dar de baja un rol       (se puede usar este SP o el de update)                          
--=============================================================================================================
IF EXISTS (SELECT name FROM sysobjects WHERE name='sp_baja_rol' AND type='p')
	DROP PROCEDURE [DDG].sp_baja_rol
GO

create procedure [DDG].sp_baja_rol (@id numeric(10,0))
as
begin

update DDG.Roles 
set rol_habilitado = 0
where rol_ID = @id

end
GO

--=============================================================================================================
--TIPO		: Stored procedure
--NOMBRE	: sp_update_rol							------------TODO falta pasarle la lista de funcionalidades---------------
--OBJETIVO  : modificar un rol existente     (tambien sirve para la baja logica)                           
--=============================================================================================================
IF EXISTS (SELECT name FROM sysobjects WHERE name='sp_update_rol' AND type='p')
	DROP PROCEDURE [DDG].sp_update_rol
GO											

create procedure [DDG].sp_update_rol (@id numeric(10,0), @nombre varchar(255), @habilitado bit)	
as
begin

update DDG.Roles
set rol_nombre = @nombre, rol_habilitado = @habilitado
where rol_ID = @id

end
GO												

--=============================================================================================================
--TIPO		: Stored procedure
--NOMBRE	: sp_get_roles_habilitados
--OBJETIVO  : get de roles habilitados                          
--=============================================================================================================
IF EXISTS (SELECT name FROM sysobjects WHERE name='sp_get_roles_habilitados' AND type='p')
	DROP PROCEDURE [DDG].sp_get_roles_habilitados
GO	

create procedure [DDG].sp_get_roles_habilitados
as
begin

select * 
from Roles
where rol_habilitado = 1

end
GO

--=============================================================================================================
--TIPO		: Stored procedure
--NOMBRE	: sp_get_roles
--OBJETIVO  : get de roles (habilitados o no)                         
--=============================================================================================================
IF EXISTS (SELECT name FROM sysobjects WHERE name='sp_get_roles' AND type='p')
	DROP PROCEDURE [DDG].sp_get_roles
GO	

create procedure [DDG].sp_get_roles
as
begin

select * 
from Roles

end
GO



--=============================================================================================================
--TIPO          : Stored procedure
--NOMBRE        : sp_limpiar_intentos_fallidos
--OBJETIVO  : intentos fallidos a 0                     
--============================================================================================================= 
 IF EXISTS (SELECT name FROM sysobjects WHERE name='sp_limpiar_intentos_fallidos' AND type='p')
        DROP PROCEDURE [DDG].sp_limpiar_intentos_fallidos
GO

create procedure [DDG].sp_limpiar_intentos_fallidos (@username varchar(255))
as
begin

update DDG.Usuarios set usuario_intentosFallidos = 0
where usuario_username = @username

end
GO



--=============================================================================================================
--TIPO		: Stored procedure
--NOMBRE	: sp_incrementar_intentos_fallidos
--OBJETIVO  : incrementa intentos fallidos para un usuario                      
--=============================================================================================================
 IF EXISTS (SELECT name FROM sysobjects WHERE name='sp_incrementar_intentos_fallidos' AND type='p')
	DROP PROCEDURE [DDG].sp_incrementar_intentos_fallidos
GO

create procedure [DDG].sp_incrementar_intentos_fallidos (@username varchar(255))
as
begin

update  DDG.Usuarios set usuario_intentosFallidos = (usuario_intentosFallidos + 1)
where usuario_username = @username

end
GO



--=============================================================================================================
--TIPO		: Stored procedure
--NOMBRE	: sp_login_check
--OBJETIVO  : checkeo login correcto (chequea intentos fallidos)  
--output: -1: si no existe usuario, -2: contrase�a incorrecta (incrementa intentos fallidos), id: login correcto (resetea intentos fallidos), -3:usuario bloqueado                     
--=============================================================================================================
 IF EXISTS (SELECT name FROM sysobjects WHERE name='sp_login_check' AND type='p')
	DROP PROCEDURE [DDG].sp_login_check
GO	

create procedure [DDG].sp_login_check(@username varchar (255), @contrasenia varchar(255), @retorno int output)
as
begin

 if (DDG.existeUsuario(@username)) = 0 set @retorno = -1
	else
	begin
	if(DDG.usuarioActivo(@username) = 0) set @retorno = -3
		else
		if(select usuario_password
		from DDG.Usuarios
		where usuario_username = @username) = HASHBYTES('SHA2_256',cast(@contrasenia as varchar(255)))begin  set @retorno = (select u.usuario_ID  from Usuarios u where u.usuario_username = @username) exec DDG.sp_limpiar_intentos_fallidos @username end
			else 
			begin
			set @retorno=-2
			exec [DDG].sp_incrementar_intentos_fallidos @username 
			end
		end
	return @retorno

end
GO


			

--=============================================================================================================
--TIPO		: Stored procedure
--NOMBRE	: sp_get_roles_usuario
--OBJETIVO  : get roles de usuario hablitados                    
--=============================================================================================================	
 IF EXISTS (SELECT name FROM sysobjects WHERE name='sp_get_roles_usuario' AND type='p')
	DROP PROCEDURE [DDG].sp_get_roles_usuario
GO

create procedure [DDG].sp_get_roles_usuario (@idUsuario numeric (10,0))	
as
begin

select r.*
from Usuarios u, UsuariosXRoles ur, Roles r
where u.usuario_ID = @idUsuario
and u.usuario_ID = ur.usuarioXRol_usuario
and ur.usuarioXRol_rol = r.rol_ID
and r.rol_habilitado = 1 	

end
GO		
									
													/*Funciones*/

--=============================================================================================================
--TIPO		: Funcion
--NOMBRE	: existeUsuario
--OBJETIVO  : determinar si existe un usuario en el sistema                                   
--=============================================================================================================
IF EXISTS (SELECT name FROM sysobjects WHERE name='existeUsuario' AND type in ( N'FN', N'IF', N'TF', N'FS', N'FT' ))
DROP FUNCTION [ddg].existeUsuario
GO

create function [DDG].existeUsuario(@username varchar(255))
returns bit
begin
declare @retorno bit

if((select count(*)
	from DDG.Usuarios
	where usuario_username = @username) > 0) set @retorno = 1 else set @retorno = 0
return @retorno

end
GO

--=============================================================================================================
--TIPO		: Funcion
--NOMBRE	: usuarioActivo
--OBJETIVO  : comprueba que el usuario tenga intentos restante para el login                                  
--=============================================================================================================
IF EXISTS (SELECT name FROM sysobjects WHERE name='usuarioActivo' AND type in ( N'FN', N'IF', N'TF', N'FS', N'FT' ))
DROP FUNCTION [ddg].usuarioActivo
GO

create function [DDG].usuarioActivo (@username varchar(255))
returns bit
begin
declare @retorno bit

if((select usuario_intentosFallidos
	from Usuarios
	where usuario_username = @username) < 3) set @retorno = 1 else set @retorno = 0

return @retorno
end
GO

--=============================================================================================================
--TIPO		: Funcion
--NOMBRE	: getTrimestre
--OBJETIVO  : obtener trimestre dado un mes                                    
--=============================================================================================================
IF EXISTS (SELECT name FROM sysobjects WHERE name='getTrimestre' AND type in ( N'FN', N'IF', N'TF', N'FS', N'FT' ))
DROP FUNCTION [ddg].getTrimestre
GO

create function [DDG].getTrimestre (@mes int)
returns int
begin
declare @retorno int

if (@mes between 1 and 3) set @retorno = 1 
if (@mes between 4 and 6) set @retorno = 2
if (@mes between 7 and 9) set @retorno = 3
if (@mes between 10 and 12) set @retorno = 4

return @retorno
end

GO



--=============================================================================================================
--TIPO		: Funcion
--NOMBRE	: choferYaAsignado
--OBJETIVO  : verificar si un chofer ya esta asignado a un automovil habilitado                                    
--=============================================================================================================

IF EXISTS (SELECT name FROM sysobjects WHERE name='choferYaAsignado' AND type in ( N'FN', N'IF', N'TF', N'FS', N'FT' ))
DROP FUNCTION [ddg].choferYaAsignado
GO

create function [DDG].choferYaAsignado(@idchofer numeric(10,0))
returns bit
begin
declare @retorno bit

if	((select count(*)
	from DDG.Autos
	where auto_chofer = @idchofer
	and auto_habilitado = 1) > 0)

	set @retorno = 1

else
	set @retorno = 0

return @retorno

end
GO

--=============================================================================================================
--TIPO		: Funcion
--NOMBRE	: calcularimporteViaje
--OBJETIVO  : calcula el importe de un viaje                                    
--=============================================================================================================
IF EXISTS (SELECT name FROM sysobjects WHERE name='calcularimporteViaje' AND type in ( N'FN', N'IF', N'TF', N'FS', N'FT' ))
DROP FUNCTION [ddg].calcularimporteViaje
GO

create function [DDG].calcularimporteViaje(@idViaje numeric(10,0))
	returns float
begin
declare @retorno float

set @retorno = (select( turno_precio_base + (turno_valor_km * viaje_cantidad_km))
				from viajes, turnos
				where viaje_id = @idViaje
				and viaje_turno = turno_id)

return @retorno
end
GO

/* Alta Usuario */

--=============================================================================================================
--TIPO		: Stored procedure
--NOMBRE	: sp_alta_usuario
--OBJETIVO  : dar de alta un usuario                                 
--=============================================================================================================
IF EXISTS (SELECT name FROM sysobjects WHERE name='sp_alta_usuario' AND type='p')
	DROP PROCEDURE [DDG].sp_alta_usuario
GO

create procedure [DDG].sp_alta_usuario (@username varchar(255), @contrasenia varchar(255))
as
begin

insert into DDG.Usuarios (usuario_username, usuario_password)
values(@username, HASHBYTES('SHA2_256',cast(@contrasenia as varchar(16))))

end
GO

/* Fin alta usuario */



/* ABM Cliente */

--=============================================================================================================
--TIPO		: Stored procedure
--NOMBRE	: sp_alta_cliente						
--OBJETIVO  : dar de alta un cliente                              
--=============================================================================================================
IF EXISTS (SELECT name FROM sysobjects WHERE name='sp_alta_cliente' AND type='p')
	DROP PROCEDURE [DDG].sp_alta_cliente
GO

create procedure [DDG].sp_alta_cliente (@nombre varchar(250), @apellido varchar(250), @fechanac date, @dni numeric(10,0), @direccion varchar(250),@codpost numeric(18,0), @telefono numeric(18,0), @email varchar(250))
as
begin
	declare @usuario varchar(255)
	declare @contrase�a varchar(255)
	set @usuario =   convert(varchar(255), @dni)
	set @contrase�a =   convert(varchar(255), @dni)

	exec [DDG].sp_alta_usuario @usuario, @contrase�a

	insert into DDG.Clientes(cliente_usuario,cliente_nombre,cliente_apellido,cliente_fecha_nacimiento,cliente_dni,cliente_direccion,cliente_codigo_postal,cliente_telefono,cliente_email)
	values((select usuario_id from ddg.usuarios where usuario_username=@dni), @nombre, @apellido, @fechanac, @dni, @direccion, @codpost, @telefono, @email)

end
GO




--=============================================================================================================
--TIPO		: Stored procedure
--NOMBRE	: sp_update_cliente
--OBJETIVO  : modificar datos de un cliente                                 
--=============================================================================================================
IF EXISTS (SELECT name FROM sysobjects WHERE name='sp_update_cliente' AND type='p')
	DROP PROCEDURE [DDG].sp_update_cliente
GO

create procedure [DDG].sp_update_cliente (@parametros varchar(900), @idcliente numeric(10,0)) as
begin
	declare @sql_statement nvarchar(1000)
	SET @sql_statement = 'update ddg.clientes set ' + @parametros + ' where cliente_id = ' + @idcliente
	exec sp_executesql @sql_statement
end
GO





--=============================================================================================================
--TIPO		: Stored procedure
--NOMBRE	: sp_baja_cliente
--OBJETIVO  : dar de baja (logica) a un cliente                                 
--=============================================================================================================
IF EXISTS (SELECT name FROM sysobjects WHERE name='sp_baja_cliente' AND type='p')
	DROP PROCEDURE [DDG].sp_baja_cliente
GO

create procedure [DDG].sp_baja_cliente (@idcliente numeric(10,0)) as
begin
	update ddg.clientes
	set cliente_habilitado = 0
	where cliente_id = @idcliente
end
GO


/* Fin ABM Cliente */




/* ABM Automovil */

--=============================================================================================================
--TIPO		: Stored procedure
--NOMBRE	: sp_alta_automovil
--OBJETIVO  : dar de alta un automovil                                 
--=============================================================================================================
IF EXISTS (SELECT name FROM sysobjects WHERE name='sp_alta_automovil' AND type='p')
	DROP PROCEDURE [DDG].sp_alta_automovil
GO

create procedure [DDG].sp_alta_automovil (@idchofer numeric(10,0),@idmodelo numeric(10,0),@patente varchar(10),@licencia varchar(10),@rodado varchar(10))
as
begin

if (ddg.choferYaAsignado (@idchofer)=1)
	
	THROW 51000, 'El chofer ya esta asignado.', 1;														/*TODO un chofer puede  tener mas de un auto a la vez*/

else
	insert into DDG.Autos(auto_chofer,auto_modelo,auto_patente,auto_licencia,auto_rodado)
	values(@idchofer, @idmodelo, @patente, @licencia, @rodado)

end
GO




--=============================================================================================================
--TIPO		: Stored procedure
--NOMBRE	: sp_update_automovil
--OBJETIVO  : modificar datos de un automovil                                 
--=============================================================================================================
IF EXISTS (SELECT name FROM sysobjects WHERE name='sp_update_automovil' AND type='p')
	DROP PROCEDURE [DDG].sp_update_automovil
GO

create procedure [DDG].sp_update_automovil (@id numeric(10,0),@idchofer numeric(10,0),@idmodelo numeric(10,0),@patente varchar(10),@licencia varchar(10),@rodado varchar(10),@habilitado numeric(1,0)) as
begin
	
if (ddg.choferYaAsignado (@idchofer)=1)
	
	THROW 51000, 'El chofer ya esta asignado.', 1;													/*TODO un chofer puede  tener mas de un auto a la vez*/

else

	update 	ddg.autos
	set 	auto_chofer = @idchofer,
		auto_modelo = @idmodelo,
		auto_patente = @patente,
		auto_licencia = @licencia,
		auto_rodado = @rodado,
		auto_habilitado = @habilitado
	where	auto_id = @id;
end
GO




--=============================================================================================================
--TIPO		: Stored procedure
--NOMBRE	: sp_baja_automovil
--OBJETIVO  : dar de baja (logica) a un automovil                                 
--=============================================================================================================
IF EXISTS (SELECT name FROM sysobjects WHERE name='sp_baja_automovil' AND type='p')
	DROP PROCEDURE [DDG].sp_baja_automovil
GO

create procedure [DDG].sp_baja_automovil (@idauto numeric(10,0)) as
begin
	update ddg.autos
	set auto_habilitado = 0
	where auto_id = @idauto
end
GO


/* Fin ABM Automovil */


/* ABM Choferes */

--=============================================================================================================
--TIPO		: Stored procedure
--NOMBRE	: sp_alta_chofer	
--OBJETIVO  : dar de alta un chofer                               
--=============================================================================================================

IF EXISTS (SELECT name FROM sysobjects WHERE name='sp_alta_chofer' AND type='p')
	DROP PROCEDURE [DDG].sp_alta_chofer
GO

create procedure [DDG].sp_alta_chofer (@nombre varchar(250), @apellido varchar(250), @fechanac date, @dni numeric(10,0), @direccion varchar(250),@codpost numeric(18,0), @telefono numeric(18,0), @email varchar(250))
as
begin
	declare @usuario varchar(255)
	declare @contrase�a varchar(255)
	set @usuario =   convert(varchar(255), @dni)
	set @contrase�a =   convert(varchar(255), @dni)

	exec [DDG].sp_alta_usuario @usuario, @contrase�a

	insert into DDG.Choferes(chofer_usuario ,chofer_nombre ,chofer_apellido, chofer_fecha_nacimiento ,chofer_dni, chofer_direccion,chofer_telefono ,chofer_email)
	values((select usuario_id from ddg.usuarios where usuario_username=@dni), @nombre, @apellido, @fechanac, @dni, @direccion, @telefono, @email)

end
GO


--=============================================================================================================
--TIPO		: Stored procedure
--NOMBRE	: sp_update_chofer							
--OBJETIVO  : modificar datos de un chofer                              
--=============================================================================================================
/*Probar si funciona lo de mariano*/


--=============================================================================================================
--TIPO		: Stored procedure
--NOMBRE	: sp_baja_chofer							
--OBJETIVO  : eliminar chofer                             
--=============================================================================================================

IF EXISTS (SELECT name FROM sysobjects WHERE name='sp_baja_chofer' AND type='p')
	DROP PROCEDURE [DDG].sp_baja_chofer
GO

create procedure [DDG].sp_baja_chofer (@idchofer numeric(10,0)) as
begin
	update ddg.Choferes
	set chofer_habilitado = 0
	where chofer_id = @idchofer
end
GO

--=============================================================================================================
--TIPO		: Stored procedure
--NOMBRE	: sp_alta_viaje							
--OBJETIVO  : dar de alta un viaje                             
--=============================================================================================================

IF EXISTS (SELECT name FROM sysobjects WHERE name='sp_alta_viaje' AND type='p')
	DROP PROCEDURE [DDG].sp_alta_viaje
GO

create procedure [ddg].sp_alta_viaje (@idChofer numeric(10,0), @idAuto numeric(10,0), @idTurno numeric(10,0), @idCliente numeric(10,0), @cantKM numeric(5,0), @horaIn time(7) , @horaFin time(7)) as
begin
	insert into ddg.viajes(viaje_chofer, viaje_auto, viaje_turno, viaje_cliente, viaje_cantidad_km, viaje_hora_inicio, viaje_hora_fin) 
	values (@idChofer, @idAuto, @idTurno, @idCliente, @cantKM, @horaIn , @horaFin)
end
GO

--=============================================================================================================
--TIPO		: Stored procedure
--NOMBRE	: sp_obtenerPorcentajeActual						
--OBJETIVO  : Obtener ultima actualizacion de porcentaje de pago a choferes                            
--=============================================================================================================
IF EXISTS (SELECT name FROM sysobjects WHERE name='sp_obtenerPorcentajeActual' AND type='p')
	DROP PROCEDURE [DDG].sp_obtenerPorcentajeActual
GO

create procedure [DDG].sp_obtenerPorcentajeActual as
begin
	select top 1 porcentaje_valor
	from [ddg].Porcentajes
	order by porcentaje_id desc
end
GO


--=============================================================================================================
--TIPO		: Stored procedure				(TODO podria devolver el id para que sea mas facil buscar los viajes despues)
--NOMBRE	: sp_alta_rendicion																												
--OBJETIVO  : pagar a un chofer los viajes de un dia particular (dar de alta una rendicion de un dia y actualizar los viajes con esa rendicion)                            
--=============================================================================================================
IF EXISTS (SELECT name FROM sysobjects WHERE name='sp_alta_rendicion' AND type='p')
	DROP PROCEDURE [DDG].sp_alta_rendicion
GO

create procedure [ddg].sp_alta_rendicion (@idChofer numeric(10,0), @fecha date, @idTurno numeric(10,0)) as
begin
declare @idRendicion int

	insert into ddg.rendiciones (rendicion_importe, rendicion_fecha, rendicion_chofer, rendicion_turno, rendicion_porcentaje)
		values( ((select sum([DDG].calcularImporteViaje(viaje_id))
					from [ddg].viajes
					where viaje_chofer = @idchofer
					and viaje_fecha_viaje = @fecha
					and viaje_turno = @idTurno) * (select top 1 porcentaje_valor from [ddg].Porcentajes order by porcentaje_id desc)) , @fecha, @idchofer, @idTurno,  (select max(porcentaje_id) from DDG.Porcentajes))
	
	set @idRendicion = ((select rendicion_id from DDG.Rendiciones where rendicion_chofer= @idChofer and rendicion_fecha = @fecha))

	insert into DDG.RendicionesDetalle (rendicionDetalle_rendicion)
	values (@idRendicion)

	update DDG.Viajes
	set viaje_rendicion = @idRendicion
	where viaje_chofer = @idChofer and viaje_fecha_viaje = @fecha and viaje_turno = @idTurno

end
GO

--=============================================================================================================
--TIPO		: Stored procedure						(TODO podria devolver el id para que sea mas facil buscar los viajes despues)
--NOMBRE	: sp_alta_factura																												
--OBJETIVO  : facturar desde una fecha a otra (dar de alta la factura y actualizar los viajes)                            
--=============================================================================================================
IF EXISTS (SELECT name FROM sysobjects WHERE name='sp_alta_factura' AND type='p')
	DROP PROCEDURE [DDG].sp_alta_factura
GO

create procedure [ddg].sp_alta_factura (@idCliente numeric(10,0), @fechaDesde date, @fechaHasta date) as
begin
declare @idfactura int

	insert into ddg.Facturas(factura_importe, factura_cliente, factura_fecha_fin, factura_fecha_inicio, factura_numero)
		values( ((select sum([DDG].calcularImporteViaje(viaje_id))
					from [ddg].viajes
					where viaje_cliente = @idCliente
					and viaje_fecha_viaje between @fechaDesde and @fechaHasta)) , @idCliente, @fechaHasta, @fechaDesde,  (select max(factura_numero) + 1 from DDG.Facturas))
	
	set @idfactura = ((select factura_id from DDG.Facturas where factura_cliente = @idCliente and factura_fecha_inicio = @fechaDesde and factura_fecha_fin = @fechaHasta))

	insert into DDG.FacturasDetalle(facturaDetalle_factura)
	values (@idfactura)

	update DDG.Viajes
	set viaje_factura = @idfactura
	where viaje_cliente = @idCliente and viaje_fecha_viaje between @fechaDesde and @fechaHasta

end
GO

--=============================================================================================================
--TIPO		: funcion
--NOMBRE	: sp_get_importe_rendicion						
--OBJETIVO  : calcula el importe total de una rendicion                           
--=============================================================================================================
IF EXISTS (SELECT name FROM sysobjects WHERE name='sp_get_importe_rendicion' AND type='p')
	DROP PROCEDURE [DDG].sp_get_importe_rendicion
GO

create procedure [ddg].sp_get_importe_rendicion (@idRendicion numeric(10,0)) as
begin
		select rendicion_importe
		from ddg.rendiciones
		where rendicion_id = @idRendicion
end
GO


--=============================================================================================================
--TIPO		: Stored procedure
--NOMBRE	: sp_get_funcionalidades_rol					
--OBJETIVO  : Obtener funcionalidades de un rol en particular                         
--=============================================================================================================

IF EXISTS (SELECT name FROM sysobjects WHERE name='sp_get_funcionalidades_rol' AND type='p')
	DROP PROCEDURE [DDG].sp_get_funcionalidades_rol
GO

create procedure [DDG].sp_get_funcionalidades_rol(@idRol numeric(10,0)) as
begin
	select f.*
	from ddg.funcionalidades f, ddg.RolesXFuncionalidades rf
	where @idRol = rf.rolXFuncionalidad_rol
	and rf.rolXFuncionalidad_funcionalidad = f.funcionalidad_ID
end
GO

--=============================================================================================================
--TIPO		: Stored procedure
--NOMBRE	: sp_get_funcionalidades					
--OBJETIVO  : Obtener todas las funcionalidades                       
--============================================================================================================= 

IF EXISTS (SELECT name FROM sysobjects WHERE name='sp_get_funcionalidades' AND type='p')
	DROP PROCEDURE [DDG].sp_get_funcionalidades
GO

create procedure [DDG].sp_get_funcionalidades as
begin
	select * 
	from ddg.Funcionalidades
end
GO

--=============================================================================================================
--TIPO		: Stored procedure
--NOMBRE	: sp_get_marcas				
--OBJETIVO  : Obtener todas las marcas de auto                  
--============================================================================================================= 
IF EXISTS (SELECT name FROM sysobjects WHERE name='sp_get_marcas' AND type='p')
	DROP PROCEDURE [DDG].sp_get_marcas
GO

create procedure [DDG].sp_get_marcas as
begin
	select *
	from ddg.marcas
end
GO

--=============================================================================================================
--TIPO		: Stored procedure
--NOMBRE	: sp_get_modelos			
--OBJETIVO  : Obtener todas los modelos de auto                  
--============================================================================================================= 
IF EXISTS (SELECT name FROM sysobjects WHERE name='sp_get_modelos' AND type='p')
	DROP PROCEDURE [DDG].sp_get_modelos
GO

create procedure [DDG].sp_get_modelos as
begin
	select *
	from ddg.modelos
end
GO

--=============================================================================================================
--TIPO		: Stored procedure
--NOMBRE	: sp_get_turnos_habilitados			
--OBJETIVO  : Obtener los turnos habilitados                 
--============================================================================================================= 
IF EXISTS (SELECT name FROM sysobjects WHERE name='sp_get_turnos_habilitados' AND type='p')
	DROP PROCEDURE [DDG].sp_get_turnos_habilitados
GO

create procedure [DDG].sp_get_turnos_habilitados as
begin
	select *
	from ddg.turnos
	where turno_habilitado = 1
end
GO

--=============================================================================================================
--TIPO		: Stored procedure
--NOMBRE	: sp_get_turnos_automovil		
--OBJETIVO  : Obtener los turnos habilitados                 
--============================================================================================================= 
IF EXISTS (SELECT name FROM sysobjects WHERE name='sp_get_turnos_automovil' AND type='p')
	DROP PROCEDURE [DDG].sp_get_turnos_automovil
GO

create procedure [DDG].sp_get_turnos_automovil(@idAuto numeric(10,0)) as
begin
	select t.*
	from turnos t, AutosXTurnos at
	where at.autoXTurno_auto = @idAuto
	and t.turno_id = at.autoXTurno_turno
end
GO

--=============================================================================================================
--TIPO		: Stored procedure
--NOMBRE	: sp_get_automoviles_chofer		
--OBJETIVO  : Obtener los autos de un chofer                 
--============================================================================================================= 
IF EXISTS (SELECT name FROM sysobjects WHERE name='sp_get_automoviles_chofer' AND type='p')
	DROP PROCEDURE [DDG].sp_get_automoviles_chofer
GO

create procedure [DDG].sp_get_automoviles_chofer(@idChofer numeric(10,0)) as
begin
	select *
	from ddg.autos
	where auto_chofer = @idChofer
end
GO

--=============================================================================================================
--TIPO		: funcion
--NOMBRE	: sp_get_importe_factura					
--OBJETIVO  : obtiene importe total de una factura                          
--=============================================================================================================
IF EXISTS (SELECT name FROM sysobjects WHERE name='sp_get_importe_factura' AND type='p')
	DROP PROCEDURE [DDG].sp_get_importe_factura
GO

create procedure [ddg].sp_get_importe_factura (@idFactura numeric(10,0)) as
begin
		select factura_importe
		from ddg.Facturas
		where factura_id = @idFactura
end
GO


--=============================================================================================================
--TIPO		: Stored procedure
--NOMBRE	: sp_get_viajes_rendicion																											
--OBJETIVO  : get viajes de una rendicion                           
--=============================================================================================================
IF EXISTS (SELECT name FROM sysobjects WHERE name='sp_get_viajes_rendicion' AND type='p')
	DROP PROCEDURE [DDG].sp_get_viajes_rendicion
GO

create procedure [ddg].sp_get_viajes_rendicion(@idRendicion numeric(10,0)) as
begin

select v.*, (ddg.calcularimporteViaje(v.viaje_id) * (select top 1 porcentaje_valor from [ddg].Porcentajes order by porcentaje_id desc))
from Viajes v, RendicionesDetalle rd
where rd.rendicionDetalle_rendicion = @idRendicion
and v.viaje_rendicion = rd.rendicionDetalle_id

end
GO


--=============================================================================================================
--TIPO		: Stored procedure
--NOMBRE	: sp_get_viajes_factura																										
--OBJETIVO  : get viajes de una factura                           
--=============================================================================================================
IF EXISTS (SELECT name FROM sysobjects WHERE name='sp_get_viajes_factura' AND type='p')
	DROP PROCEDURE [DDG].sp_get_viajes_factura
GO

create procedure [ddg].sp_get_viajes_factura(@idFactura numeric(10,0)) as
begin

select v.*, ddg.calcularimporteViaje(v.viaje_id)
from Viajes v, FacturasDetalle fd
where fd.facturaDetalle_factura = @idFactura
and v.viaje_factura = fd.facturaDetalle_id

end
GO