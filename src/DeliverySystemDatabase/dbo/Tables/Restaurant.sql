create table Restaurant(
	ID int identity(1,1)	 not null, 
	CatID int				 not null,
	Name      nvarchar(30)	 not null,
	RestImage varbinary(max) not null,
	DeliveryPrice money			 null,
	OpeningDate time		 not null,
	ClosingDate time		 not null,
	Rating		decimal(2,1)	 null,
	IsActive	bit		     not null,
	constraint RestID_PR_KEY primary key (ID),
	constraint RestCatID_FR_KEY foreign key (CatID) references Category(ID),
)