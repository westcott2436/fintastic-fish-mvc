CREATE TABLE [dbo].[Measurements] (
    [Id]   INT            IDENTITY (1, 1) NOT NULL,
    [Name] NVARCHAR (100) NOT NULL,
    CONSTRAINT [PK_Measurements] PRIMARY KEY CLUSTERED ([Id] ASC)
);

