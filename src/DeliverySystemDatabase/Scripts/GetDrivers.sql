create procedure [dbo].[GetDrivers]
as
begin
	set nocount on;
	select*
	from Drivers d left join Orders o on d.ID = o.Driver
	where d.IsNowDriving = 1
end