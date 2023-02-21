--Section 1. DDL (30 pts)
--01. Database design
CREATE DATABASE NationalTouristSitesOfBG
USE NationalTouristSitesOfBG

CREATE TABLE Categories
(
	 Id	INT IDENTITY PRIMARY KEY
	,[Name]	VARCHAR(50) NOT NULL
)

CREATE TABLE Locations
(
	 Id	INT IDENTITY PRIMARY KEY
	,[Name]	VARCHAR(50) NOT NULL
	,Municipality VARCHAR(50)
	,Province VARCHAR(50)
)

CREATE TABLE Sites
(
	 Id	INT IDENTITY PRIMARY KEY
	,[Name]	VARCHAR(100) NOT NULL
	,LocationId INT FOREIGN KEY REFERENCES Locations(Id) NOT NULL
	,CategoryId INT FOREIGN KEY REFERENCES Categories(Id) NOT NULL
	,Establishment VARCHAR(15)
)

CREATE TABLE Tourists
(
	 Id	INT IDENTITY PRIMARY KEY
	,[Name]	VARCHAR(50) NOT NULL
	,Age INT CHECK (Age BETWEEN 0 AND 120) NOT NULL
	,PhoneNumber VARCHAR(20) NOT NULL
	,Nationality VARCHAR(30) NOT NULL
	,Reward VARCHAR(20)
)

CREATE TABLE SitesTourists
(
	 TouristId	INT FOREIGN KEY REFERENCES Tourists(Id) NOT NULL
	,SiteId	INT FOREIGN KEY REFERENCES Sites(Id) NOT NULL
	PRIMARY KEY (TouristId, SiteId)
)

CREATE TABLE BonusPrizes
(
	 Id	INT IDENTITY PRIMARY KEY
	,[Name]	VARCHAR(50) NOT NULL
)

CREATE TABLE TouristsBonusPrizes
(
	 TouristId INT FOREIGN KEY REFERENCES Tourists(Id) NOT NULL
	,BonusPrizeId INT FOREIGN KEY REFERENCES BonusPrizes(Id) NOT NULL
	PRIMARY KEY (TouristId, BonusPrizeId)
)

--Section 2. DML (10 pts)
--02. Insert
INSERT INTO Tourists
VALUES
	 ('Borislava Kazakova', 52, '+359896354244', 'Bulgaria', NULL)
	,('Peter Bosh', 48, '+447911844141', 'UK', NULL)
	,('Martin Smith', 29, '+353863818592', 'Ireland', 'Bronze badge')
	,('Svilen Dobrev', 49, '+359986584786', 'Bulgaria', 'Silver badge')
	,('Kremena Popova', 38, '+359893298604', 'Bulgaria', NULL)

INSERT INTO Sites
VALUES
	 ('Ustra fortress', 90, 7, 'X')
	,('Karlanovo Pyramids', 65, 7, NULL)
	,('The Tomb of Tsar Sevt', 63, 8, 'V BC')
	,('Sinite Kamani Natural Park', 17, 1, NULL)
	,('St. Petka of Bulgaria � Rupite', 92, 6, '1994')

--03. Update
UPDATE Sites
SET Establishment = '(not defined)'
WHERE Establishment IS NULL

--04. Delete
DELETE FROM TouristsBonusPrizes
WHERE BonusPrizeId = (SELECT Id FROM BonusPrizes WHERE [Name] = 'Sleeping bag')

DELETE FROM BonusPrizes
WHERE [Name] = 'Sleeping bag'

--Section 3. Querying (40 pts)
--05. Tourists
SELECT
	 [Name]
	,Age
	,PhoneNumber
	,Nationality
FROM Tourists
ORDER BY
	 Nationality
	,Age DESC
	,[Name]

--06. Sites with Their Location and Category
SELECT
	 s.[Name] AS [Site]
	,l.[Name] AS [Location]
	,s.Establishment
	,c.[Name] AS [Category]
FROM Sites AS s
LEFT JOIN Locations AS l ON s.LocationId = l.Id
LEFT JOIN Categories AS c ON s.CategoryId = c.Id
ORDER BY
	 c.[Name] DESC
	,l.[Name]
	,s.[Name]

--07. Count of Sites in Sofia Province
SELECT
	 l.Province
	,l.Municipality
	,l.[Name] AS [Location]
	,COUNT(s.LocationId) AS CountOfSites
FROM Locations AS l
JOIN Sites AS s ON l.Id = s.LocationId
WHERE Province = 'Sofia'
GROUP BY
	 l.Province
	,l.Municipality
	,l.[Name]
ORDER BY
	 COUNT(s.LocationId) DESC
	,l.[Name]

--08. Tourist Sites established BC
SELECT
	 s.[Name] AS [Site]
	,l.[Name] AS [Location]
	,l.Municipality
	,l.Province
	,s.Establishment
FROM Sites AS s
JOIN Locations AS l ON s.LocationId = l.Id
WHERE LEFT(l.[Name], 1) NOT IN ('B', 'M', 'D') AND
	  s.Establishment LIKE '%BC'
ORDER BY s.[Name]

--09. Tourists with their Bonus Prizes
SELECT
	 t.[Name]
	,t.Age
	,t.PhoneNumber
	,t.Nationality
	,ISNULL(p.[Name], '(no bonus prize)') AS Reward
FROM Tourists AS t
LEFT JOIN TouristsBonusPrizes AS tp ON t.Id = tp.TouristId
LEFT JOIN BonusPrizes AS p ON tp.BonusPrizeId = p.Id
ORDER BY t.[Name]

--10. Tourists visiting History and Archaeology sites
SELECT
	 SUBSTRING(t.[Name], CHARINDEX(' ', t.[Name]), 200) AS LastName
	,t.Nationality
	,t.Age
	,t.PhoneNumber
FROM Tourists AS t
LEFT JOIN SitesTourists AS st ON t.Id = st.TouristId
LEFT JOIN Sites AS s ON st.SiteId = s.Id
LEFT JOIN Categories AS c ON s.CategoryId = c.Id
WHERE c.[Name] = 'History and archaeology'
GROUP BY
	 t.[Name]
	,t.Nationality
	,t.Age
	,t.PhoneNumber
ORDER BY LastName

--Section 4. Programmability (20 pts)
--11. Tourists Count on a Tourist Site
GO
CREATE FUNCTION udf_GetTouristsCountOnATouristSite (@Site VARCHAR(100))
RETURNS INT
AS
BEGIN
	DECLARE @touristsCount INT;

	SET @touristsCount =
			(SELECT COUNT(*)
			FROM Sites AS s
			LEFT JOIN SitesTourists AS st ON s.Id = st.SiteId
			LEFT JOIN Tourists AS t ON st.TouristId = t.Id
			WHERE s.[Name] = @Site)

	RETURN @touristsCount
END
GO

--12. Annual Reward Lottery
CREATE PROCEDURE usp_AnnualRewardLottery(@TouristName VARCHAR(50))
AS
BEGIN
	
	DECLARE @SitesCount INT;

	SET @SitesCount = 
			(SELECT COUNT(*)
			FROM Tourists AS t
			LEFT JOIN SitesTourists AS st ON t.Id = st.TouristId
			WHERE t.[Name] = @TouristName)

	IF(@SitesCount >= 100)
		BEGIN
			UPDATE Tourists
			SET Reward = 'Gold badge'
			WHERE [Name] = @TouristName
		END
	ELSE IF (@SitesCount >= 50 AND @SitesCount < 100)
		BEGIN
			UPDATE Tourists
			SET Reward = 'Silver badge'
			WHERE [Name] = @TouristName
		END
	ELSE IF (@SitesCount >= 25 AND @SitesCount < 50)
		BEGIN
			UPDATE Tourists
			SET Reward = 'Bronze badge'
			WHERE [Name] = @TouristName
		END
	ELSE
		BEGIN
			UPDATE Tourists
			SET Reward = NULL
			WHERE [Name] = @TouristName
		END

	SELECT
		 t.[Name]
		,t.Reward
	FROM Tourists AS t
	LEFT JOIN SitesTourists AS st ON t.Id = st.TouristId
	WHERE t.[Name] = @TouristName
	GROUP BY t.[Name]
			,t.Reward
END
