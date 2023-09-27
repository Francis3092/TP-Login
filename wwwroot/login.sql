USE [loginDB]
GO
/****** Object:  User [alumno]    Script Date: 27/9/2023 11:31:38 ******/
CREATE USER [alumno] FOR LOGIN [alumno] WITH DEFAULT_SCHEMA=[dbo]
GO
/****** Object:  Table [dbo].[Usuario]    Script Date: 27/9/2023 11:31:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuario](
	[UserName] [varchar](500) NOT NULL,
	[Contraseña] [varchar](500) NOT NULL,
	[Mail] [varchar](500) NOT NULL,
	[Telefono] [int] NOT NULL
) ON [PRIMARY]
GO
