CREATE TABLE [dbo].[SupplierTypes] (
    [Id]   INT            IDENTITY (1, 1) NOT NULL,
    [Name] NVARCHAR (100) NOT NULL,
    CONSTRAINT [PK_SupplierTypes] PRIMARY KEY CLUSTERED ([Id] ASC)
);

