CREATE TABLE [dbo].[WaterType] (
    [Id]   INT            IDENTITY (1, 1) NOT NULL,
    [Name] NVARCHAR (100) NOT NULL,
    CONSTRAINT [PK_WaterType] PRIMARY KEY CLUSTERED ([Id] ASC)
);

