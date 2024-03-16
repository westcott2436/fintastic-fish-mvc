CREATE TABLE [dbo].[Foods] (
    [Id]             INT            IDENTITY (1, 1) NOT NULL,
    [Name]           NVARCHAR (100) NOT NULL,
    [Price]          FLOAT (53)     NOT NULL,
    [SalePrice]      FLOAT (53)     NOT NULL,
    [Size]           FLOAT (53)     NOT NULL,
    [Taxable]        FLOAT (53)     NOT NULL,
    [Stock]          INT            CONSTRAINT [DF_Foods_Stock] DEFAULT ((0)) NOT NULL,
    [SaleStartDate]  DATE           NOT NULL,
    [SaleEndDate]    DATE           NOT NULL,
    [FoodTypeId]     INT            NOT NULL,
    [MearsurementId] INT            NOT NULL,
    CONSTRAINT [PK_Foods] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Foods_FoodTypes] FOREIGN KEY ([FoodTypeId]) REFERENCES [dbo].[FoodTypes] ([Id]),
    CONSTRAINT [FK_Foods_Measurements] FOREIGN KEY ([MearsurementId]) REFERENCES [dbo].[Measurements] ([Id]) 
);

