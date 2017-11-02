-- 01. Records’ Count

SELECT COUNT(*) as 'Count'
FROM WizzardDeposits

-- 02. Longest Magic Wand

SELECT MAX(MagicWandSize) AS 'LongestMagicWand'
FROM WizzardDeposits

-- 03. Longest Magic Wand per Deposit Groups

SELECT DepositGroup, MAX(MagicWandSize) AS 'LongestMagicWand' 
FROM WizzardDeposits
GROUP BY DepositGroup

-- 04. Smallest Deposit Group per Magic Wand Size


  SELECT DepositGroup FROM
  (SELECT DepositGroup, AVG(MagicWandSize) AS AverageMagicWandSize
   FROM [dbo].[WizzardDeposits]
  GROUP BY DepositGroup) as avgm
  WHERE AverageMagicWandSize = ( SELECT MIN(AverageMagicWandSize) MinAverageMagicWandSize 
								   FROM
								(SELECT DepositGroup, AVG(MagicWandSize) AS AverageMagicWandSize
								   FROM [dbo].[WizzardDeposits]
								  GROUP BY DepositGroup) AS av)

-- 05. Deposits Sum

SELECT DepositGroup, SUM(DepositAmount) AS 'TotalSum' FROM WizzardDeposits
GROUP BY DepositGroup

-- 06. Deposits Sum for Ollivander Family

SELECT DepositGroup, SUM(DepositAmount) AS 'TotalSum' FROM WizzardDeposits
WHERE MagicWandCreator = 'Ollivander family'
GROUP BY DepositGroup

-- 07. Deposits Filter

SELECT DepositGroup, SUM(DepositAmount) AS 'TotalSum' FROM WizzardDeposits
WHERE MagicWandCreator = 'Ollivander family'
GROUP BY DepositGroup
HAVING SUM(DepositAmount) < 150000
ORDER BY TotalSum DESC

-- 08. Deposit Charge

SELECT DepositGroup, MagicWandCreator, MIN(DepositCharge) AS 'MinDepositCharge' 
FROM WizzardDeposits
GROUP BY DepositGroup, MagicWandCreator
ORDER BY MagicWandCreator, DepositGroup

-- 09. Age Groups

SELECT 
      CASE
	  WHEN Age >= 0 AND Age <=10 THEN '[0-10]'
	  WHEN Age >= 11 AND Age <=20 THEN '[11-20]'
	  WHEN Age >= 21 AND Age <=30 THEN '[21-30]'
	  WHEN Age >= 31 AND Age <=40 THEN '[31-40]'
	  WHEN Age >= 41 AND Age <=50 THEN '[41-50]'
	  WHEN Age >= 51 AND Age <=60 THEN '[51-60]'
	  WHEN Age >= 61 THEN '[61+]'
	  END AS AgeGroup,COUNT(Age) AS WizzardCount FROM WizzardDeposits
      GROUP BY CASE
	  WHEN Age >= 0 AND Age <=10 THEN '[0-10]'
	  WHEN Age >= 11 AND Age <=20 THEN '[11-20]'
	  WHEN Age >= 21 AND Age <=30 THEN '[21-30]'
	  WHEN Age >= 31 AND Age <=40 THEN '[31-40]'
	  WHEN Age >= 41 AND Age <=50 THEN '[41-50]'
	  WHEN Age >= 51 AND Age <=60 THEN '[51-60]'
	  WHEN Age >= 61 THEN '[61+]'
	  END

-- 10. First Letter

SELECT LEFT(FirstName, 1) AS 'FirstLetter' FROM WizzardDeposits
WHERE DepositGroup = 'Troll Chest'
GROUP BY LEFT(FirstName, 1)
ORDER BY FirstLetter

-- 11. Average Interest

SELECT DepositGroup, IsDepositExpired, AVG(DepositInterest) AS 'AverageInterest' FROM WizzardDeposits
WHERE DepositStartDate > '1985-01-01'
GROUP BY DepositGroup, IsDepositExpired
ORDER BY DepositGroup DESC, IsDepositExpired

-- 12. Rich Wizard, Poor Wizard

DECLARE @currentDeposit DECIMAL(8, 2)
DECLARE @previousDeposit DECIMAL(8,2)
DECLARE @totalSum DECIMAL(8, 2) = 0

DECLARE wizardCursor CURSOR FOR SELECT DepositAmount FROM WizzardDeposits
OPEN wizardCursor
FETCH NEXT FROM wizardCursor INTO @currentDeposit

WHILE (@@FETCH_STATUS = 0)
BEGIN
IF(@previousDeposit  IS NOT NULL)
BEGIN
SET @totalSum += (@previousDeposit - @currentDeposit)
END
SET @previousDeposit = @currentDeposit

FETCH NEXT FROM wizardCursor INTO @currentDeposit
END

CLOSE wizardCursor
DEALLOCATE wizardCursor

SELECT @totalSum

SELECT SUM(wizardDep.Diffrence) FROM 
(
SELECT 
FirstName, DepositAmount,
LEAD(FirstName) OVER (ORDER BY Id) AS GuessWizzard,
LEAD(DepositAmount) OVER (ORDER BY Id) AS CuessDeposit,
DepositAmount - LEAD(DepositAmount) OVER (ORDER BY Id) AS Diffrence
FROM WizzardDeposits
) AS wizardDep

-- Функцията Leead е за следващата стойност, a функцията Lag e за предишни стойности.
-- 13. Departments Total Salaries

SELECT DepartmentID, SUM(Salary) AS 'TotalSalary' FROM Employees
GROUP BY DepartmentID 
ORDER BY DepartmentID

-- 14. Employees Minimum Salaries

SELECT DepartmentID, MIN(Salary) AS 'MinimumSalary' FROM Employees
WHERE DepartmentID IN (2,5,7) AND HireDate > '2000-01-01'
GROUP BY DepartmentID

-- 15. Employees Average Salaries

SELECT * INTO NewTable FROM Employees
WHERE Salary > 30000

DELETE NewTable
WHERE ManagerID = 42

UPDATE NewTable
SET Salary += 5000
WHERE DepartmentID = 1

SELECT DepartmentID, AVG(Salary) FROM NewTable
GROUP BY DepartmentID

-- 16. Employees Maximum Salaries

SELECT DepartmentID, MAX(Salary) AS 'MaxSalary' FROM Employees
GROUP BY DepartmentID
HAVING MAX(Salary) NOT BETWEEN 30000 AND 70000;

-- 17. Employees Count Salaries

SELECT COUNT(Salary)  FROM Employees
WHERE ManagerID IS NULL

-- 18. 3rd Highest Salary

SELECT DISTINCT sal.DepartmentID, sal.Salary FROM
(SELECT DepartmentID,Salary,DENSE_RANK() OVER(PARTITION BY  DepartmentID ORDER BY Salary DESC) AS SalaryRank
FROM Employees) AS sal
WHERE sal.SalaryRank = 3

-- 19. Salary Challenge

SELECT TOP 10 e.FirstName, e.LastName, e.DepartmentId FROM Employees AS e
WHERE e.Salary  > (
					SELECT AVG(Salary) FROM Employees AS em
					WHERE e.DepartmentID = em.DepartmentID
					GROUP BY DepartmentID
					)
					






