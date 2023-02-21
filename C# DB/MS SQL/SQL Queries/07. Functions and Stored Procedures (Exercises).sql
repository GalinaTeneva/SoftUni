--Part I – Queries for SoftUni Database
--01. Employees with Salary Above 35000

CREATE PROC usp_GetEmployeesSalaryAbove35000
AS
BEGIN
	SELECT
		 FirstName AS [First Name]
		,LastName AS [Last Name]
	FROM Employees
	WHERE Salary > 35000
END
GO

--02. Employees with Salary Above Number
CREATE PROCEDURE usp_GetEmployeesSalaryAboveNumber
				(@number DECIMAL(18,4))
AS
BEGIN
	SELECT
		 FirstName AS [First Name]
		,LastName AS [Last Name]
	FROM Employees
	WHERE Salary >= @number
END
GO

--03. Town Names Starting With
CREATE PROCEDURE usp_GetTownsStartingWith @string NVARCHAR(10)
AS
BEGIN
	SELECT [Name]
	FROM Towns
	WHERE [Name] LIKE @string + '%'
END
GO

--04. Employees from Town
CREATE PROCEDURE usp_GetEmployeesFromTown @town NVARCHAR(100)
AS
BEGIN
	SELECT
		 e.FirstName AS [First Name]
		,e.LastName AS [Last Name]
	FROM Employees AS e
	LEFT JOIN Addresses AS a ON e.AddressID = a.AddressID
	LEFT JOIN Towns AS t ON a.TownID = t.TownID
	WHERE t.[Name] = @town
END
GO

--05. Salary Level Function
CREATE FUNCTION ufn_GetSalaryLevel(@salary DECIMAL(18,4))
RETURNS VARCHAR(8)
AS
BEGIN
	DECLARE @salaryLevel VARCHAR (8)

	IF @salary < 30000
	BEGIN
		SET @salaryLevel = 'Low'
	END
	ELSE IF @salary BETWEEN 30000 AND 50000
	BEGIN
		SET @salaryLevel = 'Average'
	END
	ELSE IF @salary > 50000
	BEGIN
		SET @salaryLevel = 'High'
	END
	
	RETURN @salaryLevel
END
GO

--06. Employees by Salary Level
CREATE PROCEDURE usp_EmployeesBySalaryLevel @levelOfSalary VARCHAR(8)
AS
BEGIN
	SELECT
		 FirstName AS [First Name]
		,LastName AS [Last Name]
	FROM Employees
	WHERE dbo.ufn_GetSalaryLevel (Salary) = @levelOfSalary 
END
GO

--07. Define Function
CREATE FUNCTION ufn_IsWordComprised(@setOfLetters NVARCHAR(100), @word NVARCHAR(50))
RETURNS BIT
AS
BEGIN
	DECLARE @wordIndex INT = 1
	WHILE (@wordIndex <= LEN(@word))
	BEGIN
		DECLARE @currChar CHAR = SUBSTRING(@word, @wordIndex, 1)
		IF CHARINDEX(@currChar, @setOfLetters) = 0 
		BEGIN
			RETURN 0
		END

		SET @wordIndex += 1
	END

	RETURN 1;
END
GO

--08. Delete Employees and Departments
CREATE PROCEDURE usp_DeleteEmployeesFromDepartment (@departmentId INT)
AS
BEGIN
	-- Storing employee Ids in a table
	DECLARE @employeeToDelete TABLE (Id INT)
	INSERT INTO @employeeToDelete
		SELECT EmployeeID
		FROM Employees
		WHERE DepartmentID = @departmentId
	
	-- Removing the emmployees from the projects they are working on.
	DELETE
	FROM EmployeesProjects
	WHERE EmployeeID IN (SELECT * FROM @employeeToDelete)

	-- Altering ManagerID column in Departments table in order to be able to set the ManagerId to NULL
	--(if there is an employee to delete who is a manager)
	ALTER TABLE Departments
	ALTER COLUMN ManagerID INT

	UPDATE Departments
	SET ManagerID = NULL
	WHERE ManagerID IN (SELECT * FROM @employeeToDelete)

	--Setting ManagerID to NULL of all employees with futurely delete manager
	--(if there is an employee to delete who is a manager)
	UPDATE Employees
	SET ManagerID = NULL
	WHERE ManagerID IN (SELECT * FROM @employeeToDelete)

	--Deleteing the employees to delete after removing all references to other tables
	DELETE
	FROM Employees
	WHERE DepartmentID = @departmentId

	--Deleting the departments which are left without managers after the deletion of the employees
	DELETE
	FROM Departments
	WHERE DepartmentID = @departmentId

	--Selecting the number of employees from the given department
	SELECT COUNT(*)
	FROM Employees
	WHERE DepartmentID = @departmentId
END
GO

--Part II – Queries for Bank Database
--09. Find Full Name
CREATE PROCEDURE usp_GetHoldersFullName
AS
BEGIN
	SELECT
		CONCAT(FirstName, ' ', LastName) AS [Full Name]
	FROM AccountHolders
END
GO

--10. People with Balance Higher Than
CREATE PROCEDURE usp_GetHoldersWithBalanceHigherThan @number FLOAT
AS
BEGIN
	SELECT
		 ah.FirstName
		,ah.LastName
	FROM Accounts AS a
	JOIN AccountHolders AS ah ON a.AccountHolderId = ah.Id
	GROUP BY
		 ah.FirstName
		,ah.LastName
		,a.AccountHolderId
	HAVING SUM(Balance) > @number
	ORDER BY
		 ah.FirstName
		,ah.LastName
END
GO

--11. Future Value Function
CREATE FUNCTION ufn_CalculateFutureValue (@sum MONEY, @yearlyInterestRate FLOAT, @years INT)
RETURNS MONEY
AS
BEGIN
	DECLARE @futureValue MONEY

	SET @futureValue = FORMAT(@sum * (POWER((1 + @yearlyInterestRate), @years)), 'G', 'en-us')

	RETURN @futureValue
END
GO

--12. Calculating Interest
CREATE PROCEDURE usp_CalculateFutureValueForAccount (@accountId INT, @interestRate FLOAT)
AS
BEGIN
	SELECT
		 ah.Id AS [Account Id]
		,ah.FirstName AS [First Name]
		,ah.LastName AS [Last Name]
		,a.Balance AS [Current Balance]
		,dbo.ufn_CalculateFutureValue(a.Balance, @interestRate, 5) AS [Balance in 5 years]
	FROM AccountHolders AS ah
	JOIN Accounts AS a ON ah.Id = a.AccountHolderId
	WHERE a.Id = @accountId
END
GO

--Part III – Queries for Diablo Database
--13. *Scalar Function: Cash in User Games Odd Rows
CREATE FUNCTION ufn_CashInUsersGames (@gameName NVARCHAR(50))
RETURNS TABLE AS
RETURN
(
	SELECT SUM(Cash) AS [SumCash]
	FROM
	(
		SELECT
			 g.[Name]
			,ug.Cash
			,ROW_NUMBER() OVER (ORDER BY ug.Cash DESC) AS RowNumber
		FROM UsersGames AS ug
		JOIN Games AS g ON ug.GameId = g.Id
		WHERE g.[Name] = @gameName
	) AS RankingSubQuery
	WHERE RowNumber % 2 <> 0
)
