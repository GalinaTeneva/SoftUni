--Section 1. DDL (30 pts)
--01. Database design
CREATE DATABASE Airport
USE Airport

CREATE TABLE Passengers
	(
		 Id INT PRIMARY KEY IDENTITY
		,FullName VARCHAR(100) UNIQUE NOT NULL
		,Email VARCHAR(50) UNIQUE NOT NULL
	)

CREATE TABLE Pilots
	(
		 Id INT PRIMARY KEY IDENTITY
		,FirstName VARCHAR(30) UNIQUE NOT NULL
		,LastName VARCHAR(30) UNIQUE NOT NULL
		,Age TINYINT NOT NULL CHECK (Age BETWEEN 21 AND 62)
		,Rating FLOAT CHECK(Rating BETWEEN 0.0 AND 10.0)
	)

CREATE TABLE AircraftTypes
	(
		 Id INT PRIMARY KEY IDENTITY
		,TypeName VARCHAR(30) UNIQUE NOT NULL
	)

CREATE TABLE Aircraft
	(
		 Id INT PRIMARY KEY IDENTITY
		,Manufacturer VARCHAR(25) NOT NULL
		,Model VARCHAR(30) NOT NULL
		,[Year] INT NOT NULL
		,FlightHours INT
		,Condition CHAR(1) NOT NULL
		,TypeId INT FOREIGN KEY REFERENCES AircraftTypes(Id) NOT NULL
	)

CREATE TABLE PilotsAircraft
	(
		 AircraftId INT FOREIGN KEY REFERENCES Aircraft(Id) NOT NULL
		,PilotId INT FOREIGN KEY REFERENCES Pilots(Id) NOT NULL
		,PRIMARY KEY (AircraftId, PilotId)
	)

CREATE TABLE Airports
	(
		 Id INT PRIMARY KEY IDENTITY
		,AirportName VARCHAR(70) UNIQUE NOT NULL
		,Country VARCHAR(100) UNIQUE NOT NULL
	)

CREATE TABLE FlightDestinations
	(
		 Id INT PRIMARY KEY IDENTITY
		,AirportId INT FOREIGN KEY REFERENCES Airports(Id) NOT NULL
		,[Start] DATETIME NOT NULL
		,AircraftId INT FOREIGN KEY REFERENCES Aircraft(Id) NOT NULL
		,PassengerId INT FOREIGN KEY REFERENCES Passengers(Id) NOT NULL
		,TicketPrice DECIMAL(18,2) NOT NULL DEFAULT 15
	)

--Section 2. DML (10 pts)
--02. Insert
INSERT INTO Passengers
SELECT
	 CONCAT(FirstName, ' ', LastName) AS FullName
	,CONCAT(FirstName, LastName, '@gmail.com' ) AS Email 
FROM Pilots
WHERE Id BETWEEN 5 AND 15

--03. Update
UPDATE Aircraft
SET Condition = 'A'
WHERE Condition IN ('C', 'B') AND
	  (FlightHours IS NULL OR FlightHours <= 100) AND
	  [Year] >= 2013

--04. Delete
DELETE FROM Passengers
WHERE LEN(FullName) <= 10

--Section 3. Querying (40 pts)
--05. Aircraft
SELECT
	 Manufacturer
	,Model
	,FlightHours
	,Condition
FROM Aircraft
ORDER BY FlightHours DESC

--06. Pilots and Aircraft
SELECT
	 p.FirstName
	,p.LastName
	,a.Manufacturer
	,a.Model
	,a.FlightHours
FROM Pilots AS p
JOIN PilotsAircraft AS pa ON p.Id = pa.PilotId
JOIN Aircraft AS a ON pa.AircraftId = a.Id
WHERE a.FlightHours IS NOT NULL AND a.FlightHours < 304
ORDER BY 
	 a.FlightHours DESC
	,p.FirstName

--07. Top 20 Flight Destinations
SELECT TOP(20)
	 fd.Id AS DestinationId
	,fd.[Start]
	,p.FullName
	,a.AirportName
	,fd.TicketPrice
FROM FlightDestinations AS fd
JOIN Passengers AS p ON fd.PassengerId = p.Id
JOIN Airports AS a ON fd.AirportId = a.Id
WHERE DATEPART(DAY, fd.[Start]) % 2 = 0
ORDER BY 
	 fd.TicketPrice DESC
	,a.AirportName

--08. Number of Flights for Each Aircraft
SELECT
	 a.Id AS AircraftId
	,a.Manufacturer
	,a.FlightHours
	,COUNT(fd.Id) AS FlightDestinationId
	,ROUND(AVG(fd.TicketPrice), 2) AS AvgPrice
FROM Aircraft AS a 
JOIN FlightDestinations AS fd ON a.Id = fd.AircraftId
GROUP BY
	 a.Id
	,a.Manufacturer
	,a.FlightHours
HAVING COUNT(fd.Id) >= 2
ORDER BY
	 4 DESC
	,1

--09. Regular Passengers
SELECT
p.FullName
,COUNT(fd.Id) AS CountOfAircraft
,SUM(fd.TicketPrice) AS TotalPayed
FROM Passengers AS p
JOIN FlightDestinations AS fd ON p.Id = fd.PassengerId
WHERE TRIM(p.FullName) LIKE '_a%'
GROUP BY p.FullName
HAVING COUNT(fd.Id) >=2
ORDER BY p.FullName

--10. Full Info for Flight Destinations
SELECT
	 ap.AirportName
	,fd.[Start] AS DayTime
	,fd.TicketPrice
	,p.FullName
	,ac.Manufacturer
	,ac.Model
FROM FlightDestinations AS fd
JOIN Airports AS ap ON fd.AirportId = ap.Id
JOIN Passengers AS p ON fd.PassengerId = p.Id
JOIN Aircraft AS ac ON fd.AircraftId = ac.Id
WHERE DATEPART(HOUR, fd.[Start]) BETWEEN 6 AND 20
 AND fd.TicketPrice > 2500
ORDER BY ac.Model

--Section 4. Programmability (20 pts)
--11. Find all Destinations by Email Address
GO
CREATE FUNCTION udf_FlightDestinationsByEmail(@email VARCHAR(50))
RETURNS INT
AS
BEGIN

	DECLARE @fdCount INT

	SET @fdCount =
	(
		SELECT COUNT(fd.Id)
		FROM Passengers AS p
		JOIN FlightDestinations AS fd ON p.Id = fd.PassengerId
		WHERE p.Email = @email
		GROUP BY p.Id
	)

	IF(@fdCount IS NULL)
	BEGIN
		SET @fdCount = 0
	END

	RETURN @fdCount
END
GO

--12. Full Info for Airports
CREATE PROCEDURE usp_SearchByAirportName @airportName VARCHAR(70)
AS
BEGIN
SELECT
	 a.AirportName
	,p.FullName
	,CASE
		WHEN fd.TicketPrice <= 400 THEN 'Low'
		WHEN fd.TicketPrice BETWEEN 401 AND 1500 THEN 'Medium'
		WHEN fd.TicketPrice > 1500 THEN 'High'
	 END AS LevelOfTickerPrice
	,ac.Manufacturer
	,ac.Condition
	,act.TypeName
FROM Airports AS a
LEFT JOIN FlightDestinations AS fd ON a.Id = fd.AirportId
LEFT JOIN Passengers AS p ON fd.PassengerId = p.Id
LEFT JOIN Aircraft AS ac ON fd.AircraftId = ac.Id
LEFT JOIN AircraftTypes AS act ON ac.TypeId = act.Id
WHERE a.AirportName = @airportName
ORDER BY
	 ac.Manufacturer
	,p.Email
END

