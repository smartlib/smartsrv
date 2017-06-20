CREATE TABLE [dbo].[Interval] (
    [Code]     VARCHAR (10) NOT NULL,
    [TimeSpan] BIGINT       NOT NULL,
    [Seconds]  AS           (CONVERT([float],[TimeSpan])/(10000000)),
    [Minutes]  AS           (CONVERT([float],[TimeSpan])/((60)*(10000000))),
    [Hours]    AS           (CONVERT([float],[TimeSpan])/((CONVERT([float],(60))*(60))*(10000000))),
    [Days]     AS           (CONVERT([float],[TimeSpan])/(((CONVERT([float],(24))*(60))*(60))*(10000000))),
    [Weeks]    AS           (CONVERT([float],[TimeSpan])/((((CONVERT([float],(7))*(24))*(60))*(60))*(10000000))),
    [Months]   AS           (CONVERT([float],[TimeSpan])/((((CONVERT([float],(30))*(24))*(60))*(60))*(10000000))),
    [Years]    AS           (CONVERT([float],[TimeSpan])/((((CONVERT([float],(365))*(24))*(60))*(60))*(10000000))),
    CONSTRAINT [PK_Interval] PRIMARY KEY CLUSTERED ([Code] ASC)
);



