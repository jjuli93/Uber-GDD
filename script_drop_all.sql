use [GD1C2017]
go



-- Eliminacion de tablas

drop table [DDG].Viajes
drop table [DDG].RendicionesDetalle
drop table [DDG].Rendiciones
drop table [DDG].Porcentajes
drop table [DDG].AutosXTurnos
drop table [DDG].Autos
drop table [DDG].Modelos
drop table [DDG].Marcas
drop table [DDG].Turnos
drop table [DDG].FacturasDetalle
drop table [DDG].Facturas
drop table [DDG].Choferes
drop table [DDG].Clientes
drop table [DDG].UsuariosXRoles
drop table [DDG].Usuarios
drop table [DDG].RolesXFuncionalidades
drop table [DDG].Roles
drop table [DDG].Funcionalidades



-- Eliminacion de triggers

--DROP TRIGGER tr_baja_rol



-- Eliminacion de stored procedures

DROP PROCEDURE [DDG].sp_alta_rol
DROP PROCEDURE [DDG].sp_baja_rol
DROP PROCEDURE [DDG].sp_update_rol
DROP PROCEDURE [DDG].sp_get_roles_habilitados
DROP PROCEDURE [DDG].sp_get_roles
DROP PROCEDURE [DDG].sp_limpiar_intentos_fallidos
DROP PROCEDURE [DDG].sp_incrementar_intentos_fallidos
DROP PROCEDURE [DDG].sp_login_check
DROP PROCEDURE [DDG].sp_get_roles_usuario
DROP PROCEDURE [DDG].sp_get_choferes_con_mayor_recaudacion
DROP PROCEDURE [DDG].sp_get_choferes_con_viaje_mas_largo
DROP PROCEDURE [DDG].sp_get_clientes_con_mayor_consumo
DROP PROCEDURE [DDG].sp_get_clientes_mayor_uso_mismo_auto
DROP PROCEDURE [DDG].sp_alta_usuario
DROP PROCEDURE [DDG].sp_alta_cliente
DROP PROCEDURE [DDG].sp_update_cliente
DROP PROCEDURE [DDG].sp_baja_cliente



-- Eliminacion de funciones

DROP FUNCTION [ddg].existeUsuario
DROP FUNCTION [ddg].usuarioActivo
DROP FUNCTION [ddg].getTrimestre



-- Eliminacion del schema

drop schema DDG


