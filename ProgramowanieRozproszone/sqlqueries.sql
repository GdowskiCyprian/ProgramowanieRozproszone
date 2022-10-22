
DROP TABLE OrderIdtoProductId
DROP TABLE Orders
DROP TABLE Clients
DROP TABLE Products

CREATE TABLE Clients(
ClientId int PRIMARY KEY,
ClientName varchar(255), 
ClientAddress varchar(255)
);
go

CREATE TABLE Products(
ProductId int PRIMARY KEY,
ProductName varchar(255), 
ProductPrice float
);
go

CREATE TABLE Orders (
OrderId int PRIMARY KEY,
OrderDate date,
ClientId int
)
go

CREATE TABLE OrderIdtoProductId(
OrderId int,
ProductId int
)

--for db1
INSERT INTO Clients VALUES (1, 'Cyprian', 'Cyprian Address')
INSERT INTO Clients VALUES (3, 'Piotr', 'Piotr Address')

--for db2
INSERT INTO Clients VALUES (2, 'Patrycja', 'Patrycja Address')
INSERT INTO Clients VALUES (4, 'Student', 'Student Address')

--for db1
INSERT INTO Products VALUES (1,'Laptop',10)
INSERT INTO Products VALUES (3,'Komputer',32.5)

--for db2
INSERT INTO Products VALUES (2,'Monitor',12.5)
INSERT INTO Products VALUES (4,'Myszka',0.4)

--for db1
INSERT INTO Orders VALUES (1, '2022-10-10', 2)
INSERT INTO OrderIdtoProductId VALUES (2,1);
INSERT INTO OrderIdtoProductId VALUES (2,2);

--for db2
INSERT INTO Orders VALUES (2, '2022-10-20', 3)
INSERT INTO OrderIdtoProductId VALUES (1,3);
INSERT INTO OrderIdtoProductId VALUES (1,4);