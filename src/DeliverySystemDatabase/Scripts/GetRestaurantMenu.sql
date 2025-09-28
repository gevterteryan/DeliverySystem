create procedure [dbo].[GetRestaurantMenu]
(
	@RestaurantID int
)
as
begin
	set nocount on;
	select*
	from Item
	where RestID = @RestaurantID and IsActive = 1
end