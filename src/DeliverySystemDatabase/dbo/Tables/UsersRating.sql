CREATE TABLE UsersRating(
		UserID int not null,
		RestID int not null,
		Rate tinyint not null

	CONSTRAINT UsersRatingUserIDRestID_PR_KEY PRIMARY KEY (UserID, RestID),
	CONSTRAINT UsersRatingUserID_FR_KEY FOREIGN KEY (UserID) REFERENCES UserS(ID),
	CONSTRAINT UsersRatingRestID_FR_KEY FOREIGN KEY (RestID) REFERENCES Restaurant(ID)
)