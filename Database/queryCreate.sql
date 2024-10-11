create table categoria(
	idCategoria int  IDENTITY(1,1) NOT NULL,
	descripCategoria varchar(max)
)
alter table categoria add constraint PK_CATEGORIA PRIMARY KEY (idCategoria);

create table producto(
	idProducto int  IDENTITY(1,1) NOT NULL,
	nameProducto varchar(max),
	precio float,
	descripProducto varchar(max),
	fotoProducto  varchar(max),
	idCategoria int
)
alter table producto add constraint PK_PRODUCTO PRIMARY KEY (idProducto);
alter table producto add constraint FK_PRODUCTO_CATEGORIA FOREIGN KEY(idCategoria)REFERENCES categoria(idCategoria);

create table favoritos(
	idFavorito int identity (1,1) not null,
	idProducto int,
	idCategoria int,  
)
alter table favoritos add constraint PK_FAVORITO PRIMARY KEY (idFavorito);
alter table favoritos add constraint FK_FAVORITO_CATEGORIA FOREIGN KEY(idCategoria)REFERENCES categoria (idCategoria)
alter table favoritos add constraint FK_FAVORITO_PRODUCTO FOREIGN KEY(idProducto)REFERENCES producto (idProducto)

insert into categoria VALUES('ELECTRODOMESTICO')
insert into categoria VALUES('COCINA');
insert into categoria VALUES('BAÑO');

insert into producto values('REFRIGERADORA INDURAMA', 750.25, 'Electrodoméstico que conserva alimentos y bebidas a baja temperatura para mantener su frescura.','imagen', 2);
insert into producto values('COCINA INDURAMA', 550.25, 'Electrodoméstico que permite preparar alimentos mediante diferentes métodos de cocción como hervir, freír o hornear.','imagen', 2);
insert into producto values('LICUADORA INDURAMA', 100.25, 'Electrodoméstico que mezcla y tritura alimentos o líquidos mediante cuchillas giratorias','imagen', 2);

insert into producto values('MOUSE HP', 50.25, 'Dispositivo de entrada que permite controlar el cursor en una computadora mediante movimientos y clics.','imagen', 1);
insert into producto values('COMPUTADORA HP', 500.25, 'Dispositivo electrónico que procesa datos y ejecuta programas para realizar diversas tareas.','imagen', 1);
insert into producto values('LAPTOP HP', 1000.25, 'Computadora portátil que integra pantalla, teclado y batería en un solo dispositivo compacto y fácil de transportar.','imagen', 1);

insert into producto values('FOCO INTELIGENTE', 20.25, 'Bombilla que se controla de forma remota mediante aplicaciones o asistentes de voz, permitiendo ajustar la iluminación y otras funciones.','imagen', 3);
insert into producto values('GRIFO INTELIGENTE', 70.25, 'Dispositivo que controla el flujo de agua automáticamente mediante sensores o comandos de voz, optimizando su uso.','imagen', 3);
