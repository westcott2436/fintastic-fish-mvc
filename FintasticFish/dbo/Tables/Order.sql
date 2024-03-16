CREATE TABLE [dbo].[Order] (
    [Id]            INT        IDENTITY (1, 1) NOT NULL,
    [OrderDate]     DATE       NOT NULL,
    [Total]         FLOAT (53) NOT NULL,
    [AddressId]     INT        NOT NULL,
    [CustomerId]    INT        NOT NULL,
    [OrderStatusId] INT        NOT NULL,
    CONSTRAINT [PK_Order] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Order_Addresses] FOREIGN KEY ([AddressId]) REFERENCES [dbo].[Addresses] ([Id]),
    CONSTRAINT [FK_Order_Customers] FOREIGN KEY ([CustomerId]) REFERENCES [dbo].[Customers] ([Id]),
    CONSTRAINT [FK_Order_OrderStatuses1] FOREIGN KEY ([OrderStatusId]) REFERENCES [dbo].[OrderStatuses] ([Id])
);

