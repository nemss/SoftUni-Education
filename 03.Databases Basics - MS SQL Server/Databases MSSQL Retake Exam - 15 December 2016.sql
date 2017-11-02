CREATE DATABASE TheNerdHerd
USE TheNerdHerd

CREATE TABLE Chats
(
Id INT,
CONSTRAINT PK_Chats_Id PRIMARY KEY (Id),
Title VARCHAR(32),
StartDate DATE,
IsActive BIT
)

CREATE TABLE Locations 
(
Id INT,
CONSTRAINT FK_Locations_Id PRIMARY KEY (Id),
Latitude FLOAT,
Longitude FLOAT
)

CREATE TABLE Credentials
(
Id INT,
CONSTRAINT FK_Credentials_Id PRIMARY KEY (Id),
Email VARCHAR(30),
Password VARCHAR(20)
)

CREATE TABLE Users
(
Id INT IDENTITY,
CONSTRAINT PK_Users_Id PRIMARY KEY (Id),
Nickname VARCHAr(25),
Gender CHAR(1),
Age INT,
LocationId INT,
CredentialId INT UNIQUE,
CONSTRAINT FK_Users_Locations FOREIGN KEY (LocationId)
REFERENCES Locations(Id),
CONSTRAINT FK_Users_CredentialId FOREIGN KEY (CredentialId)
REFERENCES Credentials(Id)
)

CREATE TABLE UsersChats
(
UserId INT,
ChatId INT,
CONSTRAINT PK_UserChats PRIMARY KEY (ChatId, UserId),
CONSTRAINT FK_UserChats_Users FOREIGN KEY (UserId)
REFERENCES Users(Id),
CONSTRAINT FK_ChatId_Chats FOREIGN KEY (ChatId)
REFERENCES Chats(Id)
)

CREATE TABLE Messages
(
Id INT IDENTITY,
CONSTRAINT PK_Messages_Id PRIMARY KEY (Id),
Content VARCHAR(200),
SentOn DATE,
ChatId INT,
UserId INT,
CONSTRAINT FK_Messages_Chats FOREIGN KEY (ChatId)
REFERENCES Chats(Id),
CONSTRAINT FK_Messages_Users FOREIGN KEY (UserId)
REFERENCES Users(Id)
)

-- Section 2. DML 2. Insert

INSERT INTO Messages(Content, ChatId, UserId, SentOn)
SELECT CONCAT(u.Age, '-', u.Gender, '-', l.Latitude, '-', l.Longitude),
	   CASE 
			WHEN u.Gender = 'F' THEN CEILING(SQRT(u.Age * 2))
			WHEN u.Gender = 'M' THEN CEILING(POWER(u.Age / 18,3))
	   END,
	   u.Id,
	   GETDATE()
FROM Users AS u
INNER JOIN Locations AS l
ON u.LocationId = l.Id
WHERE u.Id BETWEEN 10 AND 20

-- Section 2. DML 3. Update

UPDATE Chats
SET StartDate = (SELECT MIN(m.SentOn) FROM Chats AS c
				 INNER JOIN Messages AS m
				 ON c.Id = m.ChatId
				 WHERE c.Id = Chats.Id)
WHERE Chats.Id IN (
					SELECT c.Id FROM Messages AS  m
					INNER JOIN Chats AS c
					ON m.ChatId = c.Id
					GROUP BY c.Id, c.StartDate
					HAVING c.StartDate > MIN(m.SentOn)
					)
-- Section 2. DML 4. Delete

DELETE FROM Locations
WHERE Locations.Id NOT IN (SELECT LocationId FROM Users
					WHERE LocationId IS NOT NULL)

-- Section 3: Querying - 5. Age Range

SELECT u.Nickname,
       u.Gender,
	   u.Age
FROM Users AS u
WHERE u.Age > 22 AND u.Age <=37 

-- Section 3: Querying - 6. Messages

SELECT m.Content,
	   m.SentOn
FROM Messages AS m
WHERE m.SentOn > '2014-05-12' AND
	  m.Content LIKE '%just%'
ORDER BY m.Id DESC

-- Section 3: Querying - 7. Chats

SELECT c.Title,
       c.IsActive
FROM Chats AS c
WHERE (LEN(c.Title) < 5 AND c.IsActive = 0) OR SUBSTRING(c.Title, 3, 2) = 'tl'
ORDER BY c.Title DESC

-- c.Title LIKE '___tl@%'
-- Section 3: Querying - 8. Chat Messages

SELECT c.Id,
	   c.Title,
	   m.Id
FROM Messages AS m
INNER JOIN Chats AS c
ON m.ChatId = c.Id
WHERE m.SentOn < '2012-03-26' AND RIGHT(c.Title, 1) = 'x' 
ORDER BY c.Id, m.Id

-- Section 3: Querying - 9. Message Count

SELECT TOP(5) c.Id, COUNT(*) AS TotalMessages FROM Messages AS m
LEFT JOIN Chats AS c
ON m.ChatId = c.Id
WHERE m.Id < 90
GROUP  BY c.Id
ORDER BY TotalMessages DESC, c.Id 

-- Section 3: Querying - 10. Credentials

SELECT u.Nickname,
	   c.Email,
	   c.Password
FROM Users AS u
INNER JOIN Credentials AS c
ON u.CredentialId = c.Id
WHERE RIGHT(RTRIM(c.Email), 5) = 'co.uk' --LIKE '%co.uk'
ORDER BY c.Email

-- Section 3: Querying - 11. Locations

SELECT u.Id,
	   u.Nickname,
	   u.Age
FROM Users AS u
FULL JOIN Locations AS l
ON u.LocationId = l.Id
WHERE l.Id IS NULL

-- Section 3: Querying - 12. Left Users

SELECT  m.Id , m.ChatId, m.UserId
FROM Messages AS m 
WHERE m.ChatId = 17 AND m.UserId NOT IN(SELECT uc.UserId FROM UsersChats AS uc
										WHERE uc.ChatId = 17) OR m.UserId IS NULL
ORDER BY m.Id DESC

-- Section 3: Querying - 13. Users in Bulgaria

SELECT DISTINCT u.Nickname,
	   c.Title,
	   l.Latitude,
	   l.Longitude
FROM Users AS u
INNER JOIN Locations AS l 
ON u.LocationId = l.Id
INNER JOIN UsersChats AS uc
ON uc.UserId = u.Id
INNER JOIN Chats AS c
ON c.Id = uc.ChatId
WHERE (l.Latitude >= 41.13999 AND l.Latitude <= 44.12999)
  AND (l.Longitude >= 22.20999 AND l.Longitude <= 28.35999)
ORDER BY c.Title

-- Section 3: Querying - 14. Last Chat

SELECT c.Title, m.Content FROM Messages AS m
LEFT JOIN Chats AS c
ON m.ChatId = c.Id
WHERE c.Id = (SELECT top(1) c.Id FROM Chats AS c
			 ORDER BY c.StartDate DESC)

-- Section 4: Programmability - 15. Radians

CREATE FUNCTION udf_GetRadians (@degrees FLOAT)
RETURNS FLOAT
AS
BEGIN

DECLARE @result FLOAT
SET @result =( @degrees * PI()) / 180

RETURN @result

END

SELECT dbo.udf_GetRadians(22.12)

-- Section 4: Programmability - 16. Change Password


CREATE PROCEDURE udp_ChangePassword (@Email VARCHAR(50), @NewPassword VARCHAR(50))
AS
BEGIN

IF NOT EXISTS(SELECT c.Id FROM Credentials AS c
				WHERE c.Email = @Email)
	BEGIN
		RAISERROR('The email does''t exist!', 16, 1)
		RETURN
	END
ELSE
	BEGIN
		UPDATE Credentials
		SET Password = @newPassword
		WHERE Id = (SELECT Id FROM Credentials
					WHERE Email = @Email)
	END
END

CREATE PROCEDURE udp_ChangePassword (@email VARCHAR(50), @newPassword VARCHAR(50))
AS
BEGIN

BEGIN TRANSACTION

UPDATE Credentials
SET Password = @newPassword
WHERE Email = @email

IF(@@ROWCOUNT <> 1)	
	BEGIN 
		ROLLBACK
		RAISERROR('The email does''t exist!', 16, 1)
	END
ELSE
	BEGIN
		COMMIT
	END		
END

EXEC udp_ChangePassword 'abarnes0@sssogou.com', 'new_pass'

--Section 4: Programmability - 17. Send Message

CREATE PROCEDURE udp_SendMessage (@UserId INT, @ChatId INT , @Content VARCHAR(200))
AS
BEGIN

BEGIN TRANSACTION

INSERT INTO Messages(Content, SentOn, ChatId, UserId)
VALUES
(@Content, GETDATE(), @ChatId, @UserId)

IF(@UserId NOT IN (SELECT u.UserId FROM UsersChats AS u
				WHERE u.ChatId = @ChatId))
	BEGIN 
		ROLLBACK
		RAISERROR('There is no chat with that user!', 16, 1)
	END
ELSE
	BEGIN
		COMMIT
	END
END


EXEC dbo.udp_SendMessage 100, 100 , 'scsd'

CREATE  PROCEDURE udp_SendMessage (@userId INT, @chatId INT, @content VARCHAR(MAX))
AS
BEGIN

DECLARE @chatsCount INT = (SELECT COUNT(*) FROM UsersChats 
						   WHERE UserId = @userId AND ChatId = @chatId)

IF(@chatsCount <> 1)
	BEGIN
		RAISERROR('There is no chat with that user!', 16, 1)
	END
ELSE
	BEGIN
		INSERT INTO Messages (UserId, ChatId, Content, SentOn)
		VALUES
		(@userId, @chatId, @content, GETDATE())
	END
END

-- Section 4: Programmability - 18. Log Messages

CREATE TABLE MessageLogs 
(
Id INT PRIMARY KEY,
Content VARCHAR(200),
SentOn DATE,
ChatId INT,
UserId INT
)

CREATE TRIGGER tr_MessegeLogs ON Messages FOR DELETE
AS
BEGIN

INSERT INTO MessageLogs (Id, Content , SentOn ,ChatId, UserId)
SELECT m.Id, 
		 m.Content, 
		 m.SentOn,
		 m.ChatId, 
		 m.UserId 
 FROM deleted AS m

END

-- Section 5: Bonus - 19. Delete users

CREATE TRIGGER tr_DeleteUsers ON Users INSTEAD OF DELETE
AS
BEGIN

		DELETE FROM UsersChats
		WHERE UserId IN (SELECT Id FROM deleted)

		UPDATE Messages
		SET UserId = NULL
		WHERE UserId IN (SELECT Id FROM deleted)

		DELETE FROM Users
		WHERE Id IN (SELECT id FROM deleted)

END
