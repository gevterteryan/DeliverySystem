create procedure [dbo].[GetAllOrders]

as
begin
	set nocount on;
	select Drivers.ID as DriverID, Drivers.FirstName as DriverName,*
	from Orders left join Restaurant on Orders.RestaurantID = Restaurant.ID
			left join Users on Orders.UserID = Users.ID left join Drivers on Orders.Driver = Drivers.ID
			where OrderStart >= cast(sysdatetime() as date) and OrderStart < dateadd(day, 1, cast(sysdatetime() as date))
			order by OrderStart
end	