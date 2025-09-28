create table Item(
	ID int identity(1,1)      not null,
	RestID int				  not null,
	ItemCatID int			not null,
	Name nvarchar(50)		  not null,
	Description nvarchar(256) not null,
	Price money				  not null,
	Picture varbinary(max)	  null,
	[IsActive] bit		      not null,
	constraint ItemID_PR_KEY primary key (ID),
	constraint ItemRestID_FR_KEY foreign key (RestID) references Restaurant(ID),
	constraint ItemCatID_FR_KEY foreign key (ItemCatID) references ItemCategory(ID)
)