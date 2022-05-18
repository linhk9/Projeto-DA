
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 05/18/2022 20:00:23
-- Generated from EDMX file: C:\wamp64\www\Projeto-DA\Restaurante_APP\Restaurante_APP\RestauranteAPP.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [RestaurantesAPP];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------


-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------


-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Pessoa'
CREATE TABLE [dbo].[Pessoa] (
    [IdPessoa] int IDENTITY(1,1) NOT NULL,
    [Nome] nvarchar(max)  NOT NULL,
    [Telemovel] int  NOT NULL,
    [Morada_IdMorada] int  NOT NULL
);
GO

-- Creating table 'Restaurante'
CREATE TABLE [dbo].[Restaurante] (
    [IdRestaurante] int IDENTITY(1,1) NOT NULL,
    [Nome] nvarchar(max)  NOT NULL,
    [Morada_IdMorada] int  NOT NULL
);
GO

-- Creating table 'MoradaSet'
CREATE TABLE [dbo].[MoradaSet] (
    [IdMorada] int IDENTITY(1,1) NOT NULL,
    [Rua] nvarchar(max)  NOT NULL,
    [Cidade] nvarchar(max)  NOT NULL,
    [CodPostal] int  NOT NULL,
    [Pais] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'ItemMenuSet'
CREATE TABLE [dbo].[ItemMenuSet] (
    [IdItemMenu] int IDENTITY(1,1) NOT NULL,
    [CategoriaIdCategoria] int  NOT NULL,
    [Nome] nvarchar(max)  NOT NULL,
    [Fotografia] nvarchar(max)  NOT NULL,
    [Ingredientes] nvarchar(max)  NOT NULL,
    [Precos] float  NOT NULL,
    [Ativo] bit  NOT NULL
);
GO

-- Creating table 'PedidoSet'
CREATE TABLE [dbo].[PedidoSet] (
    [IdPedido] int IDENTITY(1,1) NOT NULL,
    [EstadoPedidoIdEstado] int  NOT NULL,
    [ValorTotal] float  NOT NULL,
    [Trabalhador_IdPessoa] int  NOT NULL,
    [Cliente_IdPessoa] int  NOT NULL,
    [Restaurante_IdRestaurante] int  NOT NULL
);
GO

-- Creating table 'EstadoPedidoSet'
CREATE TABLE [dbo].[EstadoPedidoSet] (
    [IdEstado] int IDENTITY(1,1) NOT NULL,
    [Estado] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'PagamentoSet'
CREATE TABLE [dbo].[PagamentoSet] (
    [IdPagamento] int IDENTITY(1,1) NOT NULL,
    [Valor] float  NOT NULL,
    [Pedido_IdPedido] int  NOT NULL,
    [MetodoPagamento_IdMetodo] int  NOT NULL
);
GO

-- Creating table 'MetodoPagamentoSet'
CREATE TABLE [dbo].[MetodoPagamentoSet] (
    [IdMetodo] int IDENTITY(1,1) NOT NULL,
    [MetododePagamento] nvarchar(max)  NOT NULL,
    [Ativo] bit  NOT NULL
);
GO

-- Creating table 'CategoriaSet'
CREATE TABLE [dbo].[CategoriaSet] (
    [IdCategoria] int IDENTITY(1,1) NOT NULL,
    [Nome] nvarchar(max)  NOT NULL,
    [Ativo] bit  NOT NULL
);
GO

-- Creating table 'Pessoa_Trabalhador'
CREATE TABLE [dbo].[Pessoa_Trabalhador] (
    [Salario] float  NOT NULL,
    [Posicao] nvarchar(max)  NOT NULL,
    [IdPessoa] int  NOT NULL,
    [Restaurante_IdRestaurante] int  NOT NULL
);
GO

-- Creating table 'Pessoa_Cliente'
CREATE TABLE [dbo].[Pessoa_Cliente] (
    [TotalGasto] float  NOT NULL,
    [NumContribuinte] int  NOT NULL,
    [IdPessoa] int  NOT NULL
);
GO

-- Creating table 'ItemMenuRestaurante'
CREATE TABLE [dbo].[ItemMenuRestaurante] (
    [ItemMenu_IdItemMenu] int  NOT NULL,
    [Restaurante_IdRestaurante] int  NOT NULL
);
GO

-- Creating table 'PedidoItemMenu'
CREATE TABLE [dbo].[PedidoItemMenu] (
    [Pedido_IdPedido] int  NOT NULL,
    [ItemMenu_IdItemMenu] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [IdPessoa] in table 'Pessoa'
ALTER TABLE [dbo].[Pessoa]
ADD CONSTRAINT [PK_Pessoa]
    PRIMARY KEY CLUSTERED ([IdPessoa] ASC);
GO

-- Creating primary key on [IdRestaurante] in table 'Restaurante'
ALTER TABLE [dbo].[Restaurante]
ADD CONSTRAINT [PK_Restaurante]
    PRIMARY KEY CLUSTERED ([IdRestaurante] ASC);
GO

-- Creating primary key on [IdMorada] in table 'MoradaSet'
ALTER TABLE [dbo].[MoradaSet]
ADD CONSTRAINT [PK_MoradaSet]
    PRIMARY KEY CLUSTERED ([IdMorada] ASC);
GO

-- Creating primary key on [IdItemMenu] in table 'ItemMenuSet'
ALTER TABLE [dbo].[ItemMenuSet]
ADD CONSTRAINT [PK_ItemMenuSet]
    PRIMARY KEY CLUSTERED ([IdItemMenu] ASC);
GO

-- Creating primary key on [IdPedido] in table 'PedidoSet'
ALTER TABLE [dbo].[PedidoSet]
ADD CONSTRAINT [PK_PedidoSet]
    PRIMARY KEY CLUSTERED ([IdPedido] ASC);
GO

-- Creating primary key on [IdEstado] in table 'EstadoPedidoSet'
ALTER TABLE [dbo].[EstadoPedidoSet]
ADD CONSTRAINT [PK_EstadoPedidoSet]
    PRIMARY KEY CLUSTERED ([IdEstado] ASC);
GO

-- Creating primary key on [IdPagamento] in table 'PagamentoSet'
ALTER TABLE [dbo].[PagamentoSet]
ADD CONSTRAINT [PK_PagamentoSet]
    PRIMARY KEY CLUSTERED ([IdPagamento] ASC);
GO

-- Creating primary key on [IdMetodo] in table 'MetodoPagamentoSet'
ALTER TABLE [dbo].[MetodoPagamentoSet]
ADD CONSTRAINT [PK_MetodoPagamentoSet]
    PRIMARY KEY CLUSTERED ([IdMetodo] ASC);
GO

-- Creating primary key on [IdCategoria] in table 'CategoriaSet'
ALTER TABLE [dbo].[CategoriaSet]
ADD CONSTRAINT [PK_CategoriaSet]
    PRIMARY KEY CLUSTERED ([IdCategoria] ASC);
GO

-- Creating primary key on [IdPessoa] in table 'Pessoa_Trabalhador'
ALTER TABLE [dbo].[Pessoa_Trabalhador]
ADD CONSTRAINT [PK_Pessoa_Trabalhador]
    PRIMARY KEY CLUSTERED ([IdPessoa] ASC);
GO

-- Creating primary key on [IdPessoa] in table 'Pessoa_Cliente'
ALTER TABLE [dbo].[Pessoa_Cliente]
ADD CONSTRAINT [PK_Pessoa_Cliente]
    PRIMARY KEY CLUSTERED ([IdPessoa] ASC);
GO

-- Creating primary key on [ItemMenu_IdItemMenu], [Restaurante_IdRestaurante] in table 'ItemMenuRestaurante'
ALTER TABLE [dbo].[ItemMenuRestaurante]
ADD CONSTRAINT [PK_ItemMenuRestaurante]
    PRIMARY KEY CLUSTERED ([ItemMenu_IdItemMenu], [Restaurante_IdRestaurante] ASC);
GO

-- Creating primary key on [Pedido_IdPedido], [ItemMenu_IdItemMenu] in table 'PedidoItemMenu'
ALTER TABLE [dbo].[PedidoItemMenu]
ADD CONSTRAINT [PK_PedidoItemMenu]
    PRIMARY KEY CLUSTERED ([Pedido_IdPedido], [ItemMenu_IdItemMenu] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [Morada_IdMorada] in table 'Pessoa'
ALTER TABLE [dbo].[Pessoa]
ADD CONSTRAINT [FK_PessoaMorada]
    FOREIGN KEY ([Morada_IdMorada])
    REFERENCES [dbo].[MoradaSet]
        ([IdMorada])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PessoaMorada'
CREATE INDEX [IX_FK_PessoaMorada]
ON [dbo].[Pessoa]
    ([Morada_IdMorada]);
GO

-- Creating foreign key on [Restaurante_IdRestaurante] in table 'Pessoa_Trabalhador'
ALTER TABLE [dbo].[Pessoa_Trabalhador]
ADD CONSTRAINT [FK_TrabalhadorRestaurante]
    FOREIGN KEY ([Restaurante_IdRestaurante])
    REFERENCES [dbo].[Restaurante]
        ([IdRestaurante])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_TrabalhadorRestaurante'
CREATE INDEX [IX_FK_TrabalhadorRestaurante]
ON [dbo].[Pessoa_Trabalhador]
    ([Restaurante_IdRestaurante]);
GO

-- Creating foreign key on [ItemMenu_IdItemMenu] in table 'ItemMenuRestaurante'
ALTER TABLE [dbo].[ItemMenuRestaurante]
ADD CONSTRAINT [FK_ItemMenuRestaurante_ItemMenu]
    FOREIGN KEY ([ItemMenu_IdItemMenu])
    REFERENCES [dbo].[ItemMenuSet]
        ([IdItemMenu])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Restaurante_IdRestaurante] in table 'ItemMenuRestaurante'
ALTER TABLE [dbo].[ItemMenuRestaurante]
ADD CONSTRAINT [FK_ItemMenuRestaurante_Restaurante]
    FOREIGN KEY ([Restaurante_IdRestaurante])
    REFERENCES [dbo].[Restaurante]
        ([IdRestaurante])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ItemMenuRestaurante_Restaurante'
CREATE INDEX [IX_FK_ItemMenuRestaurante_Restaurante]
ON [dbo].[ItemMenuRestaurante]
    ([Restaurante_IdRestaurante]);
GO

-- Creating foreign key on [Morada_IdMorada] in table 'Restaurante'
ALTER TABLE [dbo].[Restaurante]
ADD CONSTRAINT [FK_RestauranteMorada]
    FOREIGN KEY ([Morada_IdMorada])
    REFERENCES [dbo].[MoradaSet]
        ([IdMorada])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_RestauranteMorada'
CREATE INDEX [IX_FK_RestauranteMorada]
ON [dbo].[Restaurante]
    ([Morada_IdMorada]);
GO

-- Creating foreign key on [Trabalhador_IdPessoa] in table 'PedidoSet'
ALTER TABLE [dbo].[PedidoSet]
ADD CONSTRAINT [FK_PedidoTrabalhador]
    FOREIGN KEY ([Trabalhador_IdPessoa])
    REFERENCES [dbo].[Pessoa_Trabalhador]
        ([IdPessoa])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PedidoTrabalhador'
CREATE INDEX [IX_FK_PedidoTrabalhador]
ON [dbo].[PedidoSet]
    ([Trabalhador_IdPessoa]);
GO

-- Creating foreign key on [Cliente_IdPessoa] in table 'PedidoSet'
ALTER TABLE [dbo].[PedidoSet]
ADD CONSTRAINT [FK_PedidoCliente]
    FOREIGN KEY ([Cliente_IdPessoa])
    REFERENCES [dbo].[Pessoa_Cliente]
        ([IdPessoa])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PedidoCliente'
CREATE INDEX [IX_FK_PedidoCliente]
ON [dbo].[PedidoSet]
    ([Cliente_IdPessoa]);
GO

-- Creating foreign key on [Restaurante_IdRestaurante] in table 'PedidoSet'
ALTER TABLE [dbo].[PedidoSet]
ADD CONSTRAINT [FK_PedidoRestaurante]
    FOREIGN KEY ([Restaurante_IdRestaurante])
    REFERENCES [dbo].[Restaurante]
        ([IdRestaurante])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PedidoRestaurante'
CREATE INDEX [IX_FK_PedidoRestaurante]
ON [dbo].[PedidoSet]
    ([Restaurante_IdRestaurante]);
GO

-- Creating foreign key on [Pedido_IdPedido] in table 'PedidoItemMenu'
ALTER TABLE [dbo].[PedidoItemMenu]
ADD CONSTRAINT [FK_PedidoItemMenu_Pedido]
    FOREIGN KEY ([Pedido_IdPedido])
    REFERENCES [dbo].[PedidoSet]
        ([IdPedido])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [ItemMenu_IdItemMenu] in table 'PedidoItemMenu'
ALTER TABLE [dbo].[PedidoItemMenu]
ADD CONSTRAINT [FK_PedidoItemMenu_ItemMenu]
    FOREIGN KEY ([ItemMenu_IdItemMenu])
    REFERENCES [dbo].[ItemMenuSet]
        ([IdItemMenu])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PedidoItemMenu_ItemMenu'
CREATE INDEX [IX_FK_PedidoItemMenu_ItemMenu]
ON [dbo].[PedidoItemMenu]
    ([ItemMenu_IdItemMenu]);
GO

-- Creating foreign key on [EstadoPedidoIdEstado] in table 'PedidoSet'
ALTER TABLE [dbo].[PedidoSet]
ADD CONSTRAINT [FK_EstadoPedidoPedido]
    FOREIGN KEY ([EstadoPedidoIdEstado])
    REFERENCES [dbo].[EstadoPedidoSet]
        ([IdEstado])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_EstadoPedidoPedido'
CREATE INDEX [IX_FK_EstadoPedidoPedido]
ON [dbo].[PedidoSet]
    ([EstadoPedidoIdEstado]);
GO

-- Creating foreign key on [Pedido_IdPedido] in table 'PagamentoSet'
ALTER TABLE [dbo].[PagamentoSet]
ADD CONSTRAINT [FK_PagamentoPedido]
    FOREIGN KEY ([Pedido_IdPedido])
    REFERENCES [dbo].[PedidoSet]
        ([IdPedido])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PagamentoPedido'
CREATE INDEX [IX_FK_PagamentoPedido]
ON [dbo].[PagamentoSet]
    ([Pedido_IdPedido]);
GO

-- Creating foreign key on [MetodoPagamento_IdMetodo] in table 'PagamentoSet'
ALTER TABLE [dbo].[PagamentoSet]
ADD CONSTRAINT [FK_PagamentoMetodoPagamento]
    FOREIGN KEY ([MetodoPagamento_IdMetodo])
    REFERENCES [dbo].[MetodoPagamentoSet]
        ([IdMetodo])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PagamentoMetodoPagamento'
CREATE INDEX [IX_FK_PagamentoMetodoPagamento]
ON [dbo].[PagamentoSet]
    ([MetodoPagamento_IdMetodo]);
GO

-- Creating foreign key on [CategoriaIdCategoria] in table 'ItemMenuSet'
ALTER TABLE [dbo].[ItemMenuSet]
ADD CONSTRAINT [FK_CategoriaItemMenu]
    FOREIGN KEY ([CategoriaIdCategoria])
    REFERENCES [dbo].[CategoriaSet]
        ([IdCategoria])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CategoriaItemMenu'
CREATE INDEX [IX_FK_CategoriaItemMenu]
ON [dbo].[ItemMenuSet]
    ([CategoriaIdCategoria]);
GO

-- Creating foreign key on [IdPessoa] in table 'Pessoa_Trabalhador'
ALTER TABLE [dbo].[Pessoa_Trabalhador]
ADD CONSTRAINT [FK_Trabalhador_inherits_Pessoa]
    FOREIGN KEY ([IdPessoa])
    REFERENCES [dbo].[Pessoa]
        ([IdPessoa])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating foreign key on [IdPessoa] in table 'Pessoa_Cliente'
ALTER TABLE [dbo].[Pessoa_Cliente]
ADD CONSTRAINT [FK_Cliente_inherits_Pessoa]
    FOREIGN KEY ([IdPessoa])
    REFERENCES [dbo].[Pessoa]
        ([IdPessoa])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------