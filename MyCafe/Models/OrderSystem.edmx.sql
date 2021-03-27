
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 10/09/2019 17:47:08
-- Generated from EDMX file: C:\Users\mic18\Documents\GitHub\Web_Learning\MyWeb\MyCafe_v1.5\MyCafe_v1.5\Models\OrderSystem.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [Restaurant];
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

-- Creating table 'Employees'
CREATE TABLE [dbo].[Employees] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [FirstName] nvarchar(20)  NOT NULL,
    [LastName] nvarchar(20)  NOT NULL,
    [Birthday] datetime  NOT NULL,
    [RegisterTime] datetime  NOT NULL
);
GO

-- Creating table 'Menus'
CREATE TABLE [dbo].[Menus] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(50)  NOT NULL,
    [Price] int  NOT NULL,
    [Description] nvarchar(max)  NOT NULL,
    [EmployeeId] int  NOT NULL,
    [MCreateTime] datetime  NOT NULL
);
GO

-- Creating table 'Orders'
CREATE TABLE [dbo].[Orders] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [EmployeeId] int  NOT NULL,
    [CreateTime] datetime  NOT NULL,
    [ProcessTime] datetime  NULL
);
GO

-- Creating table 'Order_Detail'
CREATE TABLE [dbo].[Order_Detail] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [MenuId] int  NOT NULL,
    [OrderId] int  NOT NULL,
	[Number] int Not Null,
    [GenerateTime] datetime  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'Employees'
ALTER TABLE [dbo].[Employees]
ADD CONSTRAINT [PK_Employees]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Menus'
ALTER TABLE [dbo].[Menus]
ADD CONSTRAINT [PK_Menus]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Orders'
ALTER TABLE [dbo].[Orders]
ADD CONSTRAINT [PK_Orders]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Order_Detail'
ALTER TABLE [dbo].[Order_Detail]
ADD CONSTRAINT [PK_Order_Detail]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [EmployeeId] in table 'Menus'
ALTER TABLE [dbo].[Menus]
ADD CONSTRAINT [FK_EmployeeMenu]
    FOREIGN KEY ([EmployeeId])
    REFERENCES [dbo].[Employees]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_EmployeeMenu'
CREATE INDEX [IX_FK_EmployeeMenu]
ON [dbo].[Menus]
    ([EmployeeId]);
GO

-- Creating foreign key on [EmployeeId] in table 'Orders'
ALTER TABLE [dbo].[Orders]
ADD CONSTRAINT [FK_EmployeeOrder]
    FOREIGN KEY ([EmployeeId])
    REFERENCES [dbo].[Employees]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_EmployeeOrder'
CREATE INDEX [IX_FK_EmployeeOrder]
ON [dbo].[Orders]
    ([EmployeeId]);
GO

-- Creating foreign key on [MenuId] in table 'Order_Detail'
ALTER TABLE [dbo].[Order_Detail]
ADD CONSTRAINT [FK_MenuOrder_Detail]
    FOREIGN KEY ([MenuId])
    REFERENCES [dbo].[Menus]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_MenuOrder_Detail'
CREATE INDEX [IX_FK_MenuOrder_Detail]
ON [dbo].[Order_Detail]
    ([MenuId]);
GO

-- Creating foreign key on [OrderId] in table 'Order_Detail'
ALTER TABLE [dbo].[Order_Detail]
ADD CONSTRAINT [FK_OrderOrder_Detail]
    FOREIGN KEY ([OrderId])
    REFERENCES [dbo].[Orders]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_OrderOrder_Detail'
CREATE INDEX [IX_FK_OrderOrder_Detail]
ON [dbo].[Order_Detail]
    ([OrderId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------