CREATE PROCEDURE [dbo].[GetRestaurants]

AS
BEGIN
	SET NOCOUNT ON;
	SELECT R.*,C.CatName
	FROM Restaurant R JOIN Category C on R.CatID = C.ID
	WHERE R.IsActive =1
END