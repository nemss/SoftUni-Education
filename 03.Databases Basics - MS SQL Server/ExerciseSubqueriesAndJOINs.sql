
-- 01. Employee Address

SELECT TOP(5) e.EmployeeID, e.JobTitle, a.AddressID, a.AddressText FROM Employees AS e
INNER JOIN Addresses AS a
ON e.AddressID = a.AddressID
ORDER BY a.AddressID

-- 02. Addresses with Towns

SELECT TOP(50) e.FirstName, e.LastName, t.Name AS Town, a.AddressText FROM Employees AS e
INNER JOIN Addresses AS a
ON e.AddressID = a.AddressID
INNER JOIN Towns AS t
ON t.TownID = a.TownID
ORDER BY e.FirstName, e.LastName

-- 03. Sales Employees

SELECT e.EmployeeID, e.FirstName, e.LastName, d.Name AS DepartmentName FROM Employees AS e
INNER JOIN Departments AS d
ON e.DepartmentID = d.DepartmentID
WHERE d.Name = 'Sales'
ORDER BY e.EmployeeID

-- 04. Employee Departments

SELECT TOP(5) e.EmployeeID, e.FirstName, e.Salary, d.Name AS DepartmentName FROM Employees AS e
INNER JOIN Departments AS d
ON e.DepartmentID = d.DepartmentID
WHERE e.Salary > 15000
ORDER BY e.

-- 05. Employees Without Projects

SELECT TOP(3) e.EmployeeID, e.FirstName FROM Employees AS e
FULL JOIN EmployeesProjects AS ep
ON ep.EmployeeID = e.EmployeeID
FULL JOIN Projects AS p
ON p.ProjectID = ep.ProjectID
WHERE p.ProjectID IS NULL
ORDER BY e.EmployeeID

-- 06. Employees Hired After

SELECT e.FirstName, e.LastName, e.HireDate, d.Name AS DepartmentName FROM Employees AS e
INNER JOIN  Departments AS d
ON e.DepartmentID = d.DepartmentID
WHERE e.HireDate > '01-01-1999' AND
d.Name IN('Sales', 'Finance')

-- 07. Employees With Project

SELECT TOP(5) e.EmployeeID, e.FirstName, p.Name AS ProjectName FROM Employees AS e
INNER JOIN EmployeesProjects AS ep
ON ep.EmployeeID = e.EmployeeID
INNER JOIN Projects AS p
ON ep.ProjectID = p.ProjectID
WHERE p.StartDate > '2002-08-13' AND
p.EndDate IS NULL
ORDER BY e.EmployeeID

-- 08. Employee 24 

SELECT e.EmployeeID,e.FirstName,
CASE
WHEN p.StartDate > '2005-01-01' THEN NULL
	ELSE p.Name
END AS ProjectName
 FROM Employees AS e
FULL JOIN EmployeesProjects AS ep
ON ep.EmployeeID = e.EmployeeID
FULL JOIN Projects AS p
ON p.ProjectID = ep.ProjectID
WHERE e.EmployeeID = 24

-- 09. Employee Manager

SELECT e.EmployeeID, e.FirstName, e.ManagerID, a1.FirstName FROM Employees AS e
INNER JOIN Employees AS a1
ON e.ManagerID = a1.EmployeeID
WHERE e.ManagerID IN(3,7)
ORDER BY e.EmployeeID

-- 10. Employees Summary

	SELECT TOP(50) 
e.EmployeeID,
e.FirstName + ' '+ e.LastName AS EmployeeName,
e1.FirstName  + ' ' + e1.LastName AS ManagerName,
d.Name AS DepartmentName
	FROM Employees AS e
INNER JOIN Employees AS e1
ON e.ManagerID = e1.EmployeeID
INNER JOIN Departments AS d
ON d.DepartmentID = e.DepartmentID
ORDER BY e.EmployeeID

-- 11. Min Average Salary

SELECT MIN(s.avgSalary) AS MinAveregeSalary FROM 
			(
			SELECT AVG(e.Salary) AS avgSalary FROM Employees AS e
			GROUP BY e.DepartmentID
			) AS s

-- 12. Highest Peaks in Bulgaria

SELECT mc.CountryCode, m.MountainRange, p.PeakName, p.Elevation FROM Mountains AS m
INNER JOIN Peaks AS p
ON p.MountainId = m.Id
INNER JOIN MountainsCountries AS mc
ON m.Id = mc.MountainId
WHERE mc.CountryCode = 'BG' AND
p.Elevation > 2835
ORDER BY p.Elevation DESC

-- 13. Count Mountain Ranges

SELECT mc.CountryCode, Count(m.MountainRange) FROM Mountains AS m
INNER JOIN MountainsCountries AS mc
ON mc.MountainId = m.Id
WHERE mc.CountryCode IN(
							SELECT c.CountryCode FROM Countries AS c
							WHERE c.CountryName IN('United States', 'Bulgaria', 'Russia')
						)
GROUP BY mc.CountryCode

-- 14. Countries With or Without Rivers 

SELECT TOP(5) C.CountryName, R.RiverName FROM Rivers AS r
FULL JOIN CountriesRivers AS cr
ON r.Id = cr.RiverId
FULL JOIN Countries AS c
ON c.CountryCode = cr.CountryCode
WHERE c.ContinentCode = 'AF'
ORDER BY c.CountryName

-- 15. Continents and Currencies

SELECT c.ContinentCode, cc.CurrencyCode, 
	   COUNT(cc.CountryCode) AS CurrencyUsage
FROM Continents c
JOIN Countries cc 
ON c.ContinentCode = cc.ContinentCode 
GROUP BY c.ContinentCode , cc.CurrencyCode
HAVING COUNT(cc.CountryCode) = 
	(SELECT MAX(xxx.CurrencyXX) 
    FROM (SELECT cx.ContinentCode, ccx.CurrencyCode, 
				COUNT(ccx.COUNTryCode) AS CurrencyXX
			FROM Continents cx
			JOIN Countries ccx 
			ON cx.ContinentCode = ccx.ContinentCode 
			WHERE c.ContinentCode = cx.ContinentCode 
			GROUP BY cx.ContinentCode , ccx.CurrencyCode) AS xxx)
AND COUNT(cc.CountryCode) > 1
ORDER BY c.ContinentCode
ORDER BY c.ContinentCode

SELECT usages.CurrencyCode, usages.CurrencyCode, usages.Usage FROM 
(
SELECT ContinentCode, CurrencyCode, COUNT(*) AS Usage FROM Countries 
GROUP BY ContinentCode, CurrencyCode
HAVING COUNT(*) > 1
) AS usages
INNER JOIN 
(
	SELECT usages.ContinentCode, MAX(usages.Usage) AS MaxUsage FROM 
	(
		SELECT ContinentCode, CurrencyCode, COUNT(*) AS Usage FROM Countries 
		GROUP BY ContinentCode, CurrencyCode
	) AS usages
	GROUP BY usages.ContinentCode
) AS maxUsages ON usages.ContinentCode = maxUsages.ContinentCode AND maxUsages.MaxUsage = usages.Usage

-- 16. Countries Without any Mountains

SELECT(SELECT Count(CountryCode) FROM Countries) - (SELECT COUNT(cm.CountryCode) FROM	
(SELECT CountryCode FROM MountainsCountries
		GROUP BY CountryCode) AS cm)




-- 17. Highest Peak and Longest River by Country

SELECT TOP(5)
c.CountryName,
MAX(p.Elevation) AS HighestPeakElevetion,
MAX(r.Length) AS LongestRiverLength
 FROM Countries AS c
FULL JOIN MountainsCountries AS mc
ON c.CountryCode = mc.CountryCode
FULL JOIN Peaks AS p
ON p.MountainId = mc.MountainId
FULL JOIN CountriesRivers AS cr
ON c.CountryCode = cr.CountryCode
FULL JOIN Rivers AS r
ON r.Id = cr.RiverId
GROUP BY c.CountryName
ORDER BY HighestPeakElevetion DESC,
		 LongestRiverLength DESC,
		 c.CountryName 

-- 18. Highest Peak Name and Elevation by Country

SELECT TOP(5)
		c.CountryName AS Country, 
		ISNULL(p.PeakName,'(no highest peak)') AS HighestPeakName,
		ISNULL(MAX(p.Elevation),0) AS HighestPeakElevation,
		ISNULL(m.MountainRange, '(no mountain)') AS Mountain
 FROM Countries AS c
LEFT JOIN MountainsCountries AS ms
ON ms.CountryCode = c.CountryCode
LEFT JOIN Peaks AS p
ON p.Id = ms.MountainId
LEFT JOIN Mountains AS m
ON m.Id = ms.MountainId
GROUP BY m.MountainRange, c.CountryName, p.PeakName, p.Elevation
ORDER BY c.CountryName, p.PeakName
