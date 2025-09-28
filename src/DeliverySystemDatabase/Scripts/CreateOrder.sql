CREATE PROCEDURE [dbo].[CreateOrder]
	-- Add the parameters for the stored procedure here
	@UserID int,
	@RestaurantID int,
	@TotalPrice money,
	@DeliveryPrice money,
	@OrderAddress nvarchar(35),
	@PhoneNumber nvarchar(15),
	@OrderID int out
AS
BEGIN 
	SET NOCOUNT ON;

	INSERT INTO Orders(UserID, RestaurantID,TotalPrice,DeliveryPrice,OrderAddress,PhoneNumber)
	VALUES(@UserID, @RestaurantID,@TotalPrice,@DeliveryPrice,@OrderAddress,@PhoneNumber)
	set @OrderID= SCOPE_IDENTITY()
END