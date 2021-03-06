USE [master]
GO
/****** Object:  Database [DeliveryJW]    Script Date: 14/09/2020 10:26:58 ******/
CREATE DATABASE [DeliveryJW]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'DeliveryJW', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\DeliveryJW.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'DeliveryJW_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\DeliveryJW_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [DeliveryJW] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [DeliveryJW].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [DeliveryJW] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [DeliveryJW] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [DeliveryJW] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [DeliveryJW] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [DeliveryJW] SET ARITHABORT OFF 
GO
ALTER DATABASE [DeliveryJW] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [DeliveryJW] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [DeliveryJW] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [DeliveryJW] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [DeliveryJW] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [DeliveryJW] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [DeliveryJW] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [DeliveryJW] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [DeliveryJW] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [DeliveryJW] SET  DISABLE_BROKER 
GO
ALTER DATABASE [DeliveryJW] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [DeliveryJW] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [DeliveryJW] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [DeliveryJW] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [DeliveryJW] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [DeliveryJW] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [DeliveryJW] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [DeliveryJW] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [DeliveryJW] SET  MULTI_USER 
GO
ALTER DATABASE [DeliveryJW] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [DeliveryJW] SET DB_CHAINING OFF 
GO
ALTER DATABASE [DeliveryJW] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [DeliveryJW] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [DeliveryJW] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [DeliveryJW] SET QUERY_STORE = OFF
GO
USE [DeliveryJW]
GO
/****** Object:  Table [dbo].[Banco]    Script Date: 14/09/2020 10:26:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Banco](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](50) NULL,
	[numero_Cuenta] [varchar](50) NULL,
	[tipo_Cuenta] [varchar](5) NULL,
	[propietario_Nombre_Cuenta] [varchar](50) NULL,
 CONSTRAINT [PK_Banco] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CabeceraPedido]    Script Date: 14/09/2020 10:26:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CabeceraPedido](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[fecha_pedido] [date] NULL,
	[estado_pedido] [varchar](5) NULL,
	[numero_pedido] [varchar](50) NULL,
	[id_Usuario] [int] NULL,
	[total] [decimal](8, 4) NULL,
 CONSTRAINT [PK_CabeceraPedido] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DetallePago]    Script Date: 14/09/2020 10:26:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DetallePago](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[fecha_Pago] [date] NULL,
	[numero_Ticket] [varchar](50) NULL,
	[pais] [varchar](50) NULL,
	[provincia] [varchar](50) NULL,
	[ciudad] [varchar](50) NULL,
	[imagen_recibo] [varchar](100) NULL,
	[id_Banco] [int] NULL,
	[id_Pedido] [int] NULL,
	[imagen] [varchar](200) NULL,
 CONSTRAINT [PK_DetallePago] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DetallePedido]    Script Date: 14/09/2020 10:26:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DetallePedido](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[cantidad] [int] NULL,
	[subtotal] [decimal](8, 4) NULL,
	[iva] [decimal](8, 4) NULL,
	[id_Juego] [int] NULL,
	[id_Cabecera] [int] NULL,
 CONSTRAINT [PK_DetallePedido] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Juego]    Script Date: 14/09/2020 10:26:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Juego](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[titulo] [varchar](50) NULL,
	[precio] [decimal](8, 4) NULL,
	[plataforma] [varchar](50) NULL,
	[estado] [varchar](5) NULL,
	[fecha_lanzamiento] [date] NULL,
	[genero] [varchar](50) NULL,
	[idioma] [varchar](50) NULL,
	[imagen] [varchar](50) NULL,
 CONSTRAINT [PK_Juego] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Usuario]    Script Date: 14/09/2020 10:26:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuario](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](50) NULL,
	[apellido] [varchar](50) NULL,
	[cedula] [varchar](15) NULL,
	[telefono] [varchar](15) NULL,
	[correo] [varchar](50) NULL,
	[usuario_sesion] [varchar](50) NULL,
	[contrasena] [varchar](50) NULL,
	[pais] [varchar](50) NULL,
	[ciudad] [varchar](50) NULL,
	[rol] [varchar](50) NULL,
 CONSTRAINT [PK_Usuario] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[CabeceraPedido]  WITH CHECK ADD  CONSTRAINT [FK_CabeceraPedido_Usuario] FOREIGN KEY([id_Usuario])
REFERENCES [dbo].[Usuario] ([id])
GO
ALTER TABLE [dbo].[CabeceraPedido] CHECK CONSTRAINT [FK_CabeceraPedido_Usuario]
GO
ALTER TABLE [dbo].[DetallePago]  WITH CHECK ADD  CONSTRAINT [FK_DetallePago_Banco] FOREIGN KEY([id_Banco])
REFERENCES [dbo].[Banco] ([id])
GO
ALTER TABLE [dbo].[DetallePago] CHECK CONSTRAINT [FK_DetallePago_Banco]
GO
ALTER TABLE [dbo].[DetallePago]  WITH CHECK ADD  CONSTRAINT [FK_DetallePago_CabeceraPedido] FOREIGN KEY([id_Pedido])
REFERENCES [dbo].[CabeceraPedido] ([id])
GO
ALTER TABLE [dbo].[DetallePago] CHECK CONSTRAINT [FK_DetallePago_CabeceraPedido]
GO
ALTER TABLE [dbo].[DetallePedido]  WITH CHECK ADD  CONSTRAINT [FK_DetallePedido_CabeceraPedido] FOREIGN KEY([id_Cabecera])
REFERENCES [dbo].[CabeceraPedido] ([id])
GO
ALTER TABLE [dbo].[DetallePedido] CHECK CONSTRAINT [FK_DetallePedido_CabeceraPedido]
GO
ALTER TABLE [dbo].[DetallePedido]  WITH CHECK ADD  CONSTRAINT [FK_DetallePedido_Juego] FOREIGN KEY([id_Juego])
REFERENCES [dbo].[Juego] ([id])
GO
ALTER TABLE [dbo].[DetallePedido] CHECK CONSTRAINT [FK_DetallePedido_Juego]
GO
USE [master]
GO
ALTER DATABASE [DeliveryJW] SET  READ_WRITE 
GO
