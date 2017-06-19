CREATE TABLE [dbo].[Interval] (
    [Code] VARCHAR (10) NOT NULL,
    [TimeSpan] BIGINT NOT NULL, 
    [Seconds] as cast(TimeSpan as float)/10000000, 
	[Minutes] as cast(TimeSpan as float)/(60 * 10000000), 
	[Hours] as cast(TimeSpan as float)/(cast(60 as float) * 60 * 10000000), 
    [Days] as cast(TimeSpan as float)/(cast(24 as float) * 60 * 60 * 10000000),
    [Weeks] as cast(TimeSpan as float)/(cast(7 as float) * 24 * 60 * 60 * 10000000),
    [Months] as cast(TimeSpan as float)/(cast(30 as float) * 24 * 60 * 60 * 10000000), 
	[Years] as cast(TimeSpan as float)/(cast(365 as float) * 24 * 60 * 60 * 10000000), 
    CONSTRAINT [PK_Interval] PRIMARY KEY CLUSTERED ([Code] ASC)
);

