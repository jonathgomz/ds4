--Ejemplo 1 
SELECT * FROM Products
GO

--Ejemplo 2
SELECT ProductID, ProductName, UnitPrice FROM Products
GO

--Ejemplo 3
SELECT ProductID, ProductName, UnitPrice
from products
where UnitPrice > 15
GO

--Ejemplo 4
SELECT ProductID, ProductName, UnitPrice
from products
where UnitPrice >= 15 and UnitPrice <= 50
GO

--Ejemplo 5
SELECT ProductID, ProductName, UnitPrice
from products
where UnitPrice BETWEEN 15 and 50
GO

--Ejemplo 6
SELECT ProductID, ProductName, UnitPrice
from products
where NOT UnitPrice > 15
GO

--Ejemplo 7
SELECT ProductID, ProductName, UnitPrice
from products
where UnitPrice < 50 OR UnitPrice < 10
GO

--Ejemplo 8
SELECT EmployeeID, LastName FROM Employees
where LastName LIKE 'D%'
GO

--Ejemplo 9
SELECT EmployeeID, LastName FROM Employees
where LastName LIKE 'N%'
GO

--Ejemplo 10
SELECT EmployeeID, LastName FROM Employees
where LastName LIKE '%SALES%'
GO

--Ejemplo 11
SELECT EmployeeID, LastName FROM Employees
where LastName  NOT LIKE 'D%'
GO

--Ejemplo 12
SELECT ProductID, ProductName, UnitPrice
FROM Products
ORDER BY ProductID ASC
GO

--Ejemplo 13
SELECT ProductID, ProductName, UnitPrice
FROM Products
ORDER BY ProductID DESC
GO

--Ejemplo 14
SELECT DISTINCT OrderID From [Order Details]
GO

--Ejemplo 15 
SELECT TOP 5 OrderID, ProductID, Quantity
FROM [Order Details]
GO

--Ejemplo 16
SELECT TOP 10 PERCENT OrderID, ProductID, Quantity
FROM [Order Details]
GO

--Ejemplo 17
SELECT CategoryName AS [Nombre de Categoria]
FROM Categories
GO

--Ejemplo 18
SELECT OrderID, OrderDate, ShippedDate, ShippedDate + 5 AS RetrasoEnvio
FROM Orders
GO

--Ejemplo 19
SELECT OrderID,P.ProductID, ProductName
From Products P
INNER JOIN [Order Details] OD
ON P.ProductID=OD.ProductID
GO

--Ejemplo 20
SELECT ProductName, CompanyName, ContactName
FROM Products P
FULL JOIN Suppliers S
ON P.SupplierID=S.SupplierID
 GO