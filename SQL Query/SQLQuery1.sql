CREATE TABLE Users
(
ID int PRIMARY KEY IDENTITY,
Name nvarchar(50),
Surname nvarchar(50),
Phone nvarchar(50) UNIQUE,
Adress nvarchar(50),
Email nvarchar(50) UNIQUE,
)

CREATE TABLE Books
(
ID int PRIMARY KEY IDENTITY,
Name nvarchar(50),
ISBN nvarchar(50) UNIQUE,
PageCount int,
)

CREATE TABLE Borrowings
(
ID int PRIMARY KEY IDENTITY,
UserID int,
FOREIGN KEY (UserID) REFERENCES Users(ID),
BookID int,
FOREIGN KEY (BookID) REFERENCES Books(ID),
BorrowingsDate nvarchar(50),
ReturnDate nvarchar(50),
)

