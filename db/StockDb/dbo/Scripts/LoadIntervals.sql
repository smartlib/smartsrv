print('load intervals');

--merge into dbo.Intervals d
--using(
--	select Code from
--	values(('M1')) as s (Code)
--) as s
--on s.Code = d.Code
--when not matched then
--insert (Code) values(s.Code);