create table cliente (
id numeric(10,0) primary key identity,
id_usuario numeric(10,0) not null references usuario,
nombre varchar(250) not null,
apellido varchar(250) not null,
fecha_nacimiento datetime not null,
dni numeric(18,0) unique not null,
direccion varchar(250) not null,
codigo_postal numeric not null,
telefono numeric(18,0) unique not null,
email varchar(250),
habilitado numeric(1,0) not null
)
GO

create table factura (
id numeric(18,0) primary key identity,
cliente numeric(10,0) not null references cliente,
numero numeric(18,0) unique not null,
fecha_inicio datetime not null,
fecha_fin datetime not null,
importe decimal(7,2) not null default 0
)
GO

create table chofer (
id numeric(10,0) primary key identity,
id_usuario numeric(10,0) not null references usuario,
nombre varchar(250) not null,
apellido varchar(250) not null,
fecha_nacimiento datetime not null,
dni numeric(18,0) unique not null,
direccion varchar(250) not null,
telefono numeric(18,0) unique not null,
email varchar(250),
habilitado numeric(1,0) not null
)
GO

create table turno (
id numeric(10,0) primary key identity,
hora_inicio numeric(2,0) not null,
hora_fin numeric(2,0) not null,
descripcion varchar(255),
valor_km decimal(5,2) not null,
precio_base decimal(5,2) not null,
habilitado numeric(1,0) not null
)
GO

create table auto (
id numeric(10,0) primary key identity,
turno numeric(10,0) not null references turno,
chofer numeric(10,0) not null references chofer,
marca varchar(255) not null,
modelo varchar(255) not null,
patente varchar(10) unique not null,
licencia varchar(26) not null,
rodado varchar(10) not null,
habilitado numeric(1,0) not null
)
GO

create table pago (
id numeric(10,0) primary key identity,
chofer numeric(10,0) not null references chofer,
turno numeric(10,0) not null references turno,
importe decimal(7,2) not null default 0,
fecha datetime
)
GO

create table viaje (
id numeric(18,0) primary key identity,
chofer numeric(10,0) not null references chofer,
auto numeric(10,0) not null references auto,
turno numeric(10,0) not null references turno,
cliente numeric(10,0) not null references cliente,
pago numeric(10,0) not null references pago,
cantidad_km numeric(5,0) not null,
fecha_viaje datetime not null,
hora_inicio time not null,
hora_fin time not null
)
GO

