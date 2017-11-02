CREATE DATABASE TableRelations

-- 01. One-To-One Relationship

CREATE TABLE Passports
(
PassportID INT PRIMARY KEY,
PassportNumber VARCHAR(50) NOT NULL
)

CREATE TABLE Persons
(
PersonID INT PRIMARY KEY IDENTITY,
FirstName VARCHAR(50) NOT NULL,
Salary DECIMAL(10,2) NOT NULL,
PassportID INT UNIQUE,
CONSTRAINT FK_Persons_Passport
FOREIGN KEY (PassportID) 
REFERENCES Passports(PassportID)
)


INSERT INTO Passports(PassportID, PassportNumber)
VALUES
(101, 'N34FG21B'),
(102, 'K65LO4R7'),
(103, 'ZE657QP2')

INSERT INTO Persons (FirstName,Salary, PassportID)
Values
('Roberto', 43300.00, 102),
('Tom', 56100.00,103),
('Yana', 60200.00, 101)

-- 02. One-To-Many Relationship

CREATE TABLE Manufacturers
(
ManufacturerID INT IDENTITY,
CONSTRAINT PK_ManufacturerID PRIMARY KEY(ManufacturerID),
Name VARCHAR(50) NOT NULL,
EstablishedOn DATE
)

CREATE TABLE Models
(
ModelID INT,
CONSTRAINT PK_ModelID PRIMARY KEY (ModelID), 
Name VARCHAR(50) NOT NULL,
ManufacturerID INT,
CONSTRAINT FK_Models_Manufactures 
FOREIGN KEY (ManufacturerID) 
REFERENCES Manufacturers(ManufacturerID)
)

INSERT INTO Manufacturers (Name, EstablishedOn)
VALUES
('BMW', '07/03/1916'),
('Tesla', '01/01/2003'),
('Lada', '01/05/1966')

INSERT INTO Models (ModelID, Name, ManufacturerID)
VALUES
(101, 'X1',	1),
(102, 'i6',	1),
(103, 'Model S', 2),
(104, 'Model X', 2),
(105, 'Model 3', 2),
(106, 'Nova', 3)

-- 03. Many-To-Many Relationship

CREATE TABLE Students
(
StudentID INT IDENTITY,
CONSTRAINT PK_StudentsID PRIMARY KEY (StudentID),
Name VARCHAR(50) NOT NULL
)

CREATE TABLE Exams
(
ExamID INT,
CONSTRAINT PK_ExamID PRIMARY KEY (ExamId),
Name VARCHAR(50) NOT NULL
)

CREATE TABLE StudentsExams
(
StudentID INT,
ExamID INT,
CONSTRAINT PK_StudentsExams 
PRIMARY KEY (StudentID, ExamID),
CONSTRAINT FK_StudentsExams_Students
FOREIGN KEY (StudentID) REFERENCES Students(StudentID),
CONSTRAINT FK_StudentsExams_Exams
FOREIGN KEY (ExamID) REFERENCES Exams(ExamID)
)


INSERT INTO Students (Name)
VALUES
('Mila'),
('Toni'),
('Ron')

INSERT INTO Exams (ExamID, Name)
VALUES
(101, 'SpringMVC'),
(102, 'Neo4j'),
(103, 'Oracle 11g')

INSERT INTO StudentsExams (StudentID, ExamID)
VALUES
(1, 101),
(1, 102),
(2, 101),
(3, 103),
(2, 102),
(2, 103)

-- 04. Self-Referencing

CREATE TABLE Teachers
(
TeacherID INT,
CONSTRAINT PK_TeacherID PRIMARY KEY (TeacherID),
Name VARCHAR(50) NOT NULL,
ManagerID INT,
CONSTRAINT FK_ManagerID_TeacherID 
FOREIGN KEY (ManagerID) 
REFERENCES Teachers(TeacherID)
)

INSERT INTO Teachers (TeacherID, Name, ManagerID)

VALUES
(101, 'John', NULL),
(102, 'Maya', 106),
(103, 'Silvia', 106),
(104, 'Ted', 105),
(105, 'Mark', 101),
(106, 'Greta', 101)

-- 05. Online Store Database

CREATE DATABASE OnlineStore
USE OnlineStore

CREATE TABLE Cities
(
CityID INT,
CONSTRAINT PK_CityID PRIMARY KEY (CityID),
Name varchar(50) NOT NULL
)

CREATE TABLE Customers
(
CustomerID INT,
CONSTRAINT PK_CustomerID PRIMARY KEY (CustomerID),
Name VARCHAR(50) NOT NULL,
Birthday DATE,
CityID INT,
CONSTRAINT FK_Customers_Cities 
FOREIGN KEY (CityID) REFERENCES Cities(CityID)
)

CREATE TABLE Orders
(
OrderID INT,
CONSTRAINT PK_OrderID PRIMARY KEY (OrderID),
CustomerID INT,
CONSTRAINT FK_Orders_Customers
FOREIGN KEY (CustomerID) REFERENCES Customers(CustomerID)
)
CREATE TABLE ItemTypes
(
ItemTypeID INT,
CONSTRAINT PK_ItemTypeID PRIMARY KEY (ItemTypeID),
Name VARCHAR(50)
)


CREATE TABLE Items
(
ItemID INT,
CONSTRAINT PK_ItemID PRIMARY KEY (ItemID),
ItemTypeID INT,
CONSTRAINT FK_Items_ItemTypes 
FOREIGN KEY (ItemTypeID) REFERENCES ItemTypes(ItemTypeID)
)
ALTER TABLE Items
ADD Name VARCHAR(50) NOT NULL

CREATE TABLE OrderItems
(
OrderID INT,
ItemID INT,
CONSTRAINT PK_OrderItems
PRIMARY KEY (OrderID, ItemID),
CONSTRAINT FK_OrderItems_Orders
FOREIGN KEY (OrderID) REFERENCES Orders(OrderID),
CONSTRAINT FK_OrderItems_Items
FOREIGN KEY (ItemID) REFERENCES Items(ItemID)
)

-- 06. University Database

CREATE DATABASE UniversityDatabase
USE UniversityDatabase

CREATE TABLE Majors
(
MajorID INT,
CONSTRAINT PK_MajorID PRIMARY KEY (MajorID),
Name VARCHAR(50) NOT NULL
)

CREATE TABLE Students
(
StudentID INT,
CONSTRAINT PK_StudentID PRIMARY KEY (StudentID),
StudentNumber INT,
StudentName VARCHAR(50),
MajorID INT,
CONSTRAINT FK_Students_Majors
FOREIGN KEY (MajorID) REFERENCES Majors(MajorID)
)

CREATE TABLE Subjects
(
SubjectID INT,
CONSTRAINT PK_SubjectID PRIMARY KEY (SubjectID),
SubjectName VARCHAR(50) NOT NULL
)

CREATE TABLE Agenda
(
StudentID INT,
SubjectID INT,
CONSTRAINT PK_Agenda PRIMARY KEY (StudentID, SubjectID),
CONSTRAINT FK_Agenda_Students 
FOREIGN KEY (StudentID) REFERENCES Students(StudentID),
CONSTRAINT FK_Agenda_Subjects 
FOREIGN KEY (SubjectID) REFERENCES Subjects(SubjectID)
)

CREATE TABLE Payments
(
PaymentID INT,
CONSTRAINT PK_PaymentID PRIMARY KEY (PaymentID),
Payment DATE,
PaymentAmount MONEY,
StudentID INT,
CONSTRAINT FK_Payments_Students 
FOREIGN KEY (StudentID) REFERENCES Students(StudentID)
)

-- 09. *Peaks in Rila

USE Geography

SELECT m.MountainRange, p.PeakName, p.Elevation FROM Mountains AS m
 JOIN  Peaks AS p
 ON m.Id = p.MountainId
 WHERE m.MountainRange = 'Rila'
 ORDER BY p.Elevation DESC
