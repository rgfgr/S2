SELECT * FROM Products WHERE Discontinued=1
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
UPDATE Employees SET Address='908 W. Capital Way', City='Tacoma', PostalCode='98401' WHERE FirstName='Janet'
INSERT INTO Employees (LastName, FirstName, BirthDate, HireDate, Address, City, PostalCode, Country, HomePhone, Extension)
VALUES ('Larsen', 'Kim', 1983/05/19, 2022/01/01, 'Violvej 45', 'Sønderborg', '6400', 'Denmark', '75835264', '0745')