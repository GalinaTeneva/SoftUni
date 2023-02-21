--Section 1. DDL (30 pts)
--01. Database design
CREATE DATABASE CigarShop

USE CigarShop

CREATE TABLE Sizes
(
	 Id INT PRIMARY KEY IDENTITY
	,[Length] INT NOT NULL CHECK([Length] BETWEEN 10 AND 25)
	,RingRange DECIMAL(12,2) NOT NULL CHECK(RingRange BETWEEN 1.5 AND 7.5)
)

CREATE TABLE Tastes
(
	 Id INT PRIMARY KEY IDENTITY
	,TasteType VARCHAR(20) NOT NULL
	,TasteStrength VARCHAR(15) NOT NULL
	,ImageURL NVARCHAR(100) NOT NULL
)

CREATE TABLE Brands
(
	 Id INT PRIMARY KEY IDENTITY
	,BrandName VARCHAR(30) UNIQUE NOT NULL
	,BrandDescription VARCHAR(MAX)
)

CREATE TABLE Cigars
(
	 Id INT PRIMARY KEY IDENTITY
	,CigarName VARCHAR(80) UNIQUE NOT NULL
	,BrandId INT FOREIGN KEY REFERENCES Brands(Id) NOT NULL
	,TastId INT FOREIGN KEY REFERENCES Tastes(Id) NOT NULL
	,SizeId INT FOREIGN KEY REFERENCES Sizes(Id) NOT NULL
	,PriceForSingleCigar MONEY NOT NULL
	,ImageURL NVARCHAR(100) NOT NULL
)

CREATE TABLE Addresses
(
	 Id INT PRIMARY KEY IDENTITY
	,Town VARCHAR(30) NOT NULL
	,Country NVARCHAR(30) NOT NULL
	,Streat NVARCHAR(100) NOT NULL
	,ZIP VARCHAR(20) NOT NULL
)

CREATE TABLE Clients
(
	 Id INT PRIMARY KEY IDENTITY
	,FirstName NVARCHAR(30) NOT NULL
	,LastName NVARCHAR(30) NOT NULL
	,Email NVARCHAR(50) NOT NULL
	,AddressId INT FOREIGN KEY REFERENCES Addresses(Id) NOT NULL
)

CREATE TABLE ClientsCigars
(
	 ClientId INT FOREIGN KEY REFERENCES Clients(Id) NOT NULL
	,CigarId INT FOREIGN KEY REFERENCES Cigars(Id) NOT NULL
	 PRIMARY KEY (ClientId, CigarId)
)

--Section 2. DML (10 pts)
--02. Insert
INSERT INTO Cigars
VALUES
	 ('COHIBA ROBUSTO', 9, 1, 5, 15.50, 'cohiba-robusto-stick_18.jpg')
	,('COHIBA SIGLO I', 9, 1, 10, 410.00, 'cohiba-siglo-i-stick_12.jpg')
	,('HOYO DE MONTERREY LE HOYO DU MAIRE', 14, 5, 11, 7.50, 'hoyo-du-maire-stick_17.jpg')
	,('HOYO DE MONTERREY LE HOYO DE SAN JUAN', 14, 4, 15, 32.00, 'hoyo-de-san-juan-stick_20.jpg')
	,('TRINIDAD COLONIALES', 2, 3, 8, 85.21, 'trinidad-coloniales-stick_30.jpg')

INSERT INTO Addresses
VALUES
	 ('Sofia', 'Bulgaria', '18 Bul. Vasil levski', '1000')
	,('Athens', 'Greece', '4342 McDonald Avenue', '10435')
	,('Zagreb', 'Croatia', '4333 Lauren Drive', '10000')

--03. Update
UPDATE Cigars
SET PriceForSingleCigar = PriceForSingleCigar + (PriceForSingleCigar * 0.2)
WHERE TastId = (
				SELECT Id
				FROM Tastes
				WHERE TasteType = 'Spicy'
				)

UPDATE Brands
SET BrandDescription = 'New description'
WHERE BrandDescription IS NULL

--04. Delete
ALTER TABLE Clients
ALTER COLUMN AddressId INT

UPDATE Clients
SET AddressId = NULL
WHERE AddressId IN (
					SELECT Id
					FROM Addresses
					WHERE LEFT(Country, 1) = 'C'
					)

DELETE
FROM Addresses
WHERE LEFT(Country, 1) = 'C'

--Section 3. Querying (40 pts)
--05. Cigars by Price
SELECT
	 CigarName
	,PriceForSingleCigar
	,ImageURL
FROM Cigars
ORDER BY
	 PriceForSingleCigar
	,CigarName

--06. Cigars by Taste
SELECT
	 c.Id
	,c.CigarName
	,c.PriceForSingleCigar
	,t.TasteType
	,t.TasteStrength
FROM Cigars AS c
LEFT JOIN Tastes AS t ON c.TastId = t.Id
WHERE t.TasteType IN ('Earthy', 'Woody')
ORDER BY c.PriceForSingleCigar DESC
	
--07. Clients without Cigars
SELECT
	 c.Id
	,CONCAT(c.FirstName, ' ', c.LastName) AS ClientName
	,c.Email
FROM Clients AS c
LEFT JOIN ClientsCigars AS cc ON c.Id = cc.ClientId
WHERE cc.CigarId IS NULL
ORDER BY c.FirstName

--08. First 5 Cigars
SELECT TOP(5)
	 c.CigarName
	,c.PriceForSingleCigar
	,c.ImageURL
FROM Cigars AS c
JOIN Sizes AS s ON c.SizeId = s.Id
WHERE
	s.[Length] >= 12 AND (c.CigarName LIKE '%ci%' OR
	PriceForSingleCigar > 50 AND s.RingRange > 2.55)
ORDER BY
	 c.CigarName
	,c.PriceForSingleCigar DESC

--09. Clients with ZIP Codes
SELECT 
	 SubQuery.FullName
	,SubQuery.Country
	,SubQuery.ZIP
	,SubQuery.CigarPrice
FROM
(
	SELECT
		 CONCAT(c.FirstName, ' ', c.LastName) AS FullName
		,a.Country
		,a.ZIP
		,CONCAT('$',cig.PriceForSingleCigar) AS CigarPrice
		,DENSE_RANK() OVER (PARTITION BY CONCAT(c.FirstName, ' ', c.LastName) ORDER BY cig.PriceForSingleCigar DESC) AS [Rank]
	FROM Clients AS c
	LEFT JOIN Addresses AS a ON c.AddressId = a.Id
	LEFT JOIN ClientsCigars AS cc ON c.Id = cc.ClientId
	LEFT JOIN Cigars AS cig ON cc.CigarId = cig.Id
	WHERE ISNUMERIC(a.ZIP) = 1
) AS SubQuery
WHERE [Rank] = 1

--10. Cigars by Size
SELECT
	 c.LastName
	,AVG(s.[Length]) AS CiagrLength
	,CEILING(AVG(s.RingRange)) AS CiagrRingRangege
FROM Clients AS c
JOIN ClientsCigars AS cc ON c.Id = cc.ClientId
JOIN Cigars AS cig ON cc.CigarId = cig.Id
JOIN Sizes AS s ON cig.SizeId = s.Id
GROUP BY c.LastName
ORDER BY CiagrLength DESC

--Section 4. Programmability (20 pts)
--11. Client with Cigars
GO
CREATE FUNCTION udf_ClientWithCigars(@name NVARCHAR(30))
RETURNS INT
AS
BEGIN
	DECLARE @cigarsCount INT;

	SET @cigarsCount =  (SELECT COUNT(cc.CigarId)
						FROM Clients AS c
						LEFT JOIN ClientsCigars AS cc ON c.Id = cc.ClientId
						WHERE c.FirstName = @name)

	RETURN @cigarsCount
END
GO

--12. Search for Cigar with Specific Taste
GO
CREATE PROCEDURE usp_SearchByTaste(@taste VARCHAR(20))
AS
BEGIN
	SELECT
		 c.CigarName
		,CONCAT('$',c.PriceForSingleCigar) AS Price
		,t.TasteType
		,b.BrandName
		,CONCAT(s.[Length], ' cm') AS CigarLength
		,CONCAT(s.RingRange, ' cm') AS CigarRingRange
	FROM Cigars AS c
	LEFT JOIN Tastes AS t ON c.TastId = t.Id
	LEFT JOIN Brands AS b ON b.Id = c.BrandId
	LEFT JOIN Sizes AS s ON s.Id = c.SizeId
	WHERE t.TasteType = @taste
	ORDER BY
		 s.[Length]
		,s.RingRange DESC
END
GO
