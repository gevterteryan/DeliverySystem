create table Users(
	ID int identity(1,1)	  not null,
	FirstName nvarchar(15)    not null,
	LastName nvarchar(25)     not null,
	Age datetime2			  not null,
	OrdersCount	int				  null constraint OrderCount_DF default  0, 
	PhoneNumber nvarchar(15)  not null,
	UserEmail nvarchar(25)	  not null,
	UserPassword nvarchar(25) not null,
	UserBonus	money			  null,
	IsBlocked	bit				  null,
    constraint UsersID_PR_KEY primary key (ID)
)