-- Databases MSSQL Server Exam - 19 February 2017
-- 01. Create Database
CREATE DATABASE Bakery
USE Bakery 

CREATE TABLE Countries
(
Id INT IDENTITY, 
CONSTRAINT PK_Countries_Id PRIMARY KEY(Id),
Name NVARCHAR(50) UNIQUE
)

CREATE TABLE Distributors
(
Id INT IDENTITY,
CONSTRAINT PK_Distrbutors_Id PRIMARY KEY(Id),
Name NVARCHAR(25) UNIQUE,
AddressText NVARCHAR(30),
Summary NVARCHAR(200),
CountryId INT,
CONSTRAINT FK_Distributors_Countries FOREIGN KEY(CountryId)
REFERENCES Countries(Id) 
)

CREATE TABLE Ingredients
(
Id INT IDENTITY,
CONSTRAINT PK_Ingredients_Id PRIMARY KEY(Id),
Name NVARCHAR(30),
Description NVARCHAR(200),
OriginCountryId INT,
CONSTRAINT FK_Ingredients_Countries FOREIGN KEY(OriginCountryId)
REFERENCES Countries(Id),
DistributorId INT,
CONSTRAINT FK_Ingredients_Distributors FOREIGN KEY(DistributorId)
REFERENCES Distributors(Id)
)

CREATE TABLE Customers
(
Id INT IDENTITY,
CONSTRAINT PK_Customers_Id PRIMARY KEY(Id),
FirstName NVARCHAR(25),
LastName NVARCHAR(25),
Gender CHAR(1),
CONSTRAINT CK_Customers_Gender CHECK (Gender IN('M','F')),
Age INT,
PhoneNumber CHAR(10),
CountryId INT,
CONSTRAINT FK_Customers_Countries FOREIGN KEY(CountryId)
REFERENCES  Countries(Id)
)

CREATE TABLE Products
(
Id INT IDENTITY,
CONSTRAINT PK_Products PRIMARY KEY(Id),
Name NVARCHAR(25) UNIQUE,
Description NVARCHAR(250),
Recipe NVARCHAR(MAX),
Price MONEY,
CONSTRAINT CK_Price CHECK (Price >= 0 )
)

CREATE TABLE Feedbacks
(
Id INT IDENTITY,
CONSTRAINT PK_Feedbacks PRIMARY KEY(Id),
Description NVARCHAR(255),
Rate DECIMAL(10, 2),
CONSTRAINT CK_Rate CHECK (Rate BETWEEN 0 AND 10),
ProductId INT,
CONSTRAINT FK_Feedbacks_Products FOREIGN KEY(ProductId)
REFERENCES Products(Id),
CustomerId INT,
CONSTRAINT FK_Feedbacks_Customers FOREIGN KEY(CustomerId)
REFERENCES Customers(Id)
)

CREATE TABLE ProductsIngredients
(
ProductId INT,
IngredientId INT,
CONSTRAINT PK_ProductsIngredients PRIMARY KEY (IngredientId, ProductId),
CONSTRAINT FK_ProductsIngredients_Products FOREIGN KEY(ProductId)
REFERENCES Products(Id),
CONSTRAINT FK_ProductsIngredients_Ingredients FOREIGN KEY(IngredientId)
REFERENCES Ingredients(Id)
)

-- 02. Insert

INSERT INTO Distributors (Name, CountryId, AddressText, Summary)
VALUES
('Deloitte & Touche', 2, '6 Arch St #9757', 'Customizable neutral traveling'),
('Congress Title', 13, '58 Hancock St', 'Customer loyalty'),
('Kitchen People', 1, '3 E 31st St #77', 'Triple-buffered stable delivery'),
('General Color Co Inc', 21, '6185 Bohn St #72', 'Focus group'),
('Beck Corporation', 23, '21 E 64th Ave', 'Quality-focused 4th generation hardware')

INSERT INTO Customers (FirstName, LastName, Age, Gender, PhoneNumber, CountryId)
VALUES
('Francoise', 'Rautenstrauch', 15, 'M', '0195698399', 5),
('Kendra', 'Loud', 22, 'F', '0063631526', 11),
('Lourdes', 'Bauswell', 50, 'M', '0139037043', 8),
('Hannah', 'Edmison', 18, 'F', '0043343686', 1),
('Tom', 'Loeza', 31, 'M', '0144876096', 23),
('Queenie', 'Kramarczyk', 30, 'F', '0064215793' ,29),
('Hiu', 'Portaro', 25, 'M', '0068277755', 16),
('Josefa', 'Opitz', 43,'F',	'0197887645', 17)

-- 03. Update

UPDATE Ingredients
SET DistributorId = 35 
WHERE Name in ('Bay Leaf','Paprika' ,'Poppy' )

UPDATE Ingredients
SET OriginCountryId = 14
WHERE OriginCountryId = 8


-- 04.	Delete

DELETE FROM Feedbacks 
WHERE CustomerId = 14  OR ProductId = 5

-- 05.	Products by Price

SELECT P.Name, p.Price, p.Description FROM Products AS p
ORDER BY p.Price DESC, p.Name

-- 06. Ingredients

SELECT i.Name, i.Description, i.OriginCountryId FROM Ingredients AS i
WHERE i.OriginCountryId IN (1, 10, 20)
ORDER BY i.Id

-- 07. Ingredients from Bulgaria and Greece

SELECT TOP(15) i.Name,
			 i.Description,
			 c.Name AS 'CountryName'
FROM Ingredients AS i
INNER JOIN Countries AS c
ON i.OriginCountryId = c.Id
WHERE c.Name IN ('Bulgaria',  'Greece')
ORDER BY i.Name, CountryName 

-- 08. Best Rated Products

SELECT TOP(10) p.Name, 
	   p.Description,
	   AVG(f.Rate) AS 'AverageRate',
	   COUNT(*) AS 'FeedbacksAmount'
FROM Products AS p
INNER JOIN Feedbacks AS f
ON p.Id = f.ProductId
GROUP BY p.Name, p.Description
ORDER BY AverageRate DESC, FeedbacksAmount DESC

-- 09. Negative Feedback

SELECT  f.ProductId,
		f.Rate,
		f.Description,
		f.CustomerId,
		c.Age,
		c.Gender
FROM Customers AS c
INNER JOIN Feedbacks AS f
ON f.CustomerId = c.Id
WHERE f.Rate < 5.0
ORDER BY f.ProductId DESC, f.Rate

-- 10. Customers without Feedback

SELECT CONCAT(c.FirstName, ' ', c.LastName) AS 'CustomerName',
       c.PhoneNumber, 
	   c.Gender
FROM Customers AS c
LEFT JOIN Feedbacks AS f
ON f.CustomerId = c.Id
WHERE f.Id IS NULL
ORDER BY c.Id

-- 11. Honorable Mentions

SELECT f.ProductId,
	   CONCAT(c.FirstName, ' ', c.LastName) AS 'CustomerName',
	   f.Description
FROM Customers AS c
FULL JOIN Feedbacks AS f
ON f.CustomerId = c.Id
FULL JOIN (SELECT f.CustomerId ,COUNT(*) AS 'feedbacks' FROM Feedbacks AS f
GROUP BY f.CustomerId) AS countt
ON countt.CustomerId = f.CustomerId
WHERE countt.feedbacks >= 3
ORDER BY f.ProductId, CustomerName, f.Id

-- 12. Customers by Criteria

SELECT c.FirstName, c.Age, c.PhoneNumber FROM Customers AS c
INNER JOIN Countries AS t
ON c.CountryId = t.Id
WHERE (c.Age >= 21 AND c.FirstName LIKE '%an%') OR
      (RIGHT(RTRIM(c.PhoneNumber),2) = 38 AND t.Name <> 'Creece')
ORDER BY c.FirstName, c.Age DESC

-- 13. Middle Range Distributors

SELECT d.Name,
	   i.Name,
	   P.Name,
	   AVG(f.Rate) AS 'AverageRate' 
FROM Ingredients AS i
INNER JOIN Distributors AS d
ON i.DistributorId = d.Id
INNER JOIN ProductsIngredients AS pn
ON i.Id = pn.IngredientId
INNER JOIN Products AS p
ON p.Id = pn.ProductId
INNER JOIN Feedbacks AS f
ON f.ProductId = p.Id
GROUP BY d.Name, i.Name, p.Name
HAVING AVG(f.Rate) >= 5 AND AVG(f.Rate) <= 8
ORDER BY d.Name, i.Name, p.Name

-- 14. The Most Positive Country

SELECT  top(1) WITH TIES cm.Name, AVG(f.Rate) AS 'FeedbackRate' FROM Feedbacks AS f
INNER JOIN Customers AS c
ON c.Id = f.CustomerId
INNER JOIN Countries AS cm
ON c.CountryId = cm.Id
GROUP BY cm.Name
ORDER BY FeedbackRate DESC

-- 15. Country Representative

SELECT c.Name, d.Name  FROM Ingredients AS i
INNER JOIN Distributors AS d
ON i.DistributorId = d.Id
INNER JOIN Countries AS c
ON d.CountryId = c.Id
INNER JOIN (SELECT TOP(1) WITH TIES d.DistributorId ,COUNT(d.Id) 'Max' FROM Ingredients AS d
GROUP BY d.DistributorId
ORDER BY COUNT(d.Id) DESC) AS aa
ON aa.DistributorId = d.Id
WHERE d.Id = aa.Max

-- 16.	Customers with Countries
GO
CREATE VIEW v_UserWithCountries AS
SELECT CONCAT(c.FirstName, ' ', c.LastName) AS CustomerName,
	   c.Age,
	   c.Gender,
	   cn.Name
FROM Customers AS c
INNER JOIN Countries AS cn
ON c.CountryId = cn.Id
GO

-- 17. Feedback by Product Name

CREATE FUNCTION dbo.udf_GetRating(@ProductName NVARCHAR(25))
RETURNS VARCHAR(20)
AS
BEGIN
DECLARE @word NVARCHAR(20)
DECLARE @avgRate DECIMAL(10,2) = (SELECT AVG(f.Rate) FROM Products AS p 
				   INNER JOIN Feedbacks AS f
				   ON p.Id = f.ProductId
				   WHERE p.Name LIKE @ProductName
				   GROUP BY  f.ProductId
				  )

if(@avgRate < 5)
	BEGIN
		SET @word = 'Bad'
	END
ELSE IF(@avgRate BETWEEN 5 AND 8)
	BEGIN
		SET @word = 'Average'
	END
ELSE IF(@avgRate > 8)
	BEGIN
		SET @word = 'Good'
	END
ELSE 
	BEGIN
	SET @word = 'No rating'
	END

	RETURN @word
END

-- 18.	Send Feedback

CREATE PROCEDURE usp_SendFeedback (@customerId INT, @productId INT, @rate DECIMAL(10,2), @description NVARCHAR(255))
AS
BEGIN
	BEGIN TRANSACTION

	INSERT INTO Feedbacks (CustomerId, ProductId, Rate, Description)
	VALUES
	(@customerId, @productId, @rate, @description)

	IF((SELECT COUNT(*) FROM Feedbacks AS f
	WHERE f.CustomerId = @customerId
	GROUP BY f.CustomerId) > 3)
	BEGIN 
	ROLLBACK
	RAISERROR ('You are limited to only 3 feedbacks per product!',16, 1)
	END 
ELSE
	BEGIN 
	COMMIT
	END
END

-- 19. Delete Products

CREATE TRIGGER tr_DeleteProduct ON Products INSTEAD OF DELETE
AS
BEGIN
	DELETE FROM ProductsIngredients 
	WHERE ProductId = (SELECT d.Id FROM deleted AS d )

	UPDATE [dbo].[Feedbacks]
	SET ProductId = NULL 
	WHERE ProductId = (SELECT d.Id FROM deleted AS d)
END