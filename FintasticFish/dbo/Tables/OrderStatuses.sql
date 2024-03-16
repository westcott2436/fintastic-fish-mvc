CREATE TABLE [dbo].[OrderStatuses] (
    [Id]   INT            IDENTITY (1, 1) NOT NULL,
    [Name] NVARCHAR (100) NOT NULL,
    CONSTRAINT [PK_OrderStatuses] PRIMARY KEY CLUSTERED ([Id] ASC)
);

