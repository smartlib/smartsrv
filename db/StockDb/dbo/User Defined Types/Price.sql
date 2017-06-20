CREATE TYPE [dbo].[Price] AS TABLE (
    [DateTime] DATETIME   NOT NULL,
    [Open]     FLOAT (53) NOT NULL,
    [Max]      FLOAT (53) NOT NULL,
    [Min]      FLOAT (53) NOT NULL,
    [Close]    FLOAT (53) NOT NULL,
    PRIMARY KEY CLUSTERED ([DateTime] ASC));

