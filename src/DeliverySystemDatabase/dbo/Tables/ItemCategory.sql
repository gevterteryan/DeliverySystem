create table ItemCategory(
		ID int identity(1,1) not null,
		Name nvarchar(50)    not null
		constraint ItemCatID_PR_KEY primary key (ID)
)