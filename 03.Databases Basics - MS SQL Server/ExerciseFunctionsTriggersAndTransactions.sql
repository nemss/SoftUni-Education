-- Part I – Queries for SoftUni Database

-- 01. Employees with Salary Above 35000

CREATE PROCEDURE usp_GetEmployeesSalaryAbove35000
AS 
BEGIN
SELECT 
	e.FirstName AS [First Name],
	e.LastName AS [Last Name]
FROM Employees AS e
WHERE e.Salary > 35000
END


EXEC usp_GetEmployeesSalaryAbove35000

-- 02. Employees with Salary Above Number

CREATE PROCEDURE usp_GetEmployeesSalaryAboveNumber (@number Money)
AS
BEGIN
	SELECT e.FirstName, e.LastName FROM Employees AS e
	WHERE e.Salary >= @number
END

EXEC usp_GetEmployeesSalaryAboveNumber 48100

-- 03. Town Names Starting With

CREATE PROCEDURE usp_GetTownsStartingWith (@parameter VARCHAR(20))
AS
BEGIN
	SELECT t.Name FROM Towns AS t
	WHERE t.Name LIKE @parameter+ '%'
END

EXEC usp_GetTownsStartingWith b

-- 04. Employees from Town

CREATE PROCEDURE usp_GetEmployeesFromTown (@townName VARCHAR(50))
AS
BEGIN
	SELECT e.FirstName, e.LastName FROM Employees AS e
	INNER JOIN Addresses AS a
	ON a.AddressID = e.AddressID
	INNER JOIN Towns AS t
	ON t.TownID = a.TownID
	WHERE t.Name = @townName
END

EXEC usp_GetEmployeesFromTown Sofia

-- 05. Salary Level Function

CREATE FUNCTION ufn_GetSalaryLevel (@salary MONEY) 
RETURNS varchar(20)
AS
BEGIN
DECLARE @level varchar(20)
if(@salary < 30000)
	BEGIN
		SET @level = 'Low'
	END
ELSE IF(@salary >=30000 AND @salary<= 50000)
	BEGIN
		SET @level = 'Average'
	END
ELSE IF(@salary > 50000)
	BEGIN
		SET @level = 'High'
	END

RETURN @level
END

CREATE FUNCTION ufn_GetSalaryLevel(@salary MONEY)
RETURNS NVARCHAR(10)
AS
BEGIN
	RETURN
		CASE 
			WHEN @salary < 30000 THEN 'Low'
			WHEN @salary BETWEEN 30000 AND 50000 THEN 'Average'
			WHEN @salary > 50000 THEN 'High'
		END
END

-- 06. Employees by Salary Level

CREATE PROCEDURE usp_EmployeesBySalaryLevel (@levelOfSalary NVARCHAR(10))
AS
BEGIN 
	SELECT e.FirstName, e.LastName FROM Employees AS e
	WHERE dbo.ufn_GetSalaryLevel(e.Salary) = @levelOfSalary
END

EXEC dbo.usp_EmployeesBySalaryLevel 'Low'

-- 07. Define Function

CREATE FUNCTION  ufn_IsWordComprised(@setOfLetters VARCHAR(50), @word VARCHAR(50))
RETURNS BIT
AS
BEGIN
		DECLARE @index INT = 1
		DECLARE @lenght INT = LEN(@word);
		DECLARE @letter CHAR(1)
		WHILE (@index <= @lenght)
		BEGIN
				SET @letter = SUBSTRING(@word, @index, 1)
				IF(CHARINDEX(@letter, @setOfLetters) > 0)
					SET @index = @index + 1
				ELSE
					RETURN 0
		END
RETURN 1		
END

-- 08. Delete Employees and Departments

ALTER TABLE Departments
ALTER TABLE ManagerId INT NULL

SELECT e.EmployeeID FROM Employees AS e
WHERE e.DepartmentID IN (SELECT d.DepartmentID FROM Departments AS d
						 WHERE d.Name IN ('Production', 'Production Control'))

DELETE FROM EmployeesProjects
WHERE EmployeeID IN (SELECT e.EmployeeID FROM Employees AS e
						 WHERE e.DepartmentID IN (SELECT d.DepartmentID FROM Departments AS d
						 WHERE d.Name IN ('Production', 'Production Control')))

UPDATE Employees
SET ManagerID = NULL
WHERE ManagerID IN (SELECT e.EmployeeID FROM Employees AS e
						 WHERE e.DepartmentID IN (SELECT d.DepartmentID FROM Departments AS d
						 WHERE d.Name IN ('Production', 'Production Control')))

UPDATE Departments
SET ManagerID = NULL
WHERE ManagerID IN (SELECT e.EmployeeID FROM Employees AS e
						 WHERE e.DepartmentID IN (SELECT d.DepartmentID FROM Departments AS d
						 WHERE d.Name IN ('Production', 'Production Control')))

DELETE FROM Departments
WHERE Name IN ('Production', 'Production Control')


-- 09. Employees with Three Projects

CREATE PROCEDURE usp_Assignproject(@employeeId INT, @projectId INT)
AS
BEGIN
	BEGIN TRANSACTION 
		INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
		VALUES
			(@employeeId, @projectId)

			IF(SELECT COUNT(*)  FROM EmployeesProjects AS ep
			WHERE ep.EmployeeID = @employeeId) > 3
				BEGIN
					RAISERROR('The employee has too many projects!', 16, 1)
					ROLLBACK
				END
			ELSE
				BEGIN 
					COMMIT
				END
END

-- 10. Find Full Name
USE Bank

CREATE PROCEDURE usp_GetHoldersFullName
AS 
BEGIN
	SELECT b.FirstName + ' ' + b.LastName FROM AccountHolders AS b
END

EXEC usp_GetHoldersFullName

-- 11. People with Balance Higher Than

CREATE PROCEDURE usp_GetHoldersWithBalanceHigherThan (@suppliedNumber MONEY)
AS
BEGIN
	SELECT ah.FirstName, ah.LastName FROM AccountHolders as ah
	INNER JOIN Accounts AS a
	ON ah.Id = a.AccountHolderId
	GROUP BY ah.FirstName, ah.LastName
	HAVING SUM(a.Balance) > @suppliedNumber

END

-- 12. Future Value Function

CREATE FUNCTION ufn_CalculateFutureValue (@sum MONEY, @rate FLOAT, @years INT)
RETURNS MONEY
AS
BEGIN
	DECLARE @result MONEY
	SET @result = @sum * (POWER((1 + @rate), @years))

	RETURN @result
END

SELECT dbo.ufn_CalculateFutureValue (1000, 0.1, 5)

-- 13. Calculating Interest

CREATE PROCEDURE usp_CalculateFutureValueForAccount(@acountId INT, @rate FLOAT)
AS
BEGIN 
 SELECT ah.Id AS [Account Id],
		ah.FirstName [First Name],
		ah.LastName [Last Name],
		a.Balance [Current Balance],
		dbo.ufn_CalculateFutureValue(a.Balance, @rate, 5)
  FROM AccountHolders AS ah
 INNER JOIN Accounts AS a
 ON a.AccountHolderId = ah.Id
 WHERE a.Id = @acountId 
END

EXEC usp_CalculateFutureValueForAccount 1,0.1

-- 14. Deposit Money Procedure

CREATE PROCEDURE usp_DepositMoney (@AcountId INT, @moneyAmount MONEY)
AS
BEGIN
	BEGIN TRAN
	UPDATE Accounts SET Balance += @moneyAmount
	WHERE Accounts.Id = @AcountId
	COMMIT
END

-- 15. Withdraw Money Procedure

CREATE PROCEDURE usp_WithdrawMoney (@AccountId INT, @moneyAmount MONEY)
AS
BEGIN
	BEGIN TRAN
	UPDATE Accounts SET Balance -= @moneyAmount
	WHERE Accounts.Id = @AccountId;
	COMMIT
END
	
-- 16. Money Transfer

CREATE PROCEDURE usp_TransferMoney (@senderId INT, @receiverId INT, @amount MONEY)
AS
BEGIN
	BEGIN TRANSACTION 

	UPDATE Accounts 
	SET Balance-= @amount
	WHERE Id = @senderId

	UPDATE Accounts
	SET Balance += @amount
	WHERE Id = @receiverId

	IF((SELECT Balance FROM Accounts 
		WHERE Id = @senderId) < 0)
		BEGIN 
			ROLLBACK
		END
			COMMIT
END				

-- 17. Create Table Logs

CREATE TABLE Logs
(
LogId INT PRIMARY KEY,
AccountId INT,
OldSum MONEY,
NewSum MONEY
)

CREATE TRIGGER tr_SumUpdate ON Accounts AFTER UPDATE
AS
BEGIN
	INSERT INTO Logs(AccountId, OldSum, NewSum)
	SELECT i.Id, d.Balance, i.Balance FROM inserted AS i
	INNER JOIN deleted AS d
	ON i.AccountHolderId = d.AccountHolderId

END

-- 18. Create Table Emails

CREATE TABLE NotificationEmails
(
Id INT PRIMARY KEY IDENTITY,
Recipinet INT,
Subject VARCHAR(50),
Body VARCHAR(200)
)

CREATE TRIGGER tr_LogsEmail ON Logs AFTER INSERT
AS
BEGIN 
	INSERT INTO NotificationEmails(Recipient, Subject, Body)
	SELECT AccountId,
			'Balance change for account: '
			+ CONVERT(varchar(30), AccountId),
			'On ' + CONVERT(varchar(30), GETDATE()) + ' your balance was changed from '
			+ CONVERT(varchar(30), OldSum) + 'to '
			+ CONVERT (varchar(30), NewSum)
			 FROM Logs
END

-- 19. *Cash in User Games Odd Rows

use Diablo

CREATE FUNCTION ufn_CashInUsersGames (@gameName NVARCHAR(50))
RETURNS @Results TABLE
(
 SumCash MONEY
) 
AS 
BEGIN 
	INSERT INTO @Results
	SELECT SUM(ca.Cash) AS CashSum
		 FROM 
		(SELECT ug.Cash, 
		ROW_NUMBER() OVER (ORDER BY ug.Cash DESC) AS [RowNimber]
		FROM UsersGames AS ug
		INNER JOIN Games AS g
		ON ug.GameId = g.Id
		WHERE g.Name = @gameName) AS ca
		WHERE RowNimber % 2 <> 0
		RETURN
		
END

-- 21. *Massive Shopping

BEGIN TRANSACTION
DECLARE @sum1 MONEY = (SELECT SUM(i.Price)
						FROM Items i
						WHERE MinLevel BETWEEN 11 AND 12)
IF (SELECT Cash FROM UsersGames WHERE Id = 110) < @sum1
ROLLBACK

ELSE BEGIN
		UPDATE UsersGames
		SET Cash = Cash - @sum1
		WHERE Id = 110

		INSERT INTO UserGameItems (UserGameId, ItemId)
		SELECT 110, Id 

		FROM Items 
		WHERE MinLevel BETWEEN 11 AND 12
		COMMIT
	END



BEGIN TRANSACTION
DECLARE @sum2 MONEY = (SELECT SUM(i.Price)
						FROM Items i
						WHERE MinLevel BETWEEN 19 AND 21)

IF (SELECT Cash FROM UsersGames WHERE Id = 110) < @sum2
ROLLBACK
ELSE BEGIN

		UPDATE UsersGames
		SET Cash = Cash - @sum2
		WHERE Id = 110

		INSERT INTO UserGameItems (UserGameId, ItemId)
			SELECT 110, Id 
			FROM Items 
			WHERE MinLevel BETWEEN 19 AND 21
		COMMIT
	END

SELECT i.Name AS 'Item Name' 
FROM UserGameItems ugi
JOIN Items i
ON ugi.ItemId = i.Id
WHERE ugi.UserGameId = 110

-- 22. Number of Users for Email Provider

USE Diablo

SELECT e.[Email Provider], COUNT(e.[Email Provider]) AS [Number Of Users] FROM 
			(SELECT SUBSTRING(u.Email, CHARINDEX('@', u.Email) + 1, LEN(u.Email) - CHARINDEX('@', u.Email)+1) AS [Email Provider]FROM Users AS u
			) AS e
			GROUP BY e.[Email Provider]
			ORDER BY  [Number Of Users] DESC, e.[Email Provider] ASC

-- 23. All Users in Games

SELECT g.Name AS Game,
	   gt.Name AS 'Game Type',
	   u.Username,
	   ug.Level, 
	   ug.Cash,
	   c.Name
 FROM Users AS u
FULL JOIN UsersGames AS ug
ON u.Id = ug.UserId
JOIN Games AS g
ON ug.GameId = g.Id
JOIN GameTypes AS gt
ON g.GameTypeId = gt.Id
JOIN Characters AS c
ON ug.CharacterId = c.Id
ORDER BY ug.Level DESC, u.Username, g.Name

-- 24. Users in Games with Their Items

SELECT u.Username,
	   g.Name AS 'Game', 
	   COUNT(i.Name) AS 'Items Count', 
	   SUM(i.Price) AS 'Items Price' 
	   FROM Users AS u
INNER JOIN UsersGames AS ug
ON u.Id = ug.UserId
INNER JOIN Games AS g
ON ug.GameId = g.Id
INNER JOIN UserGameItems AS ugi
ON ugi.UserGameId = ug.Id
INNER JOIN Items AS i
ON ugi.ItemId = i.Id
GROUP BY g.Name, u.Username
HAVING  COUNT(i.Name) >= 10
ORDER BY [Items Count] DESC, [Items Price] DESC, u.Username 

-- 25. * User in Games with Their Statistics

SELECT Username, g.Name Game, MAX(c.Name) Character, 
		SUM(its.Strength) + MAX(chs.Strength) + MAX(gts.Strength) [Strength], 
		SUM(its.Defence) + MAX(chs.Defence) + MAX(gts.Defence) [Defence], 
		SUM(its.Speed) + MAX(chs.Speed) + MAX(gts.Speed) [Speed], 
		SUM(its.Mind) + MAX(chs.Mind) + MAX(gts.Mind) [Mind], 
		SUM(its.Luck) + MAX(chs.Luck) + MAX(gts.Luck) [Luck]
FROM Users AS u
LEFT JOIN UsersGames AS ug
ON u.Id = ug.UserId
LEFT JOIN Games AS g
ON ug.GameId = g.Id
LEFT JOIN GameTypes AS gt
ON gt.Id = g.GameTypeId
LEFT JOIN UserGameItems AS ugi
ON ugi.UserGameId = ug.Id
LEFT JOIN Items AS i
ON ugi.ItemId = i.Id
LEFT JOIN  Characters AS c
ON ug.CharacterId = c.Id
 LEFT JOIN [Statistics] chs ON chs.Id = c.StatisticId
 LEFT JOIN [Statistics] gts ON gts.Id = gt.BonusStatsId
 LEFT JOIN [Statistics] its ON its.Id = i.StatisticId
 GROUP BY Username, g.Name
 ORDER BY Strength DESC, Defence DESC, Speed DESC, Mind DESC, Luck DESC
	
-- 26. All Items with Greater than Average Statistics
DECLARE @avgMind INT = (SELECT AVG(s.Mind) AS 'AVG Mind' FROM [Statistics] AS s)
SELECT i.Name,
 i.Price, 
 i.MinLevel,
 s.Strength,
 s.Defence,
 s.Speed,
 s.Luck,
 s.Mind FROM Items AS i
INNER JOIN [Statistics] AS s
ON i.StatisticId = s.Id
WHERE (s.Mind) > @avgMind AND s.Luck > @avgMind AND s.Speed > @avgMind 
ORDER BY i.Name

-- 27. Display All Items about Forbidden Game Type

SELECT i.Name, i.Price, i.MinLevel, gt.Name FROM Items AS i
full JOIN GameTypeForbiddenItems AS gtf
ON i.Id = gtf.ItemId
full JOIN GameTypes AS gt 
ON gtf.GameTypeId = gt.Id
ORDER BY gt.Name DESC, i.Name

-- 28. Buy Items for User in Game

DECLARE @userID INT = 
(
	SELECT ug.Id FROM Users AS u
	INNER JOIN UsersGames AS ug
	ON u.Id = ug.UserId
	INNER JOIN Games AS g
	ON g.Id = ug.GameId
	WHERE u.Username = 'Alex' AND g.Name = 'Edinburgh'
)

INSERT INTO UserGameItems (ItemId, UserGameId)
SELECT i.Id, @userID
FROM Items AS i
WHERE i.Name IN ('Blackguard', 
				'Bottomless Potion of Amplification', 
				'Eye of Etlich (Diablo III)', 
				'Gem of Efficacious Toxin', 
				'Golden Gorget of Leoric',
				'Hellfire Amulet')

UPDATE UsersGames
SET Cash -= 
(
	SELECT SUM(i.Price) FROM Items AS i
	WHERE i.Name IN ('Blackguard', 
				'Bottomless Potion of Amplification', 
				'Eye of Etlich (Diablo III)', 
				'Gem of Efficacious Toxin', 
				'Golden Gorget of Leoric',
				'Hellfire Amulet')
)
WHERE Id = 
(
	SELECT ug.Id FROM Users AS u
	INNER JOIN UsersGames AS ug
	ON u.Id = ug.UserId
	INNER JOIN Games AS g
	ON g.Id = ug.GameId
	WHERE u.Username = 'Alex' AND g.Name = 'Edinburgh'
)


SELECT u.Username,
	g.Name, 
	ug.Cash, 
	i.Name AS 'Item Name'
FROM Users AS u
INNER JOIN UsersGames AS ug
ON u.Id = ug.UserId
INNER JOIN Games AS g
ON g.Id = ug.GameId
INNER JOIN UserGameItems AS ugi
ON ug.Id = ugi.UserGameId
INNER JOIN Items AS i
ON i.Id = ugi.ItemId
WHERE g.Name = 'Edinburgh'
ORDER BY i.Name


-- 29. Peaks and Mountains

SELECT p.PeakName,
	   m.MountainRange AS 'Mountain',
	   p.Elevation
 FROM Mountains AS m
INNER JOIN Peaks AS p
ON p.MountainId = m.Id
ORDER BY p.Elevation DESC, P.PeakName

-- 30. Peaks with Mountain, Country and Continent

SELECT p.PeakName,
	   m.MountainRange,
	   c.CountryName,
	   cn.ContinentName
 FROM Countries AS c
INNER JOIN MountainsCountries AS mc
ON c.CountryCode = mc.CountryCode
INNER JOIN Mountains AS m
ON mc.MountainId = m.Id
INNER JOIN Peaks AS p
ON m.Id = p.MountainId
INNER JOIN Continents AS cn
ON c.ContinentCode = cn.ContinentCode
ORDER BY p.PeakName

-- 31. Rivers by Country

SELECT c.CountryName,
		    cn.ContinentName,
		    COUNT(r.RiverName) AS 'RivarsCount',
			ISNULL(SUM(r.Length), 0) AS 'TotalLength'
		 FROM Countries AS c
		FULL JOIN Continents AS cn
		ON c.ContinentCode = cn.ContinentCode
		FULL JOIN CountriesRivers AS cr
		ON c.CountryCode = cr.CountryCode
		FULL JOIN Rivers AS r
		ON cr.RiverId = r.Id
		GROUP BY c.CountryName, cn.ContinentName
		ORDER BY RivarsCount DESC, SUM(r.Length) DESC, c.CountryName

-- 32. Count of Countries by Currency

SELECT cr.CurrencyCode,
	   cr.Description AS 'Currency', 
	   COUNT(co.CurrencyCode) AS 'NumberOfCountries' 
	   FROM Countries AS co
FULL JOIN Currencies AS cr 
ON co.CurrencyCode = cr.CurrencyCode
GROUP BY cr.CurrencyCode, cr.Description
ORDER BY NumberOfCountries DESC, Currency 

-- 33. Population and Area by Continent

SELECT co.ContinentName,
       SUM(cast(c.AreaInSqKm as decimal)) AS 'CountriesArea',
	   SUM(cast(c.Population as decimal)) AS 'CountriesPopulation'
 FROM Continents AS co
LEFT JOIN Countries AS c
ON co.ContinentCode = c.ContinentCode
GROUP BY co.ContinentName
ORDER BY CountriesPopulation DESC

-- 34. Monasteries by Country

CREATE TABLE Monasteries
(
	Id INT IDENTITY PRIMARY KEY,
	Name VARCHAR(50),
	CountryCode CHAR(2),
	CONSTRAINT FK_Monasteries_Countries FOREIGN KEY (CountryCode)
	REFERENCES Countries(CountryCode)
)

INSERT INTO Monasteries(Name, CountryCode) VALUES
('Rila Monastery “St. Ivan of Rila”', 'BG'), 
('Bachkovo Monastery “Virgin Mary”', 'BG'),
('Troyan Monastery “Holy Mother''s Assumption”', 'BG'),
('Kopan Monastery', 'NP'),
('Thrangu Tashi Yangtse Monastery', 'NP'),
('Shechen Tennyi Dargyeling Monastery', 'NP'),
('Benchen Monastery', 'NP'),
('Southern Shaolin Monastery', 'CN'),
('Dabei Monastery', 'CN'),
('Wa Sau Toi', 'CN'),
('Lhunshigyia Monastery', 'CN'),
('Rakya Monastery', 'CN'),
('Monasteries of Meteora', 'GR'),
('The Holy Monastery of Stavronikita', 'GR'),
('Taung Kalat Monastery', 'MM'),
('Pa-Auk Forest Monastery', 'MM'),
('Taktsang Palphug Monastery', 'BT'),
('Sümela Monastery', 'TR')


ALTER TABLE Countries 
ADD IsDeleted BIT NOT NULL DEFAULT 0

UPDATE Countries
SET IsDeleted = 1
    WHERE CountryCode IN (
        SELECT c.CountryCode FROM Countries c
         INNER JOIN CountriesRivers cr ON cr.CountryCode = c.CountryCode
         INNER JOIN Rivers r ON r.Id = cr.RiverId
         GROUP BY c.CountryCode
         HAVING COUNT(r.Id) > 3 )
 
SELECT m.Name ,
	   c.CountryName 
FROM Monasteries AS m
    INNER JOIN Countries c 
	ON c.CountryCode = m.CountryCode
WHERE c.IsDeleted = 0
ORDER BY m.Name

-- 35. Monasteries by Continents and Countries

UPDATE Countries
SET CountryName = 'Burma'
WHERE CountryName = 'Myanmar'

INSERT INTO Monasteries (Name, CountryCode)
VALUES
('Hanga Abbey', (SELECT c.CountryCode FROM Countries AS c
			     WHERE c.CountryName = 'Tanzania')),
('Myin-Tin-Daik', (SELECT c.CountryCode FROM Countries AS c
				   WHERE c.CountryName = 'Myanmar'))

SELECT co.ContinentName,
	   c.CountryName,
	   COUNT(m.Name) AS 'MonasteriesCount'
 FROM Countries AS c
LEFT JOIN Continents AS co
ON c.ContinentCode = co.ContinentCode
LEFT JOIN Monasteries AS m
ON C.CountryCode = m.CountryCode
WHERE c.IsDeleted = 0
GROUP BY co.ContinentName, c.CountryName
ORDER BY MonasteriesCount DESC, c.CountryName
 