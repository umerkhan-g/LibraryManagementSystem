USE MASTER
GO

BEGIN TRY
	DROP DATABASE LibraryManagement
END TRY
BEGIN CATCH
	--Do Nothing	
END CATCH

CREATE DATABASE LibraryManagement
GO
USE LibraryManagement
GO

CREATE TABLE Administrator
(
	adminId varchar(20) PRIMARY KEY
	, name varchar(30) NOT NULL
	, userName varchar(15) NOT NULL UNIQUE
	, userPassword varchar(15) NOT NULL
);

CREATE TABLE Book
(
	bookId varchar(20) PRIMARY KEY
	, title varchar(100) NOT NULL
	, subjectCode varchar(20) NOT NULL
	, price money NOT NULL
	, rackNo varchar(10) NOT NULL 
	, issuedTo varchar(20) 
);

CREATE TABLE Member
(
	memberId varchar(20) PRIMARY KEY
	, name varchar(30) NOT NULL
	, memType varchar(10) NOT NULL
	, membershipIssueDate date NOT NULL
	, membershipExpiryDate date NOT NULL
);

CREATE TABLE Publisher
(
	publisherId int IDENTITY(1,1) PRIMARY KEY
	, bookId varchar(20) 
	, name varchar(30) NOT NULL

	CONSTRAINT p_BID FOREIGN KEY(bookId) REFERENCES Book(bookId)
	ON UPDATE CASCADE
);

CREATE TABLE StatusOfReturn
(
	returnId int IDENTITY(1,1) PRIMARY KEY
	, bookId varchar(20)
	, memberId varchar(20)
	, issueDate date NOT NULL
	, expiryDate date NOT NULL
	, fineAmount money 
	
	CONSTRAINT sor_BID FOREIGN KEY(bookId) REFERENCES Book(bookId)
	ON UPDATE CASCADE
	, CONSTRAINT sor_MID FOREIGN KEY(memberId) REFERENCES Member(memberId)
	ON UPDATE CASCADE
);

CREATE TABLE StatusOfIssue
(
	issueID int IDENTITY(1,1) PRIMARY KEY
	, bookID varchar(20) 
	, memberID varchar(20)
	, issueDate date NOT NULL
	, expiryDate date NOT NULL

	CONSTRAINT soi_BID FOREIGN KEY(bookId) REFERENCES Book(bookId)
	ON UPDATE CASCADE
	, CONSTRAINT soi_MID FOREIGN KEY(memberId) REFERENCES Member(memberId)
	ON UPDATE CASCADE
);


CREATE TABLE ContactNo
(
	contactID int IDENTITY(1,1) PRIMARY KEY
	, adminID varchar(20)
	, publisherID int
	, memberID varchar(20)
	, theContactNo varchar(15)

	CONSTRAINT cn_AID FOREIGN KEY(adminId) REFERENCES Administrator(adminId)
	ON UPDATE CASCADE
	, CONSTRAINT cn_PID FOREIGN KEY(publisherId) REFERENCES Publisher(publisherId)
	ON UPDATE CASCADE
	, CONSTRAINT cn_MID FOREIGN KEY(memberId) REFERENCES Member(memberId)	
	ON UPDATE CASCADE
);

CREATE TABLE Address
(
	addID int IDENTITY(1, 1) PRIMARY KEY
	, adminID varchar(20)
	, publisherID int
	, memberID varchar(20)
	, theAddress varchar(100)

	CONSTRAINT add_AID FOREIGN KEY(adminId) REFERENCES Administrator(adminId)
	ON UPDATE CASCADE
	, CONSTRAINT add_PID FOREIGN KEY(publisherId) REFERENCES Publisher(publisherId)
	ON UPDATE CASCADE
	, CONSTRAINT add_MID FOREIGN KEY(memberId) REFERENCES Member(memberId) 
	ON UPDATE CASCADE
);

CREATE TABLE Author
(
	authorID int IDENTITY(1, 1) PRIMARY KEY
	, bookID varchar(20)
	, authorName varchar(30)
	
	CONSTRAINT author_AID FOREIGN KEY(bookId) REFERENCES Book(bookId)
	ON UPDATE CASCADE
);