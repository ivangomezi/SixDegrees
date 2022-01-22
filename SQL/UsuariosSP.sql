USE [PruebaSD]
GO

/****** Object:  StoredProcedure [dbo].[UsuariosSP]    Script Date: 22/01/2022 9:49:26 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[UsuariosSP]
	@usuID int,
	@nombre nvarchar(100),
	@apellido nvarchar(100)
AS
BEGIN
	select
		usuID,
		nombre,
		apellido
	from
		Usuarios
END
GO


