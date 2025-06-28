

PRINT '==== DATABASE SETUP STARTED ====';
GO

USE [master];
GO

-- Check if database exists
IF EXISTS (SELECT name FROM sys.databases WHERE name = 'librarysystem')
BEGIN
    PRINT 'Database librarysystem already exists';
    PRINT 'Dropping existing database...';
    
    -- Set single_user mode before dropping
    ALTER DATABASE [librarysystem] SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
    DROP DATABASE [librarysystem];
    
    PRINT 'Database librarysystem dropped successfully';
END
GO

-- Create new database
PRINT 'Creating new database librarysystem...';
CREATE DATABASE [librarysystem];
PRINT 'Database librarysystem created successfully';
GO

-- Use the new database
USE [librarysystem];
GO

PRINT '==== CREATING TABLES ====';

USE librarysystem;
GO

CREATE TABLE TabAuthor
(
	AID int IDENTITY(1,1) NOT NULL,
	AuthorName varchar(100) NOT NULL,
	CONSTRAINT pk_TabAuthor PRIMARY KEY (AID)
);
go
CREATE TABLE TabCategory
(
	CID int IDENTITY(1,1) NOT NULL,
	CategoryName varchar(50) NOT NULL,
	CONSTRAINT PK_TabCategory PRIMARY KEY (CID)
);
go
CREATE TABLE TabLanguage
(
	LID int IDENTITY(1,1) NOT NULL,
	LanguageName varchar(50) NOT NULL,
	CONSTRAINT PK_TabLanguage PRIMARY KEY (LID)
);
go
CREATE TABLE TabUser
(
	UID int IDENTITY(1,1) NOT NULL,
	UserName varchar(8) NOT NULL,
	Password varchar(30) NOT NULL,
	PhoneNumber varchar(30),
	Email varchar(30),
	UserLevel int NOT NULL,
	CONSTRAINT PK_TabUser PRIMARY KEY (UID)
);
go
CREATE TABLE TabBook
(
	ISBN varchar(13) NOT NULL,
	BookName varchar(100) NOT NULL,
	Author int NOT NULL,
	Category int NOT NULL,
	Language int NOT NULL,
	PublishYear int NOT NULL,
	Pages int NOT NULL,
	Publisher varchar(100) NOT NULL,
	CONSTRAINT pk_TabBook PRIMARY KEY (ISBN),
	CONSTRAINT fk_TabBook_TabAuthor FOREIGN KEY (Author) REFERENCES TabAuthor(AID),
	CONSTRAINT fk_TabBook_TabCategory FOREIGN KEY (Category) REFERENCES TabCategory(CID),
	CONSTRAINT fk_TabBook_TabLanguage FOREIGN KEY (Language) REFERENCES TabLanguage(LID)
);
go

CREATE TABLE TabBorrow
(
	BID int IDENTITY(1,1) NOT NULL,
	UID int NOT NULL,
	ISBN varchar(13) NOT NULL,
 	BorrowDate date NOT NULL,
 	ReturnDate date NOT NULL,
 	ActualReturnDate date NOT NULL DEFAULT '2000-01-01',
 	LateFee	decimal(5,2) NOT NULL DEFAULT 0.00,
	CONSTRAINT pk_TabBorrow PRIMARY KEY (BID),
	CONSTRAINT fk_TabBorrow_TabBook FOREIGN KEY (ISBN) REFERENCES TabBook(ISBN),
	CONSTRAINT fk_TabBorrow_TabUser FOREIGN KEY (UID) REFERENCES TabUser(UID)
);
go
CREATE TABLE TabReserved
(
	RID int IDENTITY(1,1) NOT NULL,
 	UID int NOT NULL,
 	ISBN varchar(13) NOT NULL,
 	ReservedDate date NOT NULL,
	CONSTRAINT pk_TabReserved PRIMARY KEY (RID),
	CONSTRAINT fk_TabReserved_TabBook FOREIGN KEY (ISBN) REFERENCES TabBook(ISBN),
	CONSTRAINT fk_TabReserved_TabUser FOREIGN KEY (UID) REFERENCES TabUser(UID)
);

go

INSERT INTO TabCategory Values('Programming');
INSERT INTO TabCategory Values('Mathematics');
INSERT INTO TabCategory Values('History');
INSERT INTO TabCategory Values('Reference');
INSERT INTO TabLanguage Values('English');
INSERT INTO TabLanguage Values('Japanese');
INSERT INTO TabLanguage Values('Korean');
INSERT INTO TabLanguage Values('Italian');
INSERT INTO TabLanguage Values('Thai');
INSERT INTO TabAuthor Values('M. Kriss');
INSERT INTO TabAuthor Values('Lisa');
INSERT INTO TabAuthor Values('Dan Villegas');
INSERT INTO TabBook Values('1000001000001','.NetFramework', 3, 1, 1, 2015, 250, 'Harvard Publishing');
INSERT INTO TabBook Values('1234567890123','Programming in C#', 1, 1, 1, 2015, 12, 'Kriss Publishing');
INSERT INTO TabBook Values('2000002000002','Integral Calculus', 2, 2, 1, 2015, 150, 'Harvard Publishing');
INSERT INTO TabBook Values('3000003000003','The Babylons', 3, 3, 1, 2014, 25, 'Oshea Publishing');
INSERT INTO TabBook Values('4000004000004','Methodological Historian', 2, 3, 1, 2014, 200, 'McKinley Publishing');
INSERT INTO TabUser Values('user', 'user','','', 1);
INSERT INTO TabUser Values('sup', 'sup','','', 2);
INSERT INTO TabUser Values('admin', 'admin','','', 3);
INSERT INTO TabBorrow(UID, ISBN, BorrowDate, ReturnDate) Values(1, '1000001000001', '2016/07/10', '2016/07/24');
INSERT INTO TabReserved(UID, ISBN, ReservedDate) Values(2, '1000001000001', '2016/07/16');
go

CREATE VIEW ViewBook AS 
SELECT	TabBook.ISBN, TabBook.BookName, TabBook.Publisher, TabBook.PublishYear, TabBook.Pages, TabAuthor.AuthorName, 
	TabCategory.CategoryName, TabLanguage.LanguageName, TabBook.Author, TabBook.Category, TabBook.Language
FROM	TabAuthor INNER JOIN
	TabBook ON TabAuthor.AID = TabBook.Author INNER JOIN
	TabCategory ON TabBook.Category = TabCategory.CID INNER JOIN
	TabLanguage ON TabBook.Language = TabLanguage.LID;
go
CREATE VIEW ViewBookAvailable AS 
SELECT TabBook.ISBN, TabBook.BookName, TabCategory.CategoryName, TabBook.Publisher, TabBook.PublishYear, TabBook.Pages, 
	TabAuthor.AuthorName, TabLanguage.LanguageName, TabBook.Author, TabBook.Category, TabBook.Language
FROM	TabAuthor INNER JOIN
	TabBook ON TabAuthor.AID = TabBook.Author INNER JOIN
	TabCategory ON TabBook.Category = TabCategory.CID INNER JOIN
	TabLanguage ON TabBook.Language = TabLanguage.LID LEFT OUTER JOIN
	TabBorrow ON TabBook.ISBN = TabBorrow.ISBN
GROUP BY TabBook.ISBN, TabBook.BookName, TabCategory.CategoryName, TabBook.Publisher, TabBook.PublishYear, TabBook.Pages, 
	TabAuthor.AuthorName, TabBook.ISBN, TabLanguage.LanguageName, TabBook.Author, TabBook.Category, TabBook.Language
HAVING	(MIN(TabBorrow.ActualReturnDate) > CONVERT(DATETIME, '2001-01-01 00:00:00', 102)) OR
	(MIN(TabBorrow.ActualReturnDate) IS NULL);
go
CREATE VIEW ViewBookBorrowed AS 
SELECT	TabBook.ISBN, TabBook.BookName, TabCategory.CategoryName, TabBook.Publisher, TabBook.PublishYear, TabBook.Pages, 
	TabAuthor.AuthorName, TabLanguage.LanguageName, TabBook.Author, TabBook.Category, TabBook.Language
FROM	TabAuthor INNER JOIN
	TabBook ON TabAuthor.AID = TabBook.Author INNER JOIN
	TabCategory ON TabBook.Category = TabCategory.CID INNER JOIN
	TabLanguage ON TabBook.Language = TabLanguage.LID LEFT OUTER JOIN
	TabBorrow ON TabBook.ISBN = TabBorrow.ISBN
GROUP BY TabBook.ISBN, TabBook.BookName, TabCategory.CategoryName, TabBook.Publisher, TabBook.PublishYear, TabBook.Pages, 
	TabAuthor.AuthorName, TabBook.ISBN, TabLanguage.LanguageName, TabBook.Author, TabBook.Category, TabBook.Language
HAVING	(MIN(dbo.TabBorrow.ActualReturnDate) <= CONVERT(DATETIME, '2001-01-01 00:00:00', 102));

go