CREATE TABLE [dbo].[ImportDataHistory] (
    [Id]           INT      IDENTITY (1, 1) NOT NULL,
    [ImportDataId] INT      NOT NULL,
    [ImportData]   DATETIME NOT NULL,
    [DateTimeFrom] DATETIME NOT NULL,
    [DateTimeTo]   DATETIME NOT NULL,
    [Count]        INT      NOT NULL,
    CONSTRAINT [PK_ImportDataHistory] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_ImportDataHistory_ImportData] FOREIGN KEY ([ImportDataId]) REFERENCES [dbo].[ImportData] ([Id])
);

