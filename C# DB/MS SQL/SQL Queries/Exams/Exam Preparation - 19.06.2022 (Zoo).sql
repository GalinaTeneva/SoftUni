--Section 1. DDL (30 pts)
--01. Database design
CREATE DATABASE Zoo

CREATE TABLE Owners
(
	 Id INT IDENTITY PRIMARY KEY
	,[Name] VARCHAR(50) NOT NULL
	,PhoneNumber VARCHAR(15) NOT NULL
	,[Address] VARCHAR(50)
)

CREATE TABLE AnimalTypes
(
	 Id INT IDENTITY PRIMARY KEY
	,AnimalType VARCHAR(30) NOT NULL
)

CREATE TABLE Cages
(
	 Id INT IDENTITY PRIMARY KEY
	,AnimalTypeId INT FOREIGN KEY REFERENCES AnimalTypes(Id) NOT NULL
)

CREATE TABLE Animals
(
	 Id INT IDENTITY PRIMARY KEY
	,[Name] VARCHAR(30) NOT NULL
	,BirthDate DATE NOT NULL
	,OwnerId INT FOREIGN KEY REFERENCES Owners(Id)
	,AnimalTypeId INT FOREIGN KEY REFERENCES AnimalTypes(Id) NOT NULL
)

CREATE TABLE AnimalsCages
(	 CageId INT FOREIGN KEY REFERENCES Cages(Id) NOT NULL
	,AnimalId INT FOREIGN KEY REFERENCES Animals(Id) NOT NULL
	,PRIMARY KEY (CageID, AnimalId)
)

CREATE TABLE VolunteersDepartments
(
	 Id INT IDENTITY PRIMARY KEY
	,DepartmentName VARCHAR(30) NOT NULL
)

CREATE TABLE Volunteers
(
	 Id INT IDENTITY PRIMARY KEY
	,[Name] VARCHAR(50) NOT NULL
	,PhoneNumber VARCHAR(15) NOT NULL
	,[Address] VARCHAR(50)
	,AnimalId INT FOREIGN KEY REFERENCES Animals(Id)
	,DepartmentId INT FOREIGN KEY REFERENCES VolunteersDepartments(Id) NOT NULL
)

--Section 2. DML (10 pts)
--02. Insert
INSERT INTO Volunteers
VALUES
	    ('Anita Kostova', '0896365412', 'Sofia, 5 Rosa str.', 15, 1)
	   ,('Dimitur Stoev', '0877564223', NULL, 42, 4)
	   ,('Kalina Evtimova', '0896321112', 'Silistra, 21 Breza str.', 9, 7)
	   ,('Stoyan Tomov', '0898564100', 'Montana, 1 Bor str.', 18, 8)
	   ,('Boryana Mileva', '0888112233', NULL, 31, 5)

INSERT INTO Animals
VALUES
	    ('Giraffe', '2018-09-21', 21, 1)
	   ,('Harpy Eagle', '2015-04-17', 15, 3)
	   ,('Hamadryas Baboon', '2017-11-02', NULL, 1)
	   ,('Tuatara', '2021-06-30', 2, 4)

--03. Update
UPDATE Animals
SET OwnerId = (SELECT Id FROM Owners WHERE [Name] = 'Kaloqn Stoqnov')
WHERE OwnerId IS NULL

--04. Delete
DELETE FROM Volunteers
WHERE DepartmentId = (SELECT Id FROM VolunteersDepartments WHERE DepartmentName = 'Education program assistant')

DELETE FROM VolunteersDepartments
WHERE DepartmentName = 'Education program assistant'

--Section 3. Querying (40 pts)
--05. Volunteers
SELECT
	 [Name]
	,PhoneNumber
	,[Address]
	,AnimalId
	,DepartmentId
FROM Volunteers
ORDER BY
	 [Name]
	,AnimalId DESC
	,DepartmentId DESC

--06. Animals data
SELECT
	 a.[Name]
	,atype.AnimalType
	,FORMAT(a.BirthDate, 'd', 'de-de') AS BirthDate
FROM Animals AS a
JOIN AnimalTypes AS atype ON a.AnimalTypeId = atype.Id
ORDER BY
	a.[Name]

--07. Owners and Their Animals
SELECT TOP (5)
	o.[Name]
	,COUNT(a.AnimalTypeId)
FROM Owners AS o
LEFT JOIN Animals AS a ON a.OwnerId = o.Id
GROUP BY o.[Name]
ORDER BY
	 COUNT(a.AnimalTypeId) DESC
	,o.[Name]
	
--08. Owners, Animals and Cages
SELECT
	 CONCAT(o.[Name],'-', a.[Name]) AS OwnersAnimals
	,o.PhoneNumber
	,ac.CageId
FROM Owners AS o
JOIN Animals AS a ON a.OwnerId = o.Id
JOIN AnimalTypes AS aType ON a.AnimalTypeId = aType.Id
JOIN AnimalsCages AS ac ON a.Id = ac.AnimalId
WHERE aType.AnimalType = 'mammals'
ORDER BY
	 o.[Name]
	,a.[Name] DESC

--09. Volunteers in Sofia
SELECT
	 v.[Name]
	,v.PhoneNumber
	,LTRIM(SUBSTRING(LTRIM(v.[Address]), 8, LEN(v.[Address]) - 6)) AS [Address]
FROM Volunteers AS v
JOIN VolunteersDepartments AS vd ON v.DepartmentId = vd.Id
WHERE vd.DepartmentName = 'Education program assistant'
 AND v.[Address] LIKE '%Sofia%'
ORDER BY v.[Name]

--10. Animals for Adoption
SELECT
	 a.[Name]
	,YEAR(a.BirthDate) AS BirthYear
	,aTypes.AnimalType
FROM Animals AS a
JOIN AnimalTypes AS aTypes ON a.AnimalTypeId = aTypes.Id
WHERE aTypes.AnimalType <> 'Birds'
  AND a.OwnerId IS NULL
  AND a.BirthDate > '2018-01-01'
ORDER BY a.[Name]

--Section 4. Programmability (20 pts)
--11. All Volunteers in a Department
GO
CREATE FUNCTION udf_GetVolunteersCountFromADepartment (@VolunteersDepartment VARCHAR(30))
RETURNS INT
AS
BEGIN
	DECLARE @count INT
	SET @count = (
				SELECT COUNT(v.[Name])
				FROM Volunteers AS v
				JOIN VolunteersDepartments AS vd ON v.DepartmentId = vd.Id
				WHERE vd.DepartmentName = @VolunteersDepartment
				)
	RETURN @count
END
GO

--12. Animals with Owner or Not
CREATE PROCEDURE usp_AnimalsWithOwnersOrNot(@AnimalName VARCHAR(30))
AS
BEGIN
	SELECT
		 a.[Name]
		,CASE
			WHEN o.[Name] IS NULL THEN 'For adoption'
			ELSE o.[Name]
		 END AS OwnersName
	FROM Animals AS a
	LEFT JOIN Owners AS o ON a.OwnerId = o.Id
	WHERE a.[Name] = @AnimalName
END
