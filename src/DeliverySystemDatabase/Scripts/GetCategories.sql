CREATE PROCEDURE [dbo].[GetCategories]
as
begin
	set nocount on;
	select*
	from Category
	where IsActive = 1
end
