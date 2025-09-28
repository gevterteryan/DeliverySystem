create table Drivers(
		ID				   int identity(1,1) not null,
		DriverType		   int				 not null,
		FirstName		   nvarchar(15)		 not null,
		LastName		   nvarchar(25)	     not null,
		Age				   datetime2	     not null,
		IsNowDriving	   bit				 not null,
		IsActive		   bit				 not null
		constraint DriversID_PR_KEY primary key (ID), 
)