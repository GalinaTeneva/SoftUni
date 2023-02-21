--Part I – Queries for SoftUni Database
--01. Find Names of All Employees by First Name
SELECT
	FirstName
	,LastName
FROM
	Employees
WHERE FirstName LIKE 'Sa%'

--02. Find Names of All Employees by Last Name
SELECT
	FirstName
	,LastName
FROM Employees
WHERE LastName LIKE '%ei%'

--03. Find First Names of All Employees
SELECT FirstName
FROM Employees
WHERE DepartmentID IN (3, 10)
	  AND YEAR(HireDate) >= 1995
	  AND YEAR(HireDate) <= 2005

--04. Find All Employees Except Engineers
SELECT FirstName
	   , LastName
FROM Employees
WHERE JobTitle NOT LIKE '%engineer%'

--05. Find Towns with Name Length
SELECT [Name]
FROM Towns
WHERE LEN([Name]) IN (5, 6)
ORDER BY [Name]

--06. Find Towns Starting With
SELECT
	 TownID
	,[Name]
FROM Towns
WHERE LEFT([Name], 1) IN ('M', 'K', 'B', 'E')
ORDER BY [Name]

--07. Find Towns Not Starting With
SELECT
	TownID
	,[Name]
FROM Towns
WHERE LEFT([Name], 1) NOT IN ('R', 'B', 'D')
ORDER BY [Name]

--08. Create View Employees Hired After 2000 Year
GO
CREATE VIEW V_EmployeesHiredAfter2000 AS
SELECT
	 FirstName
	,LastName
FROM Employees
WHERE YEAR(HireDate) > 2000
GO

--09. Length of Last Name
SELECT
	 FirstName
	,LastName
FROM Employees
WHERE LEN(LastName) = 5

--10. Rank Employees by Salary
SELECT
	 EmployeeID
	,FirstName
	,LastName
	,Salary
	,DENSE_RANK() OVER (PARTITION BY Salary ORDER BY EmployeeID) AS Rank
FROM Employees
WHERE Salary BETWEEN 10000 AND 50000
ORDER BY Salary DESC

--11. Find All Employees with Rank 2
SELECT *
FROM
(
	SELECT
		EmployeeID
		,FirstName
		,LastName
		,Salary
		,DENSE_RANK() OVER (PARTITION BY Salary ORDER BY EmployeeID) AS Rank
	FROM Employees
	WHERE Salary BETWEEN 10000 AND 50000
) AS RankingSubquery
WHERE Rank = 2
ORDER BY Salary DESC

--Part II – Queries for Geography Database
--12. Countries Holding 'A' 3 or More Times
SELECT
	CountryName
	,IsoCode
FROM Countries
WHERE LOWER(CountryName) LIKE '%a%a%a%'
ORDER BY IsoCode

--13. Mix of Peak and River Names
SELECT
	 p.PeakName
	,r.RiverName
	,CONCAT(LOWER(p.PeakName), LOWER(RIGHT(r.RiverName, LEN(r.RiverName) - 1))) AS Mix
FROM 
	 Peaks AS p
	,Rivers AS r
WHERE RIGHT(p.PeakName, 1) = LOWER(LEFT(r.RiverName, 1))
ORDER BY Mix

--Part III – Queries for Diablo Database
--14. Games from 2011 and 2012 Year
SELECT TOP (50)
	 [Name]
	,FORMAT([Start], 'yyyy-MM-dd') AS [Start]
FROM Games
WHERE YEAR([Start]) IN (2011, 2012)
ORDER BY
	 [Start]
	,[Name]

--15. User Email Providers
SELECT
	 Username
	,SUBSTRING(Email, CHARINDEX('@', Email) + 1, LEN(Email)) AS [Email Provider]
FROM Users
ORDER BY
	 [Email Provider]
	,Username

--16. Get Users with IP Address Like Pattern
SELECT 
	 [Username]
	,IpAddress
FROM Users
WHERE IpAddress LIKE '___.1%.%.___'
ORDER BY Username

--17. Show All Games with Duration and Part of the Day
SELECT
	 [Name] AS Game
	,CASE
		WHEN DATEPART(HOUR, [Start]) >= 0 AND DATEPART(HOUR, [Start]) < 12 THEN 'Morning'
		WHEN DATEPART(HOUR, [Start]) >= 12 AND DATEPART(HOUR, [Start]) < 18 THEN 'Afternoon'
		WHEN DATEPART(HOUR, [Start]) >= 18 AND DATEPART(HOUR, [Start]) < 24 THEN 'Evening'
	 END AS [Part of the Day]
	,CASE
		WHEN Duration <= 3 THEN 'Extra Short'
		WHEN Duration >= 4 AND Duration <= 6 THEN 'Short'
		WHEN Duration > 6 THEN 'Long'
		ELSE 'Extra Long'
	 END AS Duration
FROM Games AS g
ORDER BY
	 [Game]
	,Duration
	,[Part of the Day]

--Part IV – Date Functions Queries
--18. Orders Table
CREATE DATABASE Orders
USE Orders

CREATE TABLE Orders
(
	Id INT IDENTITY PRIMARY KEY
	,ProductName VARCHAR(50) NOT NULL
	,OrderDate DATETIME2 NOT NULL
)

INSERT INTO Orders
(
	ProductName
	,OrderDate
)
VALUES
	('Butter', '2016-09-19'),
	('Milk', '2016-09-30'),
	('Cheese', '2016-09-04'),
	('Bread', '2015-12-20'),
	('Tomatoes', '2015-12-30')

SELECT
	ProductName
	,OrderDate
	--,(DATEPART(DAY, OrderDate) + 3) AS [Pay Due]
	,DATEADD(DAY, 3, OrderDate) AS [Pay Due]
	,DATEADD(MONTH, 1, OrderDate) AS [Deliver Due]
FROM Orders

--19. People Table
CREATE TABLE People
(
	Id INT IDENTITY PRIMARY KEY
	,[Name] VARCHAR(100) NOT NULL
	,Birthdate DATETIME2 NOT NULL
)

INSERT INTO People
(
	[Name]
	,Birthdate
)
VALUES
	('Victor', '2000-12-07'),
	('Steven', '1992-09-10'),
	('Stephen', '1910-09-19'),
	('John', '2010-01-06')

SELECT
	[Name]
	,DATEDIFF(YEAR, Birthdate, GETDATE()) AS [Age in Years]
	,DATEDIFF(MONTH, Birthdate, GETDATE()) AS [Age in Months]
	,DATEDIFF(DAY, Birthdate, GETDATE()) AS [Age in Days]
	,DATEDIFF(MINUTE, Birthdate, GETDATE()) AS [Age in Minutes]
FROM People

SELECT *
FROM People
