--01. One-To-One Relationship
CREATE DATABASE SoftUniDemo
USE SoftUniDemo

CREATE TABLE Passports
(
	PassportID INT IDENTITY(101,1) PRIMARY KEY,
	PassportNumber VARCHAR(8)
)

INSERT INTO Passports
VALUES
	('N34FG21B'),
	('K65LO4R7'),
	('ZE657QP2')

CREATE TABLE Persons
(
	PersonID INT IDENTITY PRIMARY KEY,
	FirstName VARCHAR(100),
	Salary DECIMAL(10,2),
	PassportID INT FOREIGN KEY REFERENCES Passports(PassportID) NOT NULL  UNIQUE
)

INSERT INTO Persons
VALUES
	('Roberto', 43300.00, 102),
	('Tom', 56100.00, 103),
	('Yana', 60200.00, 101)

--02. One-To-Many Relationship
USE SoftUniDemo

CREATE TABLE Manufacturers
(
	ManufacturerID INT IDENTITY PRIMARY KEY,
	[Name] VARCHAR(100),
	EstablishedOn DATE
)

INSERT INTO Manufacturers
VALUES
	('BMW', '1916-03-07'),
	('Tesla', '2003-01-01'),
	('Lada', '1966-05-01')

CREATE TABLE Models
(
	ModelID INT IDENTITY(101,1) PRIMARY KEY,
	[Name] VARCHAR(100),
	ManufacturerID INT FOREIGN KEY REFERENCES Manufacturers(ManufacturerID)
)

INSERT INTO Models
VALUES
	('X1', 1),
	('i6', 1),
	('Model S', 2),
	('Model X', 2),
	('Model 3', 2),
	('Nova', 3)

--03. Many-To-Many Relationship
USE SoftUniDemo

CREATE TABLE Students
(
	StudentID INT IDENTITY PRIMARY KEY,
	[Name] VARCHAR(100)
)

INSERT INTO Students
VALUES
	('Mila'),
	('Toni'),
	('Ron')

CREATE TABLE Exams
(
	ExamID INT IDENTITY(101,1) PRIMARY KEY,
	[Name] VARCHAR(100)
)

INSERT INTO Exams
VALUES
	('SpringMVC'),
	('Neo4j'),
	('Oracle 11g')

CREATE TABLE StudentsExams
(
	StudentID INT FOREIGN KEY REFERENCES Students(StudentID),
	ExamID INT FOREIGN KEY REFERENCES Exams(ExamID),
	CONSTRAINT PK_Student_Exam PRIMARY KEY (StudentID, ExamID)
)

INSERT INTO StudentsExams
VALUES
	(1, 101),
	(1, 102),
	(2, 101),
	(3, 103),
	(2, 102),
	(2, 103)

--04. Self-Referencing
USE SoftUniDemo

CREATE TABLE Teachers
(
	TeacherID INT IDENTITY(101,1) PRIMARY KEY,
	[Name] VARCHAR(100) NOT NULL,
	ManagerID INT FOREIGN KEY REFERENCES Teachers(TeacherID)
)

INSERT INTO Teachers
VALUES
	('John', NULL),
	('Maya', 106),
	('Silvia', 106),
	('Ted', 105),
	('Mark', 101),
	('Greta', 101)

--05. Online Store Database
CREATE DATABASE OnlineStore
USE OnlineStore

CREATE TABLE Cities
(
	CityID INT IDENTITY PRIMARY KEY,
	[Name] VARCHAR(100) NOT NULL
)
CREATE TABLE Customers
(
	CustomerID INT IDENTITY PRIMARY KEY,
	[Name] VARCHAR(100) NOT NULL,
	Birthday DATE,
	CityID INT FOREIGN KEY REFERENCES Cities(CityID)
)
CREATE TABLE Orders
(
	OrderID INT IDENTITY PRIMARY KEY,
	CustomerID INT FOREIGN KEY REFERENCES Customers (CustomerID)
)
CREATE TABLE ItemTypes
(
	ItemTypeID INT IDENTITY PRIMARY KEY,
	[Name] VARCHAR(100) NOT NULL
)
CREATE TABLE Items
(
	ItemID INT IDENTITY PRIMARY KEY,
	[Name] VARCHAR(100) NOT NULL,
	ItemTypeID INT FOREIGN KEY REFERENCES ItemTypes (ItemTypeID)
)
CREATE TABLE OrderItems
(
	OrderID INT FOREIGN KEY REFERENCES Orders (OrderID),
	ItemID INT FOREIGN KEY REFERENCES Items (ItemID)
	PRIMARY KEY (OrderID, ItemID)
)

--06. University Database
CREATE DATABASE University
USE University

CREATE TABLE Majors
(
	MajorID INT IDENTITY PRIMARY KEY,
	[Name] VARCHAR(100) NOT NULL
)
CREATE TABLE Subjects
(
	SubjectID INT IDENTITY PRIMARY KEY,
	SubjectName VARCHAR(100) NOT NULL
)
CREATE TABLE Students
(
	StudentID INT IDENTITY PRIMARY KEY,
	StudentsNumber CHAR(20) NOT NULL,
	SubjectName VARCHAR(100) NOT NULL,
	MajorID INT FOREIGN KEY REFERENCES Majors (MajorID)
)
CREATE TABLE Agenda
(
	StudentID INT FOREIGN KEY REFERENCES Students(StudentID),
	SubjectID INT FOREIGN KEY REFERENCES Subjects (SubjectID)
	PRIMARY KEY (StudentID, SubjectID)
)
CREATE TABLE Payments
(
	PaymentID INT IDENTITY PRIMARY KEY,
	PaymentDate DATE NOT NULL,
	PaymentAmount DECIMAL(10,2) NOT NULL,
	StudentID INT FOREIGN KEY REFERENCES Students(StudentID)
)

--07.SoftUni Design: 
--Create an E/R Diagram of the SoftUni Database.

-- 08. Geography Design
-- Create an E/R Diagram of the Geography Database.

--09. *Peaks in Rila
USE [Geography]

SELECT
	m.MountainRange,
	p.PeakName,
	p.Elevation
FROM Peaks AS p
INNER JOIN Mountains AS m ON (p.MountainId = m.Id)
WHERE m.MountainRange = 'Rila'
ORDER BY p.Elevation DESC

