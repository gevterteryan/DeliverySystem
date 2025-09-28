create procedure [dbo].[GetOrders]

as
begin
	set nocount on;
	select d.ID as DriverID,d.FirstName as DriverName,r.Name as RestaurantName, *
	from Orders o left join Restaurant r on o.RestaurantID = r.ID
			left join Users u on o.UserID = u.ID left join Drivers d on o.Driver = d.ID
	where PriorityCode <> 4
end