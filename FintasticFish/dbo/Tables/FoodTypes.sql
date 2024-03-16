CREATE TABLE [dbo].[FoodTypes] (
    [Id]   INT            IDENTITY (1, 1) NOT NULL,
    [Name] NVARCHAR (100) NOT NULL,
    CONSTRAINT [PK_FoodTypes] PRIMARY KEY CLUSTERED ([Id] ASC)
);

