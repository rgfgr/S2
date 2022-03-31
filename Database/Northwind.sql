/*SELECT * FROM Products WHERE Discontinued=1
SELECT * FROM Suppliers WHERE Region='Québec'
SELECT * FROM Suppliers WHERE Country='Germany' OR Country='France'
SELECT * FROM Suppliers WHERE HomePage IS NULL
SELECT * FROM Suppliers WHERE HomePage IS NOT NULL AND (Country='Spain' OR Country='UK' OR Country='Sweden' OR Country='Germany' OR Country='Italy' OR Country='Norway' OR Country='France' OR Country='Denmark' OR Country='Netherlands' OR Country='Finland')
SELECT * FROM Employees WHERE FirstName LIKE 'M%'
SELECT * FROM Employees WHERE LastName LIKE '%an'
SELECT * FROM Employees WHERE TitleOfCourtesy='Ms.' OR TitleOfCourtesy='Mrs.'
SELECT * FROM Employees WHERE Title='Sales Representative' AND Country='UK'
SELECT COUNT(DISTINCT ProductName) FROM Products
SELECT AVG(UnitPrice) FROM Products
SELECT * FROM Products WHERE UnitPrice > 20.00 ORDER BY UnitPrice DESC
SELECT * FROM Products WHERE UnitsInStock=0 ORDER BY ProductName ASC
SELECT * FROM Products WHERE UnitsInStock=0 AND UnitsOnOrder=0 AND Discontinued=0 ORDER BY ProductName DESC
SELECT * FROM Customers WHERE Country='France' AND ContactTitle='Owner' OR Country='UK' AND ContactTitle LIKE 'Sales%' ORDER BY Country ASC, ContactName ASC
SELECT * FROM Customers WHERE (Country='Mexico' OR Country='Canada' OR Country='Argentina' OR Country='Brazil' OR Country='USA' OR Country='Venezuela') AND Fax='´no fax number' ORDER BY ContactName ASC
UPDATE Suppliers SET Fax='no fax number' WHERE Fax IS NULL; UPDATE Customers SET Fax='no fax number' WHERE Fax IS NULL
UPDATE Products SET ReorderLevel=10 WHERE ReorderLevel=0 AND UnitsInStock < 20 AND Discontinued=0
UPDATE Customers SET Region='Madrid Province' WHERE Country='Spain' AND City='Madrid'
UPDATE Customers SET Region='Catalonia' WHERE Country='Spain' AND City='Barcelona'
UPDATE Customers SET Region='Andalusia' WHERE Country='Spain' AND City='Sevilla'
UPDATE Customers SET CompanyName='Simons Vaffelhus', Address='Strandvejen 65', City='Vejle', PostalCode='7100' WHERE CompanyName='Simons bistro'
UPDATE Customers SET Address='247 New Avenue', City='Chicago', Region='IL', Phone='555-20159' WHERE CompanyName='White Clover Markets'
UPDATE Employees SET Address='908 W. Capital Way', City='Tacoma', PostalCode='98401' WHERE FirstName='Janet'*/
/*INSERT INTO Employees (LastName, FirstName, BirthDate, HireDate, Address, City, PostalCode, Country, HomePhone, Extension)
VALUES ('Larsen', 'Kim', '1983-05-19 00:00:00', '2022-01-01 00:00:00', 'Violvej 45', 'Sønderborg', '6400', 'Denmark', '75835264', '0745')
INSERT INTO Products (ProductName, CategoryID, QuantityPerUnit, UnitPrice, UnitsInStock, UnitsOnOrder, ReorderLevel, Discontinued)
VALUES ('SuperDuperBeer', 1, '2 boxes x 10 bottels', 500, 5000, 1000, 100, 0)
INSERT INTO Suppliers (CompanyName, ContactName, ContactTitle, Address, City, PostalCode, Country, Phone, Fax, HomePage)
VALUES ('Campus Vejle', 'Patrick Holst', 'super intelligence', 'Boulevarden 48', 'Vejle', '7100', 'Denmark', '72162616', 'no fax number', 'https://campusvejle.dk')
UPDATE Products SET SupplierID=30 WHERE ProductID=78
INSERT INTO Shippers (CompanyName, Phone)
VALUES ('Mærsk', '12345678')*/
/*SELECT DISTINCT Territories.TerritoryDescription, Region.RegionDescription
From Territories
INNER JOIN Region ON Territories.RegionID = Region.RegionID
SELECT Products.ProductName, Products.UnitPrice, Products.UnitsInStock
FROM Products
INNER JOIN Categories ON Products.CategoryID = Categories.CategoryID
WHERE Categories.CategoryName='Beverages' AND Products.Discontinued=0
ORDER BY Products.UnitsInStock ASC, Products.ProductName ASC
SELECT Customers.ContactName
FROM Customers
INNER JOIN Orders ON Customers.CustomerID = Orders.CustomerID
WHERE (DATEPART(yy, Orders.OrderDate) = 1997
AND DATEPART(mm, Orders.OrderDate) = 02)
ORDER BY Orders.OrderDate ASC, Customers.ContactName ASC
SELECT Customers.ContactName, Orders.ShippedDate
FROM Customers
INNER JOIN Orders ON Customers.CustomerID = Orders.CustomerID
WHERE (DATEPART(yy, Orders.OrderDate) = 1997
AND DATEPART(mm, Orders.OrderDate) BETWEEN 04 AND 06)
ORDER BY Orders.OrderDate DESC, Customers.ContactName ASC
SELECT DISTINCT Suppliers.CompanyName
FROM Suppliers
INNER JOIN Products ON Suppliers.SupplierID = Products.SupplierID
INNER JOIN Categories ON Products.CategoryID = Categories.CategoryID
WHERE Categories.CategoryName='Beverages'
ORDER BY Suppliers.CompanyName ASC
SELECT A.FirstName AS FirstName, A.LastName AS LastName, B.FirstName AS BossFirstName, B.LastName AS BossLastName
FROM Employees A
INNER JOIN Employees B ON A.ReportsTo = B.EmployeeID
ORDER BY B.LastName ASC*/