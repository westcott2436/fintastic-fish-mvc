CREATE TABLE [dbo].[States] (
    [Id]   INT            IDENTITY (1, 1) NOT NULL,
    [Name] NVARCHAR (100) NOT NULL,
    CONSTRAINT [PK_States] PRIMARY KEY CLUSTERED ([Id] ASC)
);

