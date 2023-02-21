--Part I – Queries for SoftUni Database
--01. Employee Address
SELECT TOP (5)
	 e.EmployeeId
	,e.JobTitle
	,e.AddressID
	,a.AddressText
FROM Employees AS e
INNER JOIN Addresses AS a
ON e.AddressID = a.AddressID
ORDER BY e.AddressID

--02. Addresses with Towns
SELECT TOP (50)
	 e.FirstName
	,e.LastName
	,t.[Name] AS Town
	,a.AddressText
FROM Employees AS e
INNER JOIN Addresses AS a ON e.AddressID = a.AddressID
INNER JOIN Towns AS t ON a.TownID = t.TownID
ORDER BY
	 e.FirstName
	,e.LastName

--03. Sales Employee
SELECT
	 e.EmployeeID
	,e.FirstName
	,e.LastName
	,d.[Name] AS [DepartmentName]
FROM Employees AS e
INNER JOIN Departments AS d ON e.DepartmentID = d.DepartmentID
WHERE d.[Name] = 'Sales'
ORDER BY e.EmployeeID

--04. Employee Departments
SELECT TOP (5)
	 e.EmployeeID
	,e.FirstName
	,e.Salary
	,d.[Name] AS [DepartmentName]
FROM Employees AS e
INNER JOIN Departments AS d ON e.DepartmentID = d.DepartmentID
WHERE Salary > 15000
ORDER BY e.DepartmentID

--05. Employees Without Project
SELECT TOP(3)
	 e.EmployeeID
	,e.FirstName
FROM Employees AS e
LEFT JOIN EmployeesProjects AS ep ON e.EmployeeID = ep.EmployeeID
WHERE ep.ProjectID IS NULL
ORDER BY e.EmployeeID

--06. Employees Hired After
SELECT
	 e.FirstName
	,e.LastName
	,e.HireDate
	,d.[Name] AS DeptName
FROM Employees AS e
INNER JOIN Departments AS d ON e.DepartmentID = d.DepartmentID
WHERE HireDate > '1999-01-01'
  AND d.[Name] = 'Sales' OR d.[Name] = 'Finance'
ORDER BY e.HireDate

--07. Employees with Project
SELECT TOP (5)
	 e.EmployeeID
	,e.FirstName
	,p.[Name] AS ProjectName
FROM Employees AS e
INNER JOIN EmployeesProjects AS ep ON e.EmployeeID = ep.EmployeeID
INNER JOIN Projects as p ON ep.ProjectID = p.ProjectID
WHERE p.StartDate > '2002-08-13'
  AND p.EndDate IS NULL
ORDER BY e.EmployeeID

--08. Employee 24
SELECT
	 e.EmployeeID
	,e.FirstName
	, CASE
	  WHEN YEAR(p.StartDate) >= 2005 THEN NULL
	  ELSE p.Name
	  END
	  AS ProjectName
FROM Employees AS e
INNER JOIN EmployeesProjects AS ep ON e.EmployeeID = ep.EmployeeID
INNER JOIN Projects as p ON ep.ProjectID = p.ProjectID
WHERE ep.EmployeeID = 24

--09. Employee Manager
SELECT
	 e.EmployeeID
	,e.FirstName
	,e.ManagerID
	,em.FirstName
FROM Employees AS e
INNER JOIN Employees AS em ON e.ManagerID = em.EmployeeID
WHERE e.ManagerID IN (3, 7)
ORDER BY e.EmployeeID

--10. Employees Summary
SELECT TOP (50)
	e.EmployeeID
	,CONCAT(e.FirstName, ' ', e.LastName) AS EmployeeName
	,CONCAT(em.FirstName, ' ', em.LastName) AS ManagerName
	,d.[Name] AS DepartmentName
FROM Employees AS e
INNER JOIN Employees AS em ON e.ManagerID = em.EmployeeID
INNER JOIN Departments AS d ON e.DepartmentID = d.DepartmentID
ORDER BY e.EmployeeID

--11. Min Average Salary
SELECT MIN (AverageSalary) AS MinAverageSalary
FROM
(
SELECT AVG(Salary) AS AverageSalary
FROM Employees AS e
LEFT JOIN Departments AS d ON e.DepartmentID = d.DepartmentID
GROUP BY d.[Name]
) AS s

--Part II – Queries for Geography Database
--12. Highest Peaks in Bulgaria
SELECT
	 mc.CountryCode
	,m.MountainRange
	,p.PeakName
	,p.Elevation
FROM Peaks AS p
INNER JOIN Mountains AS m ON p.MountainId = m.Id
INNER JOIN MountainsCountries AS mc ON m.Id = mc.MountainId
WHERE CountryCode = 'BG'
  AND Elevation > 2835
ORDER BY Elevation DESC

--13. Count Mountain Ranges
SELECT
	 mc.CountryCode
	 ,COUNT(mc.MountainId) AS MountainRanges
FROM MountainsCountries AS mc
WHERE mc.CountryCode IN
	(
		SELECT CountryCode
		FROM Countries
		WHERE CountryName IN ('United States', 'Russia', 'Bulgaria')
	)
GROUP BY mc.CountryCode

--14. Countries With or Without Rivers
SELECT TOP (5)
	 c.CountryName
	,r.RiverName
FROM Countries AS c
LEFT JOIN CountriesRivers AS cr ON c.CountryCode = cr.CountryCode
LEFT JOIN Rivers AS r ON cr.RiverId = r.Id
LEFT JOIN Continents AS con ON c.ContinentCode = con.ContinentCode
WHERE con.ContinentName = 'Africa'
ORDER BY c.CountryName

--15. *Continents and Currencies
SELECT
	 ContinentCode
	,CurrencyCode
	,CurrencyUsage
FROM
(
		SELECT *
		,DENSE_RANK() OVER (PARTITION BY ContinentCode ORDER BY CurrencyUsage DESC)
		 AS CurrencyRank
	FROM
	(
		SELECT
			 ContinentCode
			,CurrencyCode
			,COUNT(*) AS CurrencyUsage
		FROM Countries
		GROUP BY
			 ContinentCode
			,CurrencyCode
		HAVING COUNT(*) > 1
	) AS CurrencyUsageSubQuery
) AS CurrancyRankingSubQuery
WHERE CurrencyRank = 1

--16. Countries Without Any Mountains
SELECT
COUNT(c.CountryCode)
FROM Countries AS c
LEFT JOIN MountainsCountries AS mc ON c.CountryCode = mc.CountryCode
WHERE mc.MountainId IS NULL

--17. Highest Peak and Longest River by Country
SELECT TOP (5)
	 c.CountryName
	,MAX(p.Elevation) AS HighestPeakElevation
	,MAX(r.[Length]) AS LongestRiverLength
FROM Countries AS c
LEFT JOIN MountainsCountries AS mc ON c.CountryCode = mc.CountryCode
LEFT JOIN Peaks AS p ON mc.MountainId = p.MountainId
LEFT JOIN CountriesRivers AS cr ON c.CountryCode = cr.CountryCode
LEFT JOIN Rivers AS r ON cr.RiverId = r.Id
GROUP BY c.CountryName
ORDER BY
	 HighestPeakElevation DESC
	,LongestRiverLength DESC

--18. Highest Peak Name and Elevation by Country
SELECT TOP (5)
	 CountryName AS Country
	,CASE
	 WHEN Elevation IS NULL THEN '(no highest peak)'
	 ELSE PeakName
	 END
	 AS [Highest Peak Name]
	,CASE
	 WHEN Elevation IS NULL THEN 0
	 ELSE Elevation
	 END
	 AS [Highest Peak Elevation]
	,CASE
	 WHEN Elevation IS NULL THEN '(no mountain)'
	 ELSE MountainRange
	 END
FROM 
(
	SELECT
		 c.CountryName
		,p.PeakName
		,p.Elevation
		,m.MountainRange
		,DENSE_RANK() OVER (PARTITION BY c.CountryName ORDER BY p.Elevation DESC) AS PeaksRank
	FROM Countries AS c
	LEFT JOIN MountainsCountries AS mc ON c.CountryCode = mc.CountryCode
	LEFT JOIN Mountains AS m ON mc.MountainId = m.Id
	LEFT JOIN Peaks AS p ON m.Id = p.MountainId
) AS PeakRankingSubQuery
WHERE PeaksRank = 1
ORDER BY
	 CountryName
	,[Highest Peak Name]

