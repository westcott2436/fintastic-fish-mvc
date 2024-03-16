CREATE TABLE [dbo].[Addresses] (
    [Id]            INT            IDENTITY (1, 1) NOT NULL,
    [Street1]       NVARCHAR (100) NOT NULL,
    [Street2]       NVARCHAR (100) NOT NULL,
    [City]          NVARCHAR (100) NOT NULL,
    [StateId]       INT            NOT NULL,
    [CountryId]     INT            NOT NULL,
    [PostalCode]    INT            NOT NULL,
    [AddressTypeId] INT            NOT NULL,
    CONSTRAINT [PK_Addresses] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Addresses_AddressTypes] FOREIGN KEY ([AddressTypeId]) REFERENCES [dbo].[AddressTypes] ([Id]),
    CONSTRAINT [FK_Addresses_Countries] FOREIGN KEY ([CountryId]) REFERENCES [dbo].[Countries] ([Id]),
    CONSTRAINT [FK_Addresses_States] FOREIGN KEY ([StateId]) REFERENCES [dbo].[States] ([Id])
);

