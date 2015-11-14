
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 11/12/2015 20:24:29
-- Generated from EDMX file: C:\Users\DIEGO\Documents\GITHUB REPOSITORIO\LABORATORIO\AccesoDatos\ModeloBometrico.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [BiometricoDB];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_SectorSubSector]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[SubSectores] DROP CONSTRAINT [FK_SectorSubSector];
GO
IF OBJECT_ID(N'[dbo].[FK_SubSectorAgente_SubSector]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[SubSectorAgente] DROP CONSTRAINT [FK_SubSectorAgente_SubSector];
GO
IF OBJECT_ID(N'[dbo].[FK_SubSectorAgente_Agente]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[SubSectorAgente] DROP CONSTRAINT [FK_SubSectorAgente_Agente];
GO
IF OBJECT_ID(N'[dbo].[FK_AgenteHorario]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Horarios] DROP CONSTRAINT [FK_AgenteHorario];
GO
IF OBJECT_ID(N'[dbo].[FK_AgenteAcceso]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Accesos] DROP CONSTRAINT [FK_AgenteAcceso];
GO
IF OBJECT_ID(N'[dbo].[FK_PerfilFormulario_Perfil]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PerfilFormulario] DROP CONSTRAINT [FK_PerfilFormulario_Perfil];
GO
IF OBJECT_ID(N'[dbo].[FK_PerfilFormulario_Formulario]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PerfilFormulario] DROP CONSTRAINT [FK_PerfilFormulario_Formulario];
GO
IF OBJECT_ID(N'[dbo].[FK_PerfilUsuario_Perfil]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PerfilUsuario] DROP CONSTRAINT [FK_PerfilUsuario_Perfil];
GO
IF OBJECT_ID(N'[dbo].[FK_PerfilUsuario_Usuario]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PerfilUsuario] DROP CONSTRAINT [FK_PerfilUsuario_Usuario];
GO
IF OBJECT_ID(N'[dbo].[FK_PerfilControl_Perfil]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PerfilControl] DROP CONSTRAINT [FK_PerfilControl_Perfil];
GO
IF OBJECT_ID(N'[dbo].[FK_PerfilControl_Control]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PerfilControl] DROP CONSTRAINT [FK_PerfilControl_Control];
GO
IF OBJECT_ID(N'[dbo].[FK_AgenteUsuario]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Usuarios] DROP CONSTRAINT [FK_AgenteUsuario];
GO
IF OBJECT_ID(N'[dbo].[FK_TipoNovedadNovedad]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Novedades] DROP CONSTRAINT [FK_TipoNovedadNovedad];
GO
IF OBJECT_ID(N'[dbo].[FK_AgenteNovedad]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Novedades] DROP CONSTRAINT [FK_AgenteNovedad];
GO
IF OBJECT_ID(N'[dbo].[FK_AgenteComisionServicio]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ComisionServicios] DROP CONSTRAINT [FK_AgenteComisionServicio];
GO
IF OBJECT_ID(N'[dbo].[FK_AgenteLactancia]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Lactancias] DROP CONSTRAINT [FK_AgenteLactancia];
GO
IF OBJECT_ID(N'[dbo].[FK_FormularioControl]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Controles] DROP CONSTRAINT [FK_FormularioControl];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Sectores]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Sectores];
GO
IF OBJECT_ID(N'[dbo].[SubSectores]', 'U') IS NOT NULL
    DROP TABLE [dbo].[SubSectores];
GO
IF OBJECT_ID(N'[dbo].[Agentes]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Agentes];
GO
IF OBJECT_ID(N'[dbo].[Horarios]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Horarios];
GO
IF OBJECT_ID(N'[dbo].[Accesos]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Accesos];
GO
IF OBJECT_ID(N'[dbo].[Perfiles]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Perfiles];
GO
IF OBJECT_ID(N'[dbo].[Formularios]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Formularios];
GO
IF OBJECT_ID(N'[dbo].[Usuarios]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Usuarios];
GO
IF OBJECT_ID(N'[dbo].[Controles]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Controles];
GO
IF OBJECT_ID(N'[dbo].[Configuraciones]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Configuraciones];
GO
IF OBJECT_ID(N'[dbo].[TipoNovedades]', 'U') IS NOT NULL
    DROP TABLE [dbo].[TipoNovedades];
GO
IF OBJECT_ID(N'[dbo].[Novedades]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Novedades];
GO
IF OBJECT_ID(N'[dbo].[ComisionServicios]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ComisionServicios];
GO
IF OBJECT_ID(N'[dbo].[Lactancias]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Lactancias];
GO
IF OBJECT_ID(N'[dbo].[RelojDefectuosos]', 'U') IS NOT NULL
    DROP TABLE [dbo].[RelojDefectuosos];
GO
IF OBJECT_ID(N'[dbo].[SubSectorAgente]', 'U') IS NOT NULL
    DROP TABLE [dbo].[SubSectorAgente];
GO
IF OBJECT_ID(N'[dbo].[PerfilFormulario]', 'U') IS NOT NULL
    DROP TABLE [dbo].[PerfilFormulario];
GO
IF OBJECT_ID(N'[dbo].[PerfilUsuario]', 'U') IS NOT NULL
    DROP TABLE [dbo].[PerfilUsuario];
GO
IF OBJECT_ID(N'[dbo].[PerfilControl]', 'U') IS NOT NULL
    DROP TABLE [dbo].[PerfilControl];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Sectores'
CREATE TABLE [dbo].[Sectores] (
    [Id] bigint IDENTITY(1,1) NOT NULL,
    [Codigo] int  NOT NULL,
    [Descripcion] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'SubSectores'
CREATE TABLE [dbo].[SubSectores] (
    [Id] bigint IDENTITY(1,1) NOT NULL,
    [Codigo] int  NOT NULL,
    [Abreviatura] nvarchar(max)  NOT NULL,
    [Descripcion] nvarchar(max)  NOT NULL,
    [SectorId] bigint  NOT NULL
);
GO

-- Creating table 'Agentes'
CREATE TABLE [dbo].[Agentes] (
    [Id] bigint IDENTITY(1,1) NOT NULL,
    [Legajo] varchar(max)  NOT NULL,
    [Apellido] nvarchar(max)  NOT NULL,
    [Nombre] nvarchar(max)  NOT NULL,
    [DNI] nvarchar(max)  NOT NULL,
    [Telefono] nvarchar(max)  NOT NULL,
    [Celular] nvarchar(max)  NOT NULL,
    [Mail] nvarchar(max)  NOT NULL,
    [Visualizar] bit  NOT NULL
);
GO

-- Creating table 'Horarios'
CREATE TABLE [dbo].[Horarios] (
    [Id] bigint IDENTITY(1,1) NOT NULL,
    [AgenteId] bigint  NOT NULL,
    [HoraEntrada] time  NULL,
    [HoraSalidaParcial] time  NULL,
    [HoraEntradaParcial] time  NULL,
    [HoraSalida] time  NULL,
    [Lunes] bit  NOT NULL,
    [Martes] bit  NOT NULL,
    [Miercoles] bit  NOT NULL,
    [Jueves] bit  NOT NULL,
    [Viernes] bit  NOT NULL,
    [Sabado] bit  NOT NULL,
    [Domingo] bit  NOT NULL,
    [FechaActualizacion] datetime  NOT NULL,
    [FechaDesde] datetime  NOT NULL,
    [FechaHasta] datetime  NOT NULL
);
GO

-- Creating table 'Accesos'
CREATE TABLE [dbo].[Accesos] (
    [Id] bigint IDENTITY(1,1) NOT NULL,
    [AgenteId] bigint  NOT NULL,
    [FechaHora] datetime  NOT NULL,
    [TipoAcceso] int  NOT NULL,
    [NroReloj] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Perfiles'
CREATE TABLE [dbo].[Perfiles] (
    [Id] bigint IDENTITY(1,1) NOT NULL,
    [Descripcion] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Formularios'
CREATE TABLE [dbo].[Formularios] (
    [Id] bigint IDENTITY(1,1) NOT NULL,
    [Codigo] nvarchar(max)  NOT NULL,
    [Descripcion] nvarchar(max)  NOT NULL,
    [DescripcionCompleta] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Usuarios'
CREATE TABLE [dbo].[Usuarios] (
    [Id] bigint IDENTITY(1,1) NOT NULL,
    [Nombre] nvarchar(max)  NOT NULL,
    [Password] nvarchar(max)  NOT NULL,
    [EstaBloqueado] bit  NOT NULL,
    [AgenteId] bigint  NOT NULL
);
GO

-- Creating table 'Controles'
CREATE TABLE [dbo].[Controles] (
    [Id] bigint IDENTITY(1,1) NOT NULL,
    [Descripcion] nvarchar(max)  NOT NULL,
    [FormularioId] bigint  NOT NULL
);
GO

-- Creating table 'Configuraciones'
CREATE TABLE [dbo].[Configuraciones] (
    [Id] bigint IDENTITY(1,1) NOT NULL,
    [MinutosToleranciaLlegadaTarde] int  NOT NULL,
    [MinutosToleranciaAusente] int  NOT NULL,
    [HoraEntradaPorDefecto] time  NOT NULL,
    [HoraSalidaPorDefecto] time  NOT NULL,
    [MinutosLactancia] int  NOT NULL
);
GO

-- Creating table 'TipoNovedades'
CREATE TABLE [dbo].[TipoNovedades] (
    [Id] bigint IDENTITY(1,1) NOT NULL,
    [Abreviatura] nvarchar(max)  NOT NULL,
    [Descripcion] nvarchar(max)  NOT NULL,
    [EsJornadaCompleta] bit  NOT NULL
);
GO

-- Creating table 'Novedades'
CREATE TABLE [dbo].[Novedades] (
    [Id] bigint IDENTITY(1,1) NOT NULL,
    [AgenteId] bigint  NOT NULL,
    [TipoNovedadId] bigint  NOT NULL,
    [FechaDesde] datetime  NOT NULL,
    [FechaHasta] datetime  NULL,
    [HoraDesde] nvarchar(max)  NOT NULL,
    [HoraHasta] nvarchar(max)  NOT NULL,
    [Observacion] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'ComisionServicios'
CREATE TABLE [dbo].[ComisionServicios] (
    [Id] bigint IDENTITY(1,1) NOT NULL,
    [AgenteId] bigint  NOT NULL,
    [FechaDesde] datetime  NOT NULL,
    [FechaHasta] datetime  NULL,
    [HoraDesde] time  NOT NULL,
    [HoraHasta] time  NOT NULL,
    [EsJornadaCompleta] bit  NOT NULL,
    [Observacion] nvarchar(max)  NOT NULL,
    [Descripcion] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Lactancias'
CREATE TABLE [dbo].[Lactancias] (
    [Id] bigint IDENTITY(1,1) NOT NULL,
    [AgenteId] bigint  NOT NULL,
    [Lunes] bit  NOT NULL,
    [Martes] bit  NOT NULL,
    [Miercoles] bit  NOT NULL,
    [Jueves] bit  NOT NULL,
    [Viernes] bit  NOT NULL,
    [Sabado] bit  NOT NULL,
    [Domingo] bit  NOT NULL,
    [FechaDesde] datetime  NOT NULL,
    [FechaHasta] datetime  NOT NULL,
    [HoraInicio] time  NOT NULL,
    [FechaActualizacion] datetime  NOT NULL
);
GO

-- Creating table 'RelojDefectuosos'
CREATE TABLE [dbo].[RelojDefectuosos] (
    [Id] bigint IDENTITY(1,1) NOT NULL,
    [Fecha] datetime  NOT NULL,
    [HoraDesde] time  NULL,
    [HoraHasta] time  NULL,
    [JornadaCompleta] bit  NULL
);
GO

-- Creating table 'SubSectorAgente'
CREATE TABLE [dbo].[SubSectorAgente] (
    [SubSectores_Id] bigint  NOT NULL,
    [Agentes_Id] bigint  NOT NULL
);
GO

-- Creating table 'PerfilFormulario'
CREATE TABLE [dbo].[PerfilFormulario] (
    [Perfiles_Id] bigint  NOT NULL,
    [Formularios_Id] bigint  NOT NULL
);
GO

-- Creating table 'PerfilUsuario'
CREATE TABLE [dbo].[PerfilUsuario] (
    [Perfiles_Id] bigint  NOT NULL,
    [Usuarios_Id] bigint  NOT NULL
);
GO

-- Creating table 'PerfilControl'
CREATE TABLE [dbo].[PerfilControl] (
    [Perfiles_Id] bigint  NOT NULL,
    [Controles_Id] bigint  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'Sectores'
ALTER TABLE [dbo].[Sectores]
ADD CONSTRAINT [PK_Sectores]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'SubSectores'
ALTER TABLE [dbo].[SubSectores]
ADD CONSTRAINT [PK_SubSectores]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Agentes'
ALTER TABLE [dbo].[Agentes]
ADD CONSTRAINT [PK_Agentes]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Horarios'
ALTER TABLE [dbo].[Horarios]
ADD CONSTRAINT [PK_Horarios]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Accesos'
ALTER TABLE [dbo].[Accesos]
ADD CONSTRAINT [PK_Accesos]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Perfiles'
ALTER TABLE [dbo].[Perfiles]
ADD CONSTRAINT [PK_Perfiles]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Formularios'
ALTER TABLE [dbo].[Formularios]
ADD CONSTRAINT [PK_Formularios]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Usuarios'
ALTER TABLE [dbo].[Usuarios]
ADD CONSTRAINT [PK_Usuarios]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Controles'
ALTER TABLE [dbo].[Controles]
ADD CONSTRAINT [PK_Controles]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Configuraciones'
ALTER TABLE [dbo].[Configuraciones]
ADD CONSTRAINT [PK_Configuraciones]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'TipoNovedades'
ALTER TABLE [dbo].[TipoNovedades]
ADD CONSTRAINT [PK_TipoNovedades]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Novedades'
ALTER TABLE [dbo].[Novedades]
ADD CONSTRAINT [PK_Novedades]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'ComisionServicios'
ALTER TABLE [dbo].[ComisionServicios]
ADD CONSTRAINT [PK_ComisionServicios]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Lactancias'
ALTER TABLE [dbo].[Lactancias]
ADD CONSTRAINT [PK_Lactancias]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'RelojDefectuosos'
ALTER TABLE [dbo].[RelojDefectuosos]
ADD CONSTRAINT [PK_RelojDefectuosos]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [SubSectores_Id], [Agentes_Id] in table 'SubSectorAgente'
ALTER TABLE [dbo].[SubSectorAgente]
ADD CONSTRAINT [PK_SubSectorAgente]
    PRIMARY KEY CLUSTERED ([SubSectores_Id], [Agentes_Id] ASC);
GO

-- Creating primary key on [Perfiles_Id], [Formularios_Id] in table 'PerfilFormulario'
ALTER TABLE [dbo].[PerfilFormulario]
ADD CONSTRAINT [PK_PerfilFormulario]
    PRIMARY KEY CLUSTERED ([Perfiles_Id], [Formularios_Id] ASC);
GO

-- Creating primary key on [Perfiles_Id], [Usuarios_Id] in table 'PerfilUsuario'
ALTER TABLE [dbo].[PerfilUsuario]
ADD CONSTRAINT [PK_PerfilUsuario]
    PRIMARY KEY CLUSTERED ([Perfiles_Id], [Usuarios_Id] ASC);
GO

-- Creating primary key on [Perfiles_Id], [Controles_Id] in table 'PerfilControl'
ALTER TABLE [dbo].[PerfilControl]
ADD CONSTRAINT [PK_PerfilControl]
    PRIMARY KEY CLUSTERED ([Perfiles_Id], [Controles_Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [SectorId] in table 'SubSectores'
ALTER TABLE [dbo].[SubSectores]
ADD CONSTRAINT [FK_SectorSubSector]
    FOREIGN KEY ([SectorId])
    REFERENCES [dbo].[Sectores]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_SectorSubSector'
CREATE INDEX [IX_FK_SectorSubSector]
ON [dbo].[SubSectores]
    ([SectorId]);
GO

-- Creating foreign key on [SubSectores_Id] in table 'SubSectorAgente'
ALTER TABLE [dbo].[SubSectorAgente]
ADD CONSTRAINT [FK_SubSectorAgente_SubSector]
    FOREIGN KEY ([SubSectores_Id])
    REFERENCES [dbo].[SubSectores]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Agentes_Id] in table 'SubSectorAgente'
ALTER TABLE [dbo].[SubSectorAgente]
ADD CONSTRAINT [FK_SubSectorAgente_Agente]
    FOREIGN KEY ([Agentes_Id])
    REFERENCES [dbo].[Agentes]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_SubSectorAgente_Agente'
CREATE INDEX [IX_FK_SubSectorAgente_Agente]
ON [dbo].[SubSectorAgente]
    ([Agentes_Id]);
GO

-- Creating foreign key on [AgenteId] in table 'Horarios'
ALTER TABLE [dbo].[Horarios]
ADD CONSTRAINT [FK_AgenteHorario]
    FOREIGN KEY ([AgenteId])
    REFERENCES [dbo].[Agentes]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_AgenteHorario'
CREATE INDEX [IX_FK_AgenteHorario]
ON [dbo].[Horarios]
    ([AgenteId]);
GO

-- Creating foreign key on [AgenteId] in table 'Accesos'
ALTER TABLE [dbo].[Accesos]
ADD CONSTRAINT [FK_AgenteAcceso]
    FOREIGN KEY ([AgenteId])
    REFERENCES [dbo].[Agentes]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_AgenteAcceso'
CREATE INDEX [IX_FK_AgenteAcceso]
ON [dbo].[Accesos]
    ([AgenteId]);
GO

-- Creating foreign key on [Perfiles_Id] in table 'PerfilFormulario'
ALTER TABLE [dbo].[PerfilFormulario]
ADD CONSTRAINT [FK_PerfilFormulario_Perfil]
    FOREIGN KEY ([Perfiles_Id])
    REFERENCES [dbo].[Perfiles]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Formularios_Id] in table 'PerfilFormulario'
ALTER TABLE [dbo].[PerfilFormulario]
ADD CONSTRAINT [FK_PerfilFormulario_Formulario]
    FOREIGN KEY ([Formularios_Id])
    REFERENCES [dbo].[Formularios]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PerfilFormulario_Formulario'
CREATE INDEX [IX_FK_PerfilFormulario_Formulario]
ON [dbo].[PerfilFormulario]
    ([Formularios_Id]);
GO

-- Creating foreign key on [Perfiles_Id] in table 'PerfilUsuario'
ALTER TABLE [dbo].[PerfilUsuario]
ADD CONSTRAINT [FK_PerfilUsuario_Perfil]
    FOREIGN KEY ([Perfiles_Id])
    REFERENCES [dbo].[Perfiles]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Usuarios_Id] in table 'PerfilUsuario'
ALTER TABLE [dbo].[PerfilUsuario]
ADD CONSTRAINT [FK_PerfilUsuario_Usuario]
    FOREIGN KEY ([Usuarios_Id])
    REFERENCES [dbo].[Usuarios]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PerfilUsuario_Usuario'
CREATE INDEX [IX_FK_PerfilUsuario_Usuario]
ON [dbo].[PerfilUsuario]
    ([Usuarios_Id]);
GO

-- Creating foreign key on [Perfiles_Id] in table 'PerfilControl'
ALTER TABLE [dbo].[PerfilControl]
ADD CONSTRAINT [FK_PerfilControl_Perfil]
    FOREIGN KEY ([Perfiles_Id])
    REFERENCES [dbo].[Perfiles]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Controles_Id] in table 'PerfilControl'
ALTER TABLE [dbo].[PerfilControl]
ADD CONSTRAINT [FK_PerfilControl_Control]
    FOREIGN KEY ([Controles_Id])
    REFERENCES [dbo].[Controles]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PerfilControl_Control'
CREATE INDEX [IX_FK_PerfilControl_Control]
ON [dbo].[PerfilControl]
    ([Controles_Id]);
GO

-- Creating foreign key on [AgenteId] in table 'Usuarios'
ALTER TABLE [dbo].[Usuarios]
ADD CONSTRAINT [FK_AgenteUsuario]
    FOREIGN KEY ([AgenteId])
    REFERENCES [dbo].[Agentes]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_AgenteUsuario'
CREATE INDEX [IX_FK_AgenteUsuario]
ON [dbo].[Usuarios]
    ([AgenteId]);
GO

-- Creating foreign key on [TipoNovedadId] in table 'Novedades'
ALTER TABLE [dbo].[Novedades]
ADD CONSTRAINT [FK_TipoNovedadNovedad]
    FOREIGN KEY ([TipoNovedadId])
    REFERENCES [dbo].[TipoNovedades]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_TipoNovedadNovedad'
CREATE INDEX [IX_FK_TipoNovedadNovedad]
ON [dbo].[Novedades]
    ([TipoNovedadId]);
GO

-- Creating foreign key on [AgenteId] in table 'Novedades'
ALTER TABLE [dbo].[Novedades]
ADD CONSTRAINT [FK_AgenteNovedad]
    FOREIGN KEY ([AgenteId])
    REFERENCES [dbo].[Agentes]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_AgenteNovedad'
CREATE INDEX [IX_FK_AgenteNovedad]
ON [dbo].[Novedades]
    ([AgenteId]);
GO

-- Creating foreign key on [AgenteId] in table 'ComisionServicios'
ALTER TABLE [dbo].[ComisionServicios]
ADD CONSTRAINT [FK_AgenteComisionServicio]
    FOREIGN KEY ([AgenteId])
    REFERENCES [dbo].[Agentes]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_AgenteComisionServicio'
CREATE INDEX [IX_FK_AgenteComisionServicio]
ON [dbo].[ComisionServicios]
    ([AgenteId]);
GO

-- Creating foreign key on [AgenteId] in table 'Lactancias'
ALTER TABLE [dbo].[Lactancias]
ADD CONSTRAINT [FK_AgenteLactancia]
    FOREIGN KEY ([AgenteId])
    REFERENCES [dbo].[Agentes]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_AgenteLactancia'
CREATE INDEX [IX_FK_AgenteLactancia]
ON [dbo].[Lactancias]
    ([AgenteId]);
GO

-- Creating foreign key on [FormularioId] in table 'Controles'
ALTER TABLE [dbo].[Controles]
ADD CONSTRAINT [FK_FormularioControl]
    FOREIGN KEY ([FormularioId])
    REFERENCES [dbo].[Formularios]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_FormularioControl'
CREATE INDEX [IX_FK_FormularioControl]
ON [dbo].[Controles]
    ([FormularioId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------