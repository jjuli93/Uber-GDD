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

/*Sobreescribo descripcion turno ma�ana porque est� mal escrita*/
update DDG.Turnos
set turno_descripcion = 'Turno Ma�ana'
where turno_descripcion = 'Turno Ma�na'

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

create procedure [DDG].sp_update_rol (@id numeric(10,0), @nombre varchar, @habilitado bit)	
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
--output: 0: si no existe usuario, 1: contrase�a incorrecta (incrementa intentos fallidos), 2: login correcto (resetea intentos fallidos), 3:usuario bloqueado                     
--=============================================================================================================
 IF EXISTS (SELECT name FROM sysobjects WHERE name='sp_login_check' AND type='p')
	DROP PROCEDURE [DDG].sp_login_check
GO	

create procedure [DDG].sp_login_check(@username varchar (255), @contrase�a varchar(255), @retorno int output)
as
begin

 if (DDG.existeUsuario(@username)) = 0 set @retorno = 0
	else
	begin
	if(DDG.usuarioActivo(@username) = 0) set @retorno = 3
		else
		if(select usuario_password
		from DDG.Usuarios
		where usuario_username = @username) = HASHBYTES('SHA2_256',cast(@contrase�a as varchar(255)))begin  set @retorno = 2 exec DDG.sp_limpiar_intentos_fallidos @username end
			else 
			begin
			set @retorno=1
			exec [DDG].sp_incrementar_intentos_fallidos @username 
			end
		end
	return @retorno

end
GO


			

--=============================================================================================================
--TIPO		: Stored procedure
--NOMBRE	: sp_get_roles_usuario
--OBJETIVO  : intentos fallidos a 0                     
--=============================================================================================================	
 IF EXISTS (SELECT name FROM sysobjects WHERE name='sp_get_roles_usuario' AND type='p')
	DROP PROCEDURE [DDG].sp_get_roles_usuario
GO

create procedure [DDG].sp_get_roles_usuario (@idUsuario numeric (10,0))	
as
begin

select r.*
from Usuarios u, UsuariosXRoles ur, Roles r
where u.usuario_ID = ur.usuarioXRol_usuario
and ur.usuarioXRol_rol = r.rol_ID 	

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
