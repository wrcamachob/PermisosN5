USE [Permission]
GO
/****** Object:  Table [dbo].[Permisos]    Script Date: 14/04/2024 10:01:34 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Permisos](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[NombreEmpleado] [text] NOT NULL,
	[ApellidoEmpleado] [text] NOT NULL,
	[TipoPermiso] [int] NOT NULL,
	[FechaPermiso] [date] NOT NULL,
 CONSTRAINT [PK_Permisos] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TipoPermisos]    Script Date: 14/04/2024 10:01:34 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TipoPermisos](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Descripcion] [text] NOT NULL,
 CONSTRAINT [PK_TipoPermisos] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
ALTER TABLE [dbo].[Permisos]  WITH CHECK ADD  CONSTRAINT [FK_Permisos_TipoPermisos] FOREIGN KEY([TipoPermiso])
REFERENCES [dbo].[TipoPermisos] ([Id])
GO
ALTER TABLE [dbo].[Permisos] CHECK CONSTRAINT [FK_Permisos_TipoPermisos]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Unique ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Permisos', @level2type=N'COLUMN',@level2name=N'Id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Employee forename' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Permisos', @level2type=N'COLUMN',@level2name=N'NombreEmpleado'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Employee Surname' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Permisos', @level2type=N'COLUMN',@level2name=N'ApellidoEmpleado'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Permission Type' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Permisos', @level2type=N'COLUMN',@level2name=N'TipoPermiso'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Permission Granted on Date' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Permisos', @level2type=N'COLUMN',@level2name=N'FechaPermiso'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Unique ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'TipoPermisos', @level2type=N'COLUMN',@level2name=N'Id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Permission description' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'TipoPermisos', @level2type=N'COLUMN',@level2name=N'Descripcion'
GO
