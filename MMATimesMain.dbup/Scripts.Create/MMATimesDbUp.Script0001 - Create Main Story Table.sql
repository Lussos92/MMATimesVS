CREATE TABLE dbo.Author
(
	AuthorId int NOT NULL,
	FirstName nvarchar,
	Surname nvarchar,
	Password nvarchar,
	PRIMARY KEY (AuthorId)
	
)

CREATE TABLE dbo.NewsStory
(
	NewsStoryId int,
	Title nvarchar,
	Blurb nvarchar,
	MainBody nvarchar,
	AuthorId INT
	PRIMARY KEY (NewsStoryId)
	FOREIGN KEY (AuthorId) REFERENCES Author(AuthorId)
)