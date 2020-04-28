use DB_A5A767_sulcran;

-- test table categoria
select * from categorias;

-- 1
create procedure USP_InsCategoria
@nombrecategoria varchar(100),
@descripcion text
as
begin
	declare @idcategoria int
	set @idcategoria = (select MAX(IdCategoria)+1 from categorias)
	insert into categorias(idcategoria, nombrecategoria, descripcion)
	values(@idcategoria, @nombrecategoria, @descripcion)
end;

-- 2
create procedure USP_UpdCategoria
@idcategoria int,
@nombrecategoria varchar(100),
@descripcion text
as
begin
	update categorias Set nombrecategoria=@nombrecategoria, descripcion=@descripcion
	where idcategoria=@idcategoria
end;

--3
create procedure USP_DelCategoria
@idcategoria int
as
begin
	delete from categorias where idcategoria=@idcategoria
end;

-- 4
create procedure USP_GetCategoria
@idcategoria int=0
as
begin
	select idcategoria, nombrecategoria,descripcion
	from categorias
	where idcategoria=@idcategoria or @idcategoria=0
end;

-- Modificando el procedimiento Business
alter proc USP_InsCategoria
@idcategoria int,
@nombrecategoria varchar(100),
@descripcion text
as
begin
insert into categorias(idcategoria,nombrecategoria,descripcion,estado)
values(@idcategoria,@nombrecategoria,@descripcion,1)
end

-- Agregando estado a la tabla categorias
alter table categorias
add estado bit;

-- 5
create procedure USP_GetProducto
@idproducto int=0
as
begin
	select idproducto, nombreProducto, prov.nombreCompañia, cate.nombrecategoria, prod.cantidadPorUnidad,
	prod.precioUnidad, prod.unidadesEnExistencia, prod.unidadesEnPedido, prod.nivelNuevoPedido, prod.suspendido, prod.categoriaProducto
	from productos prod
	join proveedores prov on (prod.idProveedor = prov.idProveedor)
	join categorias cate on (prod.idCategoria = cate.idcategoria)
	where prod.idproducto=@idproducto or @idproducto=0
end;

-- 6

create procedure USP_InsProducto
@idproducto int,
@nombreproducto varchar(40),
@cantidadporunidad varchar(20),
@preciounidad decimal(18, 0),
@unidadesenexistencia smallint,
@unidadesenpedido smallint,
@nivelnuevopedido smallint,
@suspendido smallint,
@categoriaproducto varchar(20)
as
begin
	insert into productos (idproducto,nombreProducto, cantidadPorUnidad, precioUnidad, unidadesEnExistencia, unidadesEnPedido,
	nivelNuevoPedido, suspendido, categoriaProducto)
	values(@idproducto,@nombreproducto, @cantidadporunidad, @preciounidad, @unidadesenexistencia, @unidadesenpedido,
	@nivelnuevopedido, @suspendido, @categoriaproducto);
end;



