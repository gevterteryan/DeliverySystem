CREATE PROCEDURE [dbo].[RateOrder]
	@UserID int,
	@RestID int,
	@OrderRating tinyint
AS
BEGIN
		UPDATE UsersRating
		SET Rate = @OrderRating
		where UserID = @UserID and RestID = @RestID
END
