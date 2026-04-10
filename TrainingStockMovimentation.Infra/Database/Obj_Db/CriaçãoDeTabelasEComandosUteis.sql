CREATE TABLE Suppliers (
	Id BIGINT IDENTITY(1,1),
	Name VARCHAR(100) NOT NULL,
	CNPJ VARCHAR (15) NOT NULL ,
	ProductCategory INT NOT NULL

	CONSTRAINT PK_Supplier PRIMARY KEY (Id)
)



CREATE TABLE Products (
	Id BIGINT IDENTITY(1,1),
	Name VARCHAR(150) NOT NULL,
	Description VARCHAR(200) NULL,
	type INT NOT NULL,
	Price DECIMAL(18,2) NOT NULL,
	Amount INT NULL,
	SupplierId BIGINT NOT NULL

	CONSTRAINT PK_Products PRIMARY KEY (Id),
	CONSTRAINT FK_Supplier FOREIGN KEY (SupplierId) REFERENCES Suppliers(Id)
)

CREATE TABLE StockMovement (
	Id BIGINT IDENTITY(1,1),
	ProductId BIGINT NOT NULL,
	Type INT NOT NULL,
	Date DATETIME NOT NULL
	
	CONSTRAINT PK_StockMovement PRIMARY KEY (Id),
	CONSTRAINT FK_Products FOREIGN KEY (ProductId) REFERENCES Products(Id)
)

SELECT * FROM Suppliers
SELECT * FROM Products
SELECT * FROM StockMovement

INSERT INTO Products (Name, Price, type, Amount, SupplierId) VALUES ('BANANA', 18.90, 0, 2, 3)  


BEGIN TRAN
ALTER TABLE Suppliers ALTER COLUMN CNPJ VARCHAR(20)
ROLLBACK


insert into StockMovement (ProductId, Type, Date) values (1, 1, '2026-04-08')


UPDATE Products SET type = 1

SELECT * 
FROM Suppliers S
INNER JOIN Products P ON P.SupplierId = S.Id

SELECT 
                    SM.* 
                    FROM Suppliers S
                    INNER JOIN StockMovement SM ON SM.ProductId = S.Id
                    WHERE S.Id = 1


ALTER TABLE StockMovement ALTER COLUMN ValueMovimentation DECIMAL(18,2) NULL

UPDATE StockMovement SET ValueMovimentation = 18.90 

ALTER TABLE StockMovement ADD QuantityProduct INT NULL

ALTER TABLE StockMovement ADD ContaId INT NULL

ALTER TABLE StockMovement ALTER COLUMN ContaId BIGINT

ALTER TABLE StockMovement ADD CONSTRAINT FK_StockMovement_ContaBC FOREIGN KEY (ContaId) REFERENCES ContaBC(Id)

UPDATE StockMovement SET QuantityProduct = 1

select * from contaBC
SELECT * FROM StockMovement

DELETE StockMovement

UPDATE StockMovement set ContaId = 1 

CREATE TABLE ContaBC (
	Id BIGINT IDENTITY(1,1),
	Name VARCHAR (50),
	Number INT,
	Balance DECIMAL(18,2),
	FlContaAtiva INT,

	CONSTRAINT PK_ContaBC PRIMARY KEY (Id)
)

ALTER TABLE ContaBC ADD CONSTRAINT PK_ContaBC PRIMARY KEY (Id)

ALTER TABLE ContaBC ALTER COLUMN Id BIGINT IDENTITY(1,1)

INSERT INTO ContaBC (Name, Number, Balance, FlContaAtiva) VALUES ('teste jean', 123456, 200, 1)
