CREATE TABLE [dbo].[ImportData] (
    [Id]             INT           IDENTITY (1, 1) NOT NULL,
    [DataSourceCode] VARCHAR (10)  NOT NULL,
    [IntervalCode]   VARCHAR (10)  NOT NULL,
    [SymbolCode]     VARCHAR (10)  NOT NULL,
    [TableName]      VARCHAR (255) NOT NULL,
    CONSTRAINT [PK_ImportData] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_ImportData_DataSource] FOREIGN KEY ([DataSourceCode]) REFERENCES [dbo].[DataSource] ([Code]),
    CONSTRAINT [FK_ImportData_Interval] FOREIGN KEY ([IntervalCode]) REFERENCES [dbo].[Interval] ([Code]),
    CONSTRAINT [FK_ImportData_Symbol] FOREIGN KEY ([SymbolCode]) REFERENCES [dbo].[Symbol] ([Code])
);

