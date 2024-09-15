CREATE DATABASE MillionRealStateCompanyBd
GO

USE MillionRealStateCompanyBd
GO

CREATE TABLE [Owners](

	Id UNIQUEIDENTIFIER DEFAULT NEWID() PRIMARY KEY,
	[Name] VARCHAR(150) NOT NULL,
	[Address] VARCHAR(150) NOT NULL,
	Phone VARCHAR(15) NOT NULL,
	Birthday DATETIME NOT NULL
)

GO

CREATE TABLE [Properties](
	Id UNIQUEIDENTIFIER DEFAULT NEWID() PRIMARY KEY,
	[Name] VARCHAR(150) NOT NULL,
	[Address] VARCHAR(150) NOT NULL,
	Price DECIMAL NOT NULL,
	CodeInternal VARCHAR(100) NOT NULL,
	[Year] INT NOT NULL,
	[Enable] BIT,
	OwnerId UNIQUEIDENTIFIER NOT NULL,
	FOREIGN KEY (OwnerId) REFERENCES [Owners](ID)
)

GO

CREATE TABLE PropertyTraces(
	Id UNIQUEIDENTIFIER DEFAULT NEWID() PRIMARY KEY,
	[Name] VARCHAR(150) NOT NULL,
	DateSale DATETIME NULL,
	[Value] DECIMAL NOT NULL,
	Tax DECIMAL NOT NULL,
	PropertyId UNIQUEIDENTIFIER,
	FOREIGN KEY (PropertyId) REFERENCES [Properties](Id)
)
GO

CREATE TABLE PropertyImages(
	Id UNIQUEIDENTIFIER DEFAULT NEWID() PRIMARY KEY,
	[File] VARCHAR(MAX),
	[Enable] BIT,
	PropertyId UNIQUEIDENTIFIER,
	FOREIGN KEY (PropertyId) REFERENCES [Properties](Id)
)

GO

CREATE TABLE [Users](
	Id UNIQUEIDENTIFIER DEFAULT NEWID() PRIMARY KEY,
	UserName VARCHAR(30) NOT NULL,
	[Password] VARCHAR(250) NOT NULL,
	Rol VARCHAR(30) NOT NULL,
)
GO


INSERT INTO [dbo].[Users]
           ([Id]
           ,[UserName]
           ,[Password]
           ,[Rol])
     VALUES
           (
           ,'admin'
           ,'26ad2ca0ede9ee0da7efd9f6572026dc5ad2de2d5d1395d08dc2267719fcbf3e'
           ,'admin')
GO


