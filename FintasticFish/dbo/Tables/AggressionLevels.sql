CREATE TABLE [dbo].[AggressionLevels] (
    [Id]   INT            IDENTITY (1, 1) NOT NULL,
    [Name] NVARCHAR (100) NULL,
    CONSTRAINT [PK_AggressionLevels] PRIMARY KEY CLUSTERED ([Id] ASC)
);

