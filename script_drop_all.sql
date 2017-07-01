use [GD1C2017]
go

-- Eliminacion de triggers

DROP TRIGGER [DDG].tr_baja_rol



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
DROP PROCEDURE [DDG].sp_alta_automovil
DROP PROCEDURE [DDG].sp_update_automovil
DROP PROCEDURE [DDG].sp_baja_automovil
DROP PROCEDURE [DDG].sp_alta_chofer
DROP PROCEDURE [DDG].sp_baja_chofer
DROP PROCEDURE [DDG].sp_update_chofer
DROP PROCEDURE [DDG].sp_alta_viaje
DROP PROCEDURE [DDG].sp_alta_rendicion
DROP PROCEDURE [DDG].sp_alta_factura
DROP PROCEDURE [DDG].sp_get_importe_rendicion
DROP PROCEDURE [DDG].sp_obtenerPorcentajeActual
DROP PROCEDURE [DDG].sp_get_funcionalidades_rol
DROP PROCEDURE [DDG].sp_get_funcionalidades
DROP PROCEDURE [DDG].sp_get_marcas
DROP PROCEDURE [DDG].sp_get_modelos
DROP PROCEDURE [DDG].sp_get_turnos_habilitados
DROP PROCEDURE [DDG].sp_get_turnos_automovil
DROP PROCEDURE [DDG].sp_get_automoviles_chofer
DROP PROCEDURE [DDG].sp_get_automovilesHabilitados_chofer
DROP PROCEDURE [DDG].sp_get_importe_factura
DROP PROCEDURE [DDG].sp_get_viajes_rendicion
DROP PROCEDURE [DDG].sp_get_viajes_factura
DROP PROCEDURE [DDG].sp_get_modelos_marca
DROP PROCEDURE [DDG].sp_get_clientes
DROP PROCEDURE [DDG].sp_get_choferes
DROP PROCEDURE [DDG].sp_get_automoviles
DROP PROCEDURE [DDG].sp_get_turnos
DROP PROCEDURE [DDG].sp_get_automovilesHabilitados
DROP PROCEDURE [DDG].sp_get_choferesHabilitados
DROP PROCEDURE [DDG].sp_get_clientesHabilitados
DROP PROCEDURE [DDG].sp_get_automovilDetalles
DROP PROCEDURE [DDG].sp_alta_turno
DROP PROCEDURE [DDG].sp_update_turno
DROP PROCEDURE [DDG].sp_baja_turno
DROP PROCEDURE [DDG].sp_validar_datos_turno





-- Eliminacion de funciones

DROP FUNCTION [ddg].existeUsuario
DROP FUNCTION [ddg].usuarioActivo
DROP FUNCTION [ddg].getTrimestre
DROP FUNCTION [ddg].choferYaAsignado
DROP FUNCTION [ddg].calcularimporteViaje
DROP FUNCTION [ddg].existeClienteConMismoTelefono
DROP FUNCTION [ddg].ExisteRendicion
DROP FUNCTION [ddg].ExisteFacturacion
DROP FUNCTION [ddg].horario_superpuesto


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

-- Eliminacion del schema

drop schema DDG
