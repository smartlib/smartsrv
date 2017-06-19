CREATE TABLE [dbo].[Symbol] (
    [Code]  VARCHAR (20) NOT NULL,
    [LCurr] VARCHAR (10) NOT NULL,
    [RCurr] VARCHAR (10) NOT NULL,
    CONSTRAINT [PK_Symbol] PRIMARY KEY CLUSTERED ([Code] ASC),
    CONSTRAINT [FK_Symbol_LCurr] FOREIGN KEY ([LCurr]) REFERENCES [dbo].[Currency] ([Code]),
    CONSTRAINT [FK_Symbol_RCurr] FOREIGN KEY ([RCurr]) REFERENCES [dbo].[Currency] ([Code]),
    CONSTRAINT [UK_Symbol_LCurr_RCurr] UNIQUE NONCLUSTERED ([LCurr] ASC, [RCurr] ASC)
);



