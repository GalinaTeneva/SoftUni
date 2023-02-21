--Section 1. DDL (30 pts)
--01. Table design
CREATE DATABASE [Service]

USE [Service]

CREATE TABLE Users
(
	 Id INT PRIMARY KEY IDENTITY
	,Username VARCHAR(30) UNIQUE NOT NULL
	,[Password] VARCHAR(50) NOT NULL
	,[Name] VARCHAR(50)
	,Birthdate DATETIME
	,Age INT CHECK (Age BETWEEN 14 AND 110)
	,Email VARCHAR(50) NOT NULL
)

CREATE TABLE Departments
(
	 Id INT PRIMARY KEY IDENTITY
	,[Name] VARCHAR(50) NOT NULL
)

CREATE TABLE Employees
(
	 Id INT PRIMARY KEY IDENTITY
	,FirstName VARCHAR(25)
	,LastName VARCHAR(25)
	,Birthdate DATETIME
	,Age INT CHECK (Age BETWEEN 18 AND 110)
	,DepartmentId INT FOREIGN KEY REFERENCES Departments(Id)
)

CREATE TABLE Categories
(
	 Id INT PRIMARY KEY IDENTITY
	,[Name] VARCHAR(50) NOT NULL
	,DepartmentId INT FOREIGN KEY REFERENCES Departments(Id) NOT NULL
)

CREATE TABLE [Status]
(
	 Id INT PRIMARY KEY IDENTITY
	,[Label] VARCHAR(20) NOT NULL
)

CREATE TABLE Reports
(
	 Id INT PRIMARY KEY IDENTITY
	,CategoryId INT FOREIGN KEY REFERENCES Categories(Id) NOT NULL
	,StatusId INT FOREIGN KEY REFERENCES [Status](Id) NOT NULL
	,OpenDate DATETIME NOT NULL
	,CloseDate DATETIME
	,[Description] VARCHAR(200) NOT NULL
	,UserId INT FOREIGN KEY REFERENCES Users(Id) NOT NULL
	,EmployeeId INT FOREIGN KEY REFERENCES Employees(Id)
)

--Section 2. DML (10 pts)
--02. Insert
INSERT INTO Employees (FirstName, LastName, Birthdate, DepartmentId)
VALUES
	 ('Marlo', 'O''Malley', '1958-9-21', 1)
	,('Niki', 'Stanaghan', '1969-11-26', 4)
	,('Ayrton', 'Senna', '1960-03-21', 9)
	,('Ronnie', 'Peterson', '1944-02-14', 9)
	,('Giovanna', 'Amati', '1959-07-20', 5)

INSERT INTO Reports (CategoryId, StatusId, OpenDate, CloseDate, [Description], UserId, EmployeeId)
VALUES
	 (1, 1, '2017-04-13', NULL, 'Stuck Road on Str.133', 6, 2)
	,(6, 3, '2015-09-05', '2015-12-06', 'Charity trail running', 3, 5)
	,(14, 2, '2015-09-07', NULL, 'Falling bricks on Str.58', 5, 2)
	,(4, 3, '2017-07-03', '2017-07-06', 'Cut off streetlight on Str.11', 1, 1)

--03. Update
UPDATE Reports
SET CloseDate = CURRENT_TIMESTAMP
WHERE CloseDate IS NULL

--04. Delete
DELETE
FROM Reports
WHERE StatusId = 4

--Section 3. Querying (40 pts)
--05. Unassigned Reports
SELECT
	 [Description]
	,FORMAT(OpenDate, 'dd-MM-yyyy') AS OpenDate
FROM Reports AS r
WHERE EmployeeId IS NULL
ORDER BY
	 r.OpenDate
	,[Description]

--06. Reports & Categories
SELECT
	 r.[Description]
	,c.[Name] AS CategoryName
FROM Reports AS r
LEFT JOIN Categories AS c ON r.CategoryId = c.Id
ORDER BY
	 r.[Description]
	,c.[Name]

--07. Most Reported Category
SELECT TOP (5)
	 c.[Name]
	,COUNT(r.Id) AS ReportsNumber
FROM Categories AS c
LEFT JOIN Reports AS r ON c.Id = r.CategoryId
GROUP BY c.[Name]
ORDER BY COUNT(r.Id) DESC

--08. Birthday Report
SELECT
	 u.Username
	,c.[Name] AS CategoryName
FROM REPORTS AS r
LEFT JOIN Users AS u ON r.UserId = u.Id
LEFT JOIN Categories AS c ON r.CategoryId = c.Id
WHERE DATEPART(DAY, u.Birthdate) = DATEPART(DAY, r.OpenDate)
ORDER BY
	 u.Username
	,c.[Name]

--09. Users per Employee 
SELECT
	 CONCAT(e.FirstName, ' ', e.LastName) AS FullName
	,COUNT(u.Id) AS UsersCount
FROM Employees AS e
LEFT JOIN Reports AS r ON e.Id = r.EmployeeId
LEFT JOIN Users AS u ON r.UserId = u.Id
GROUP BY CONCAT(e.FirstName, ' ', e.LastName)
ORDER BY
	 COUNT(u.Id) DESC
	,CONCAT(e.FirstName, ' ', e.LastName)

--10. Full Info
SELECT
	CASE
		WHEN e.Id IS NULL THEN 'None'
		ELSE CONCAT(e.FirstName, ' ', e.LastName)
	END  AS Employee
	,CASE
		WHEN d.[Name] IS NULL THEN 'None'
		ELSE d.[Name]
	 END AS Department
	,c.[Name] AS Category
	,r.[Description]
	,FORMAT(r.OpenDate, 'dd.MM.yyyy') AS OpenDate
	,s.[Label] AS [Status]
	,u.[Name] AS [User]
FROM Reports AS r
LEFT JOIN Employees AS e ON r.EmployeeId = e.Id
LEFT JOIN Departments AS d ON e.DepartmentId = d.Id
LEFT JOIN Categories AS c ON r.CategoryId = c.Id
LEFT JOIN [Status] AS s ON r.StatusId = s.Id
LEFT JOIN Users AS u ON r.UserId = u.Id
ORDER BY
	 e.FirstName DESC
	,e.LastName DESC
	,d.[Name]
	,c.[Name]
	,r.[Description]
	,r.OpenDate
	,s.[Label]
	,u.[Name]

--Section 4. Programmability (20 pts)
--11. Hours to Complete
GO
CREATE FUNCTION udf_HoursToComplete(@StartDate DATETIME, @EndDate DATETIME)
RETURNS INT
AS
BEGIN
	DECLARE @totalHours INT;

	SET @totalHours =   CASE
						WHEN @StartDate IS NULL OR @EndDate IS NULL THEN 0
						ELSE DATEDIFF(HOUR, @StartDate, @EndDate)
						END
	RETURN @totalHours;
    --FROM Reports
END
GO

--12. Assign Employee
CREATE PROCEDURE usp_AssignEmployeeToReport(@EmployeeId INT, @ReportId INT)
AS
BEGIN
	 DECLARE @employeeDepId INT
			,@reportDepId INT
	 
	 SET @employeeDepId =  (
							SELECT d.Id
							FROM Employees AS e
							LEFT JOIN Departments AS d ON e.DepartmentId = d.Id
							WHERE e.Id = @EmployeeId
						   )
	 SET @reportDepId =  (
							SELECT d.Id
							FROM Reports AS r
							LEFT JOIN Categories AS c ON r.CategoryId = c.Id
							LEFT JOIN Departments AS d ON c.DepartmentId = d.Id
							WHERE r.Id = @ReportId
						   )
	 IF(@employeeDepId = @reportDepId)
	 BEGIN
		 UPDATE Reports
		 SET EmployeeId = @EmployeeId
		 WHERE Id = @ReportId
	 END
	 ELSE
		THROW 51000, 'Employee doesn''t belong to the appropriate department!', 1
END
