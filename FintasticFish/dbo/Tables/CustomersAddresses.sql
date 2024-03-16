CREATE TABLE [dbo].[CustomersAddresses] (
    [CustomerId] INT NOT NULL,
    [AddressId]  INT NOT NULL,
    CONSTRAINT [FK_CustomersAddresses_Addresses] FOREIGN KEY ([AddressId]) REFERENCES [dbo].[Addresses] ([Id]),
    CONSTRAINT [FK_CustomersAddresses_Customers] FOREIGN KEY ([CustomerId]) REFERENCES [dbo].[Customers] ([Id])
);

