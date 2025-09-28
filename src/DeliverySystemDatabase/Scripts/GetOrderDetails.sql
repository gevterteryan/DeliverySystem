CREATE PROCEDURE [dbo].[GetOrderDetails]
		@OrderID int
AS
BEGIN
	SELECT*
	FROM OrderDetail
	WHERE OrderID=@OrderID 
END
