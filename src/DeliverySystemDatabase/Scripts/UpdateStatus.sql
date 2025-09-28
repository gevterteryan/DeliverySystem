CREATE PROCEDURE UpdateStatus
(
    @OrderID	  INT,
    @PriorityCode INT,
	@DriverID	  INT = NULL
)
AS
BEGIN
	SET NOCOUNT ON; 
	UPDATE Orders 
    SET PriorityCode = @PriorityCode,
    Place = IIF(@PriorityCode = 0, SYSDATETIME(), Place),
	Assign = IIF(@PriorityCode=1 and @DriverID is not null, SYSDATETIME(),Assign),
	Driver = IIF(@PriorityCode=1 and @DriverID is not null, @DriverID, Driver),
    Arrive = IIF(@PriorityCode = 2, SYSDATETIME(), Arrive),
    Depart = IIF(@PriorityCode = 3, SYSDATETIME(), Depart),
    Complete = IIF(@PriorityCode = 4, SYSDATETIME(), Complete)

	OUTPUT inserted.ID,d.DriverType,d.ID as DriverID,d.FirstName as DriverName,inserted.TotalPrice,r.Name as RestaurantName,inserted.OrderAddress, u.FirstName, u.LastName,inserted.PhoneNumber, 
		   u.OrdersCount,inserted.PriorityCode, inserted.OrderStart,inserted.Place,inserted.Pickup,inserted.Assign,inserted.Arrive,inserted.Depart,inserted.Complete
	from Orders o left join Restaurant r on o.RestaurantID = r.ID
			left join Users u on o.UserID = u.ID left join Drivers d on d.Id = ISNULL(@DriverId, o.Driver)
    where o.ID = @OrderID
end