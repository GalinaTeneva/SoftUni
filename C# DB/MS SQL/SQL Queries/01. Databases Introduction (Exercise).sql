-- 01. Create Database
CREATE DATABASE Minions

-- 02. Create Tables
USE Minions

CREATE TABLE Minions
(
	Id INT PRIMARY KEY,
	[Name] VARCHAR(50) NOT NULL,
	Age SMALLINT
)

CREATE TABLE Towns
(
	Id INT PRIMARY KEY,
	[Name] VARCHAR(100)
)

-- 03. Alter Minions Table
USE Minions

ALTER TABLE Minions
	ADD TownId INT FOREIGN KEY REFERENCES Towns([Id])

-- 04. Insert Records in Both Tables
USE Minions

INSERT INTO Towns (Id, [Name])
VALUES
	(1, 'Sofia'),
	(2, 'Plovdiv'),
	(3, 'Varna')

INSERT INTO Minions(Id, [Name], Age, TownId)
VALUES
	(1, 'Kevin', 22, 1),
	(2, 'Bob', 15, 3),
	(3, 'Steward', Null, 2)

-- 05. Truncate Table Minions
USE Minions

TRUNCATE TABLE [Minions]

-- 06. Drop All Tables
USE Minions

DROP TABLE Minions
DROP TABLE Towns

-- 07. Create Table People
CREATE DATABASE People
USE People

CREATE TABLE People
(
	Id INT IDENTITY PRIMARY KEY,
	[Name] NVARCHAR(100) NOT NULL,
	Picture VARBINARY(MAX),
	Height NUMERIC(3,2),
	[Weight] NUMERIC(5,2),
	Gender CHAR(1) NOT NULL
	CONSTRAINT genderCheck CHECK(Gender In ('m', 'f')),
	Birthdate DATE NOT NULL,
	Biography NVARCHAR(MAX),
)

INSERT INTO People ([Name], Height, [Weight], Gender, Birthdate)
VALUES
	('Mariya', 1.65, 56.2, 'f', '1990-04-16'),
	('Ivan', NULL, 96.4, 'm', '1984-12-15'),
	('Misho', 1.74, 94.1, 'm', '1978-03-08'),
	('Valentina', 1.53, 60.7, 'f', '1998-10-26'),
	('Gosho', 1.72, NULL, 'm', '1999-07-30')

-- 08. Create Table Users
CREATE DATABASE Users
USE Users

CREATE TABLE Users
(
	Id BIGINT IDENTITY PRIMARY KEY,
	Username VARCHAR(30) NOT NULL,
	[Password] VARCHAR(26) NOT NULL,
	ProfilePicture VARBINARY(MAX) CHECK (LEN(ProfilePicture) >= 90000),
	LastLoginTime DATETIME2 NOT NULL,
	IsDeleted BIT NOT NULL,
)

INSERT INTO Users(Username, [Password], LastLoginTime, IsDeleted)
VALUES
	('Milen', 'csacfgrrr64', '2022-01-02 22:33:42', 0),
	('Mario', 'dsnfei;45', '2000-04-08 20:06:20', 1),
	('Mihaela', 'fgrtgre65', '2019-12-30 16:07:05', 0),
	('Vasko', ';.dokfiej69', '2023-02-14 13:06:30', 0),
	('Lili', ',lscdrorjw47', '1998-06-20 04:47:05', 1)

-- 09. Change Primary Key
USE Users

ALTER TABLE Users  
	DROP CONSTRAINT PK__Users__3214EC07F460C7D8

ALTER TABLE Users
	ADD CONSTRAINT PK_User PRIMARY KEY (Id, [Username])

-- 10. Add Check Constraint
USE Users

ALTER TABLE Users
	ADD CONSTRAINT CHK_UserPass CHECK(LEN([Password]) >= 5)

--11. Set Default Value of a Field
USE Users

ALTER TABLE Users
	ADD CONSTRAINT df_Date DEFAULT GETDATE() FOR LastLoginTime

--12. Set Unique Field
USE Users

ALTER TABLE Users
	DROP CONSTRAINT PK_User

ALTER TABLE Users
	ADD PRIMARY KEY (Id)

ALTER TABLE Users
	ADD CONSTRAINT UC_Username UNIQUE(Username)

ALTER TABLE Users
	ADD CONSTRAINT CHK_UsernameMinLength CHECK(LEN(Username) >= 3)

--13. Movies Database
CREATE DATABASE Movies
USE	 Movies

CREATE TABLE Directors
(
	Id INT IDENTITY PRIMARY KEY,
	DirectorName NVARCHAR(100) NOT NULL,
	Notes NVARCHAR(MAX)
)

INSERT INTO Directors(DirectorName)
	VALUES
	 ('Petar Petrov'),
	 ('Stanimir Marinov'),
	 ('Vasil Milenov'),
	 ('Todor Enchev'),
	 ('Vaska Koleva')

CREATE TABLE Genres
(
	Id INT IDENTITY PRIMARY KEY,
	GenreName NVARCHAR(50) NOT NULL,
	Notes NVARCHAR(MAX)
)

INSERT INTO Genres (GenreName)
	VALUES
	('Comedy'),
	('Action'),
	('Drama'),
	('Documentary'),
	('Drama')

CREATE TABLE Categories
(
	Id INT IDENTITY PRIMARY KEY,
	CategoryName NVARCHAR(50) NOT NULL,
	Notes NVARCHAR(MAX)
)

INSERT INTO Categories (CategoryName)
	VALUES
	('Category1'),
	('Category2'),
	('Category3'),
	('Category4'),
	('Category5')

CREATE TABLE Movies
(
	Id INT IDENTITY PRIMARY KEY,
	Title NVARCHAR(100) NOT NULL,
	DirectorId INT FOREIGN KEY REFERENCES Directors(Id),
	CopyrightYear DATE,
	[Length] TINYINT,
	GenreId INT FOREIGN KEY REFERENCES Genres(Id),
	CategoryId INT FOREIGN KEY REFERENCES Categories(Id),
	Rating DECIMAL(3,2),
	Notes NVARCHAR(MAX)
)

INSERT INTO Movies(Title, DirectorId, CopyrightYear, GenreId, Rating)
	VALUES
	('Title1', 2, '2000', 1, 5.70),
	('Title2', 1, '1986', 4, 4.86),
	('Title3', 5, '2016', 5, 6.82),
	('Title4', 3, '1994', 2, 5.35),
	('Title5', Null, '1994', 3, Null)

--14. Car Rental Database
CREATE DATABASE CarRental
USE CarRental

CREATE TABLE Categories
(
	Id INT IDENTITY PRIMARY KEY,
	CategoryName VARCHAR(50) NOT NULL,
	DailyRate DECIMAL(5,2) NOT NULL,
	WeeklyRate DECIMAL(5,2) NOT NULL,
	MonthlyRate DECIMAL(5,2) NOT NULL,
	WeekendRate DECIMAL(5,2) NOT NULL
)

INSERT INTO Categories (CategoryName, DailyRate, WeeklyRate, MonthlyRate, WeekendRate)
	VALUES
	 ('Hatchback', 40.00, 80.00, 120.00, 60.00),
	 ('SUV', 50, 90, 130, 70),
	 ('Truck', 60, 100, 140, 80)

CREATE TABLE Cars
(
	Id INT IDENTITY PRIMARY KEY,
	PlateNumber CHAR(8) NOT NULL,
	Manufacturer VARCHAR(50) NOT NULL,
	Model VARCHAR(30) NOT NULL,
	CarYear DATE NOT NULL,
	CategoryId INT FOREIGN KEY REFERENCES Categories(Id),
	Doors TINYINT,
	Picture VARBINARY(MAX) CHECK(lEN(Picture) >= 90000),
	Condition VARCHAR(MAX),
	Available BIT NOT NULL
)

INSERT INTO Cars (PlateNumber, Manufacturer, Model, CarYear, CategoryId, Doors, Available)
	VALUES
	('TX2503BX', 'Chevrolet', 'Silverado', '2019', 3, 2, 0),
	('CA7845XC', 'Toyota', 'RAV4', '2021', 2, 4, 1),
	('ÑÀ1111ÐÍ', 'Honda', 'Civic', '2018', 1, 4, 0)

CREATE TABLE Employees
(
	Id INT IDENTITY PRIMARY KEY,
	FirstName VARCHAR(50) NOT NULL,
	LastName VARCHAR(50) NOT NULL,
	Title VARCHAR(50),
	Notes VARCHAR(MAX)
)

INSERT INTO Employees (FirstName, LastName, Title)
	VALUES
	('Ivan', 'Vasilev', 'Salesmamn'),
	('Marian', 'Dimitrov', NULL),
	('Stamat', 'Kostov', 'Salesmamn')

CREATE TABLE Customers
(
	Id INT IDENTITY PRIMARY KEY,
	DriverLicenceNumber VARCHAR(50) NOT NULL,
	FullName VARCHAR(100) NOT NULL,
	[Address] VARCHAR(250),
	City VARCHAR(100),
	ZIPCode VARCHAR(100),
	Notes VARCHAR(MAX)
)

INSERT INTO Customers (DriverLicenceNumber, FullName, City)
	VALUES
	('dkcmgudjs;', 'Mario Stoyanov', 'Burgas'),
	('vnuflpdns', 'Kamelia Tomova', 'Ruse'),
	('vsfpiusmfk', 'Hristina Kamenova', 'Varna')

CREATE TABLE RentalOrders
(
	Id INT IDENTITY PRIMARY KEY,
	EmployeeId INT FOREIGN KEY REFERENCES Employees (Id),
	CustomerId INT FOREIGN KEY REFERENCES Customers (Id),
	CarId INT FOREIGN KEY REFERENCES Cars (Id),
	TankLevel TINYINT,
	KilometrageStart TINYINT NOT NULL,
	KilometrageEnd TINYINT NOT NULL,
	TotalKilometrage TINYINT,
	StartDate DATETIME2,
	EndDate DATETIME2,
	TotalDays TINYINT,
	RateApplied DECIMAL(5,2) NOT NULL,
	TaxRate DECIMAL(4,2),
	OrderStatus VARCHAR(50),
	Notes VARCHAR(MAX)
)

INSERT INTO RentalOrders (EmployeeId, CustomerId, CarId, KilometrageStart, KilometrageEnd, TotalDays, RateApplied)
	VALUES
	(1, 2, 2,  30, 60, 3, 60),
	(1, 3, 1,  30, 60, 2, 60),
	(1, 1, 1,  30, 60, 3, 60)

--15. Hotel Database
CREATE DATABASE Hotel
USE Hotel

CREATE TABLE Employees
(
	Id INT IDENTITY PRIMARY KEY,
	FirstName NVARCHAR(50) NOT NULL,
	LastName NVARCHAR(50) NOT NULL,
	Title NVARCHAR(50),
	Notes NVARCHAR(MAX),
)

INSERT INTO Employees (FirstName, LastName)
	VALUES
	('Martin', 'Stamenov'),
	('Katya', 'Ruseva'),
	('Manov', 'Hristov')

CREATE TABLE Customers
(
	AccountNumber INT IDENTITY PRIMARY KEY,
	FirstName NVARCHAR(50) NOT NULL,
	LastName NVARCHAR(50) NOT NULL,
	PhoneNumber NVARCHAR(50),
	EmergencyName NVARCHAR(50),
	EmergencyNumber NVARCHAR(50),
	Notes NVARCHAR(MAX)
)

INSERT INTO Customers (FirstName, LastName)
	VALUES
	('Kalina', 'Stamenova'),
	('Kiril', 'Rusev'),
	('Mariya', 'Hristova')

CREATE TABLE RoomStatus
(
	RoomStatus NVARCHAR(50) PRIMARY KEY NOT NULL,
	Notes NVARCHAR(MAX)
)

INSERT INTO RoomStatus (RoomStatus)
	VALUES
	('FREE'),
	('OCCUPIED'),
	('PENDING PAYMENT')

CREATE TABLE RoomTypes
(
	RoomType NVARCHAR(50) PRIMARY KEY NOT NULL,
	Notes NVARCHAR(MAX)
)

INSERT INTO RoomTypes (RoomType)
	VALUES
	('Apartment'),
	('Double suit'),
	('Single bed')

CREATE TABLE BedTypes
(
	BedType NVARCHAR(50) PRIMARY KEY NOT NULL,
	Notes NVARCHAR(MAX)
)

INSERT INTO BedTypes (BedType)
	VALUES
	('Double'),
	('King size'),
	('Single')

CREATE TABLE Rooms
(
	RoomNumber TINYINT IDENTITY PRIMARY KEY NOT NULL,
	RoomType NVARCHAR(50) NOT NULL,
	BedType NVARCHAR(50) NOT NULL,
	Rate DECIMAL(2,1),
	RoomStatus NVARCHAR(50) NOT NULL,
	Notes NVARCHAR(MAX)
)

INSERT INTO Rooms (RoomType, BedType, RoomStatus)
	VALUES
	('Single bed','Double', 'FREE'),
	('Double suit', 'King size', 'OCCUPIED'),
	('Apartment', 'Single', 'FREE')

CREATE TABLE Payments
(
	Id INT IDENTITY PRIMARY KEY,
	EmployeeId INT NOT NULL,
	PaymentDate DATE NOT NULL,
	AccountNumber INT NOT NULL,
	FirstDateOccupied DATE,
	LastDateOccupied DATE,
	TotalDays INT NOT NULL,
	AmountCharged DECIMAL(5,2),
	TaxRate DECIMAL(3,2),
	TaxAmount DECIMAL (10,2),
	PaymentTotal DECIMAL (10,2),
	Notes VARCHAR(MAX)
)

INSERT INTO Payments (EmployeeId, PaymentDate, AccountNumber, TotalDays, PaymentTotal)
	VALUES
	(2, '2023-01-30', 3, 4, 250.80),
	(2, '2023-04-15', 1, 7, 890.30),
	(1, '2023-07-01', 3, 15, 1300.90)

CREATE TABLE Occupancies
(
	Id INT IDENTITY PRIMARY KEY, 
	EmployeeId INT NOT NULL, 
	DateOccupied DATE NOT NULL, 
	AccountNumber INT NOT NULL, 
	RoomNumber TINYINT NOT NULL, 
	RateApplied DECIMAL(3,2), 
	PhoneCharge BIT, 
	Notes VARCHAR(MAX)
)

INSERT INTO Occupancies (EmployeeId, DateOccupied, AccountNumber, RoomNumber)
	VALUES
	(3, '2022-01-15', 3, 4),
	(1, '2022-04-08', 1, 7),
	(1, '2022-07-20', 3, 1)

--16. Create SoftUni Database
CREATE DATABASE SoftUni
USE SoftUni

CREATE TABLE Towns
(
	Id INT IDENTITY PRIMARY KEY,
	[Name] NVARCHAR(100) NOT NULL,
)
CREATE TABLE Addresses
(
	Id INT IDENTITY PRIMARY KEY,
	AddressText NVARCHAR(200) NOT NULL,
	TownId INT FOREIGN KEY REFERENCES Towns (ID)
)
CREATE TABLE Departments
(
	Id INT IDENTITY PRIMARY KEY,
	[Name] NVARCHAR(100) NOT NULL
)
CREATE TABLE Employees
(
	Id INT IDENTITY PRIMARY KEY,
	FirstName NVARCHAR(100) NOT NULL,
	MiddleName NVARCHAR(100) NOT NULL,
	LastName NVARCHAR(100) NOT NULL,
	JobTitle NVARCHAR(100) NOT NULL,
	DepartmentId INT FOREIGN KEY REFERENCES Departments (Id),
	HireDate DATE NOT NULL,
	Salary DECIMAL(12,2),
	AddressId INT FOREIGN KEY REFERENCES Addresses (Id)
)

--17. Backup Database
USE SoftUni

BACKUP DATABASE SoftUni
TO DISK = 'D:\UserData\Desktop\softuni-backup.bak'
WITH FORMAT,
		MEDIANAME = 'SoftUniBackup',
		NAME = 'Full back up of SoftUni'

--18. Basic Insert
USE SoftUni

INSERT INTO Towns ([Name])
VALUES
	('Sofia'),
	('Plovdiv'),
	('Varna'),
	('Burgas')

INSERT INTO Departments ([Name])
VALUES
	('Engineering'),
	('Sales'),
	('Marketing'),
	('Software Development'),
	('Quality Assurance')

INSERT INTO Employees (FirstName, MiddleName, LastName, JobTitle, DepartmentId, HireDate, Salary)
VALUES
	('Ivan', 'Ivanov', 'Ivanov', '.NET Developer', 4, '2013-02-01', 3500.00),
	('Petar', 'Petrov', 'Petrov', 'Senior Engineer', 1, '2004-03-02', 4000.00),
	('Maria', 'Petrova', 'Ivanova', 'Intern', 5, '2016-08-28', 525.25),
	('Georgi', 'Teziev', 'Ivanov', 'CEO', 2, '2007-12-09', 3000.00),
	('Peter', 'Pan', 'Pan', 'Intern', 3, '2016-08-28', 599.88)

--19. Basic Select All Fields
USE SoftUni

SELECT * FROM Towns
SELECT * FROM Departments
SELECT * FROM Employees

--20. Basic Select All Fields and Order Them
USE SoftUni

SELECT * FROM Towns 
ORDER BY [Name]

SELECT * FROM Departments
ORDER BY [Name]

SELECT * FROM Employees
ORDER BY Salary DESC

--21. Basic Select Some Fields
USE SoftUni

SELECT [Name] FROM Towns
ORDER BY [Name]

SELECT [Name] FROM Departments
ORDER BY [Name]

SELECT FirstName, LastName, JobTitle, Salary FROM Employees
ORDER BY Salary DESC

--22.Increase Employees Salary
USE SoftUni

UPDATE Employees
SET Salary = (Salary * 10 / 100 + Salary)
WHERE Salary > 0

SELECT Salary FROM Employees

--23. Decrease Tax Rate
USE Hotel

UPDATE Payments
SET TaxRate = TaxRate - TaxRate * 0.03
WHERE TaxRate > 0

SELECT TaxRate FROM Payments

--24. Delete All Records
USE Hotel

TRUNCATE TABLE Occupancies