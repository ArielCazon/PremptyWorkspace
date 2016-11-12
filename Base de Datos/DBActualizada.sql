USE [master]
GO
/****** Object:  Database [PremptyWorkSpace]    Script Date: 14/10/2016 10:54:12 p. m. ******/
CREATE DATABASE [PremptyWorkSpace]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'PremptyWorkSpace', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.SQLEXPRESS12\MSSQL\DATA\PremptyWorkSpace.mdf' , SIZE = 4160KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'PremptyWorkSpace_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.SQLEXPRESS12\MSSQL\DATA\PremptyWorkSpace_log.ldf' , SIZE = 1040KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [PremptyWorkSpace] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [PremptyWorkSpace].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [PremptyWorkSpace] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [PremptyWorkSpace] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [PremptyWorkSpace] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [PremptyWorkSpace] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [PremptyWorkSpace] SET ARITHABORT OFF 
GO
ALTER DATABASE [PremptyWorkSpace] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [PremptyWorkSpace] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [PremptyWorkSpace] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [PremptyWorkSpace] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [PremptyWorkSpace] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [PremptyWorkSpace] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [PremptyWorkSpace] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [PremptyWorkSpace] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [PremptyWorkSpace] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [PremptyWorkSpace] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [PremptyWorkSpace] SET  ENABLE_BROKER 
GO
ALTER DATABASE [PremptyWorkSpace] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [PremptyWorkSpace] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [PremptyWorkSpace] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [PremptyWorkSpace] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [PremptyWorkSpace] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [PremptyWorkSpace] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [PremptyWorkSpace] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [PremptyWorkSpace] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [PremptyWorkSpace] SET  MULTI_USER 
GO
ALTER DATABASE [PremptyWorkSpace] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [PremptyWorkSpace] SET DB_CHAINING OFF 
GO
ALTER DATABASE [PremptyWorkSpace] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [PremptyWorkSpace] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
USE [PremptyWorkSpace]
GO
/****** Object:  Table [dbo].[Areas]    Script Date: 14/10/2016 10:54:12 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Areas](
	[IdArea] [int] IDENTITY(1,1) NOT NULL,
	[Descripcion] [nvarchar](50) NOT NULL,
	[IdEntidad] [int] NOT NULL,
 CONSTRAINT [PK_Areas] PRIMARY KEY CLUSTERED 
(
	[IdArea] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Entidades]    Script Date: 14/10/2016 10:54:13 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Entidades](
	[IdEntidad] [int] IDENTITY(1,1) NOT NULL,
	[RazonSocial] [nvarchar](100) NOT NULL,
	[Cuit] [nvarchar](50) NOT NULL,
	[Domicilio] [nvarchar](100) NOT NULL,
	[Telefono] [nvarchar](50) NULL,
	[Categoria] [nvarchar](1) NULL,
	[FechaAlta] [datetime] NOT NULL,
	[FechaBaja] [datetime] NULL,
 CONSTRAINT [PK_Entidades] PRIMARY KEY CLUSTERED 
(
	[IdEntidad] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Eventos]    Script Date: 14/10/2016 10:54:13 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Eventos](
	[IdEventos] [int] IDENTITY(1,1) NOT NULL,
	[Titulo] [nvarchar](50) NOT NULL,
	[Descripcion] [nvarchar](50) NOT NULL,
	[Fecha] [datetime] NOT NULL,
	[IdArea] [int] NULL,
	[Tipo] [char](1) NULL,
	[IdEntidad] [int] NOT NULL,
 CONSTRAINT [PK_Eventos] PRIMARY KEY CLUSTERED 
(
	[IdEventos] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Ingresos]    Script Date: 14/10/2016 10:54:13 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Ingresos](
	[IdIngresos] [int] IDENTITY(1,1) NOT NULL,
	[IdUsuario] [int] NOT NULL,
	[FechaActual] [datetime] NOT NULL,
	[HoraIngreso] [datetime] NULL,
	[HoraEgreso] [datetime] NULL,
 CONSTRAINT [PK_Ingresos] PRIMARY KEY CLUSTERED 
(
	[IdIngresos] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Licencias]    Script Date: 14/10/2016 10:54:13 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Licencias](
	[IdLicencia] [int] IDENTITY(1,1) NOT NULL,
	[IdUsuario] [int] NOT NULL,
	[FechaInicio] [datetime] NOT NULL,
	[FechaFin] [datetime] NOT NULL,
	[Motivo] [int] NULL,
	[Descripcion] [nvarchar](50) NOT NULL,
	[Estado] [int] NOT NULL,
	[Justificacion] [bit] NOT NULL,
 CONSTRAINT [PK_Licencias] PRIMARY KEY CLUSTERED 
(
	[IdLicencia] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[MotivoLicencia]    Script Date: 14/10/2016 10:54:13 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MotivoLicencia](
	[IdMotivo] [int] IDENTITY(1,1) NOT NULL,
	[Descripcion] [nvarchar](50) NOT NULL,
	[IdEntidad] [int] NOT NULL,
 CONSTRAINT [PK_MotivoLicencia] PRIMARY KEY CLUSTERED 
(
	[IdMotivo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Respuestas]    Script Date: 14/10/2016 10:54:13 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Respuestas](
	[IdRespuesta] [int] IDENTITY(1,1) NOT NULL,
	[IdEvento] [int] NOT NULL,
	[IdUsuario] [int] NOT NULL,
	[Respuesta] [int] NULL,
	[Comentario] [nvarchar](250) NULL,
 CONSTRAINT [PK_Respuestas] PRIMARY KEY CLUSTERED 
(
	[IdRespuesta] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Roles]    Script Date: 14/10/2016 10:54:13 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Roles](
	[IdRol] [int] IDENTITY(1,1) NOT NULL,
	[Rol] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Roles] PRIMARY KEY CLUSTERED 
(
	[IdRol] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Usuarios]    Script Date: 14/10/2016 10:54:13 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuarios](
	[IdUsuario] [int] IDENTITY(1,1) NOT NULL,
	[IdRol] [int] NOT NULL,
	[Legajo] [int] NULL,
	[Nombre] [nvarchar](50) NOT NULL,
	[Apellido] [nvarchar](50) NOT NULL,
	[FechaNac] [datetime] NOT NULL,
	[FechaIngreso] [datetime] NOT NULL,
	[IdArea] [int] NOT NULL,
	[Password] [nvarchar](50) NOT NULL,
	[Domicilio] [nvarchar](50) NOT NULL,
	[NombreUsuario] [nvarchar](50) NOT NULL,
	[IdEntidad] [int] NOT NULL,
	[Email] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Usuarios] PRIMARY KEY CLUSTERED 
(
	[IdUsuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[Areas]  WITH CHECK ADD  CONSTRAINT [FK_Areas_Entidades] FOREIGN KEY([IdEntidad])
REFERENCES [dbo].[Entidades] ([IdEntidad])
GO
ALTER TABLE [dbo].[Areas] CHECK CONSTRAINT [FK_Areas_Entidades]
GO
ALTER TABLE [dbo].[Eventos]  WITH CHECK ADD  CONSTRAINT [FK_Eventos_Areas] FOREIGN KEY([IdArea])
REFERENCES [dbo].[Areas] ([IdArea])
GO
ALTER TABLE [dbo].[Eventos] CHECK CONSTRAINT [FK_Eventos_Areas]
GO
ALTER TABLE [dbo].[Eventos]  WITH CHECK ADD  CONSTRAINT [FK_Eventos_Entidades] FOREIGN KEY([IdEntidad])
REFERENCES [dbo].[Entidades] ([IdEntidad])
GO
ALTER TABLE [dbo].[Eventos] CHECK CONSTRAINT [FK_Eventos_Entidades]
GO
ALTER TABLE [dbo].[Ingresos]  WITH CHECK ADD  CONSTRAINT [FK_Ingresos_Usuarios] FOREIGN KEY([IdUsuario])
REFERENCES [dbo].[Usuarios] ([IdUsuario])
GO
ALTER TABLE [dbo].[Ingresos] CHECK CONSTRAINT [FK_Ingresos_Usuarios]
GO
ALTER TABLE [dbo].[Licencias]  WITH CHECK ADD  CONSTRAINT [FK__Licencias__Motivos] FOREIGN KEY([Motivo])
REFERENCES [dbo].[MotivoLicencia] ([IdMotivo])
GO
ALTER TABLE [dbo].[Licencias] CHECK CONSTRAINT [FK__Licencias__Motivos]
GO
ALTER TABLE [dbo].[Licencias]  WITH CHECK ADD  CONSTRAINT [FK_Licencias_Usuarios] FOREIGN KEY([IdUsuario])
REFERENCES [dbo].[Usuarios] ([IdUsuario])
GO
ALTER TABLE [dbo].[Licencias] CHECK CONSTRAINT [FK_Licencias_Usuarios]
GO
ALTER TABLE [dbo].[MotivoLicencia]  WITH CHECK ADD  CONSTRAINT [FK_MotivoLicencia_Entidades] FOREIGN KEY([IdEntidad])
REFERENCES [dbo].[Entidades] ([IdEntidad])
GO
ALTER TABLE [dbo].[MotivoLicencia] CHECK CONSTRAINT [FK_MotivoLicencia_Entidades]
GO
ALTER TABLE [dbo].[Respuestas]  WITH CHECK ADD  CONSTRAINT [FK_Respuestas_Eventos] FOREIGN KEY([IdEvento])
REFERENCES [dbo].[Eventos] ([IdEventos])
GO
ALTER TABLE [dbo].[Respuestas] CHECK CONSTRAINT [FK_Respuestas_Eventos]
GO
ALTER TABLE [dbo].[Respuestas]  WITH CHECK ADD  CONSTRAINT [FK_Respuestas_Usuarios] FOREIGN KEY([IdUsuario])
REFERENCES [dbo].[Usuarios] ([IdUsuario])
GO
ALTER TABLE [dbo].[Respuestas] CHECK CONSTRAINT [FK_Respuestas_Usuarios]
GO
ALTER TABLE [dbo].[Usuarios]  WITH CHECK ADD  CONSTRAINT [FK__Usuarios__Area] FOREIGN KEY([IdArea])
REFERENCES [dbo].[Areas] ([IdArea])
GO
ALTER TABLE [dbo].[Usuarios] CHECK CONSTRAINT [FK__Usuarios__Area]
GO
ALTER TABLE [dbo].[Usuarios]  WITH CHECK ADD  CONSTRAINT [FK__Usuarios__IdRol] FOREIGN KEY([IdRol])
REFERENCES [dbo].[Roles] ([IdRol])
GO
ALTER TABLE [dbo].[Usuarios] CHECK CONSTRAINT [FK__Usuarios__IdRol]
GO
ALTER TABLE [dbo].[Usuarios]  WITH CHECK ADD  CONSTRAINT [FK_Usuarios_Entidades] FOREIGN KEY([IdEntidad])
REFERENCES [dbo].[Entidades] ([IdEntidad])
GO
ALTER TABLE [dbo].[Usuarios] CHECK CONSTRAINT [FK_Usuarios_Entidades]
GO
USE [master]
GO
ALTER DATABASE [PremptyWorkSpace] SET  READ_WRITE 
GO
