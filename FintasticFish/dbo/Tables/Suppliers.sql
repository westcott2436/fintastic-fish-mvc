CREATE TABLE [dbo].[Suppliers] (
    [Id]             INT            IDENTITY (1, 1) NOT NULL,
    [Name]           NVARCHAR (100) NOT NULL,
    [ContactName]    NVARCHAR (100) NOT NULL,
    [Phone]          NVARCHAR (20)  NOT NULL,
    [Email]          NVARCHAR (100) NOT NULL,
    [Website]        NVARCHAR (100) NOT NULL,
    [SupplierTypeId] INT            NOT NULL,
    [Notes]          NVARCHAR (100) NOT NULL,
    [CountryId]      INT            NOT NULL,
    CONSTRAINT [PK_Suppliers] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Suppliers_Countries] FOREIGN KEY ([CountryId]) REFERENCES [dbo].[Countries] ([Id]),
    CONSTRAINT [FK_Suppliers_Suppliers] FOREIGN KEY ([SupplierTypeId]) REFERENCES [dbo].[SupplierTypes] ([Id])
);

