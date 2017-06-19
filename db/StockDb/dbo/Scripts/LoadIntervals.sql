print('load intervals');

merge into dbo.Interval d
using(
	values
	  ('TICK', 1)
	, ('S1', 10000000)
	, ('S2', 2 * 10000000)
	, ('S3', 3 * 10000000)
	, ('S4', 4 * 10000000)
	, ('S5', 5 * 10000000)
	, ('S6', 6 * 10000000)
	, ('S10', 10 * 10000000)
	, ('S12', 12 * 10000000)
	, ('S15', 15 * 10000000)
	, ('S20', 20 * 10000000)
	, ('S30', 30 * 10000000)
	, ('M1', 60 * 10000000)
	, ('M2', 2 * 60 * 10000000)
	, ('M3', 3 * 60 * 10000000)
	, ('M4', cast(4 as bigint) * 60 * 10000000)
	, ('M5', cast(5 as bigint) * 60 * 10000000)
	, ('M6', cast(6 as bigint) * 60 * 10000000)
	, ('M10', cast(10 as bigint) * 60 * 10000000)
	, ('M12', cast(12 as bigint) * 60 * 10000000)
	, ('M15', cast(15 as bigint) * 60 * 10000000)
	, ('M20', cast(20 as bigint) * 60 * 10000000)
	, ('M30', cast(30 as bigint) * 60 * 10000000)
	, ('H1', cast(60 as bigint) * 60 * 10000000)
	, ('H2', cast(2 as bigint) * 60 * 60 * 10000000)
	, ('H3', cast(3 as bigint) * 60 * 60 * 10000000)
	, ('H4', cast(4 as bigint) * 60 * 60 * 10000000)
	, ('H6', cast(6 as bigint) * 60 * 60 * 10000000)
	, ('H8', cast(8 as bigint) * 60 * 60 * 10000000)
	, ('H12', cast(12 as bigint) * 60 * 60 * 10000000)
	, ('D', cast(1 as bigint) * 24 * 60 * 60 * 10000000)
	, ('W', cast(7 as bigint) * 24 * 60 * 60 * 10000000)
	, ('MN', cast(30 as bigint) * 24 * 60 * 60 * 10000000)
	, ('Y', cast(365 as bigint) * 24 * 60 * 60 * 10000000)
) as s (Code, TimeSpan)
on s.Code = d.Code
when not matched then
insert (Code, TimeSpan) values(s.Code, TimeSpan)
when matched then
update set TimeSpan = s.TimeSpan;