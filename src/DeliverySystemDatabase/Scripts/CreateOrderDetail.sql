CREATE PROCEDURE [dbo].[CreateOrderDetail]
		@OrderId INT,
		@ItemID  INT,
		@ItemCount INT
AS
BEGIN
	INSERT INTO OrderDetail(OrderID,ItemID,ItemCount)
	VALUES(@OrderID,@ItemID,@ItemCount)
END