create table OrderDetail(
	OrderID int			  not null,
	ItemID  int			  not null,
	ItemCount tinyint     not null,
	constraint OrderDetailOrderID_FR_KEY foreign key (OrderID) references Orders(ID),
	constraint OrderDetailItemID_FR_KEY foreign key (ItemID) references Item(ID)
)