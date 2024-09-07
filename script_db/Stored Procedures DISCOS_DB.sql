USE [DISCOS_DB]
GO

/****** Object:  StoredProcedure [dbo].[modificarDisco]    Script Date: 6/9/2024 23:51:24 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

create procedure [dbo].[modificarDisco]
@Titulo varchar(100),
@Año smalldatetime,
@Canciones int,
@UrlTapa varchar(200),
@Estilo int,
@Edicion int,
@Id int
as
Update DISCOS set Titulo = @Titulo, FechaLanzamiento = @Año, CantidadCanciones = @Canciones, UrlImagenTapa = @UrlTapa, IdEstilo = @Estilo, IdTipoEdicion = @Edicion where Id = @Id
GO

USE [DISCOS_DB]
GO

/****** Object:  StoredProcedure [dbo].[listar]    Script Date: 6/9/2024 23:52:11 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[listar] as Select Titulo, FechaLanzamiento, CantidadCanciones, UrlImagenTapa, E.Descripcion Estilo, T.Descripcion TipoEdicion, E.Id IdEstilo, T.Id IdEdicion, D.Id, D.Activo from DISCOS D, ESTILOS E, TIPOSEDICION T where E.Id = D.IdEstilo AND T.Id = D.IdTipoEdicion
GO

USE [DISCOS_DB]
GO

/****** Object:  StoredProcedure [dbo].[insertarNuevo]    Script Date: 6/9/2024 23:52:32 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

create procedure [dbo].[insertarNuevo]
@email varchar(50),
@pass varchar(50)
as
insert into USUARIOS(email, pass, TipoUser) output inserted.Id values (@email, @pass, 1)
GO

USE [DISCOS_DB]
GO

/****** Object:  StoredProcedure [dbo].[eliminarFisico]    Script Date: 6/9/2024 23:52:42 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

create procedure [dbo].[eliminarFisico] @Id int as Delete from DISCOS where Id = @Id
GO

USE [DISCOS_DB]
GO

/****** Object:  StoredProcedure [dbo].[altaDisco]    Script Date: 6/9/2024 23:52:52 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

create procedure [dbo].[altaDisco]
@titulo varchar(100),
@fechalanzamiento smalldatetime,
@cantidadcanciones int,
@urlimagentapa varchar(200),
@idestilo int,
@idtipoedicion int
as
Insert into DISCOS values (@titulo, @fechalanzamiento, @cantidadcanciones, @urlimagentapa, @idestilo, @idtipoedicion, 1)
GO


