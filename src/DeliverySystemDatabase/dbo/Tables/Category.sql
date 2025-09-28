
create table Category (
	ID int identity(1,1) not null, 
	CatName nvarchar(50) not null,
	IsActive bit	     not null constraint IsActive_DF default 1,
	constraint CatID_PR_KEY primary key (ID)
)