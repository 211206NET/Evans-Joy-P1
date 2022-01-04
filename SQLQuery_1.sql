CREATE DATABASE CRDB;

ALTER DATABASE CRDB
SET AUTO_CLOSE OFF;

USE CRDB;

CREATE TABLE Storefront(
    Id INT PRIMARY KEY IDENTITY(1, 1),
    Name NVARCHAR(450) NOT NULL UNIQUE,
    Address NVARCHAR(100),
    City NVARCHAR(100),
    State NVARCHAR(50)
);


CREATE TABLE Product(
    Id INT PRIMARY KEY IDENTITY(1, 1),
    Name NVARCHAR(450) NOT NULL UNIQUE,
    Description NTEXT,
    Price DECIMAL
);

CREATE TABLE Inventory(
    Id INT PRIMARY KEY IDENTITY(1, 1),
    StorefrontId INT FOREIGN KEY REFERENCES Storefront(Id) NOT NULL,
    ProductId INT FOREIGN KEY REFERENCES Product(Id) NOT NULL,
    Quantity INT,
    Markup DECIMAL
);

-- CREATE TABLE UserType(
--     Id INT PRIMARY KEY IDENTITY(1, 1),
--     Name NVARCHAR(450) NOT NULL
-- );

CREATE TABLE [User](
    -- Note: User is a reserved keyword so use [] so that SQL knows your referring to a table.
    Id INT PRIMARY KEY IDENTITY(1, 1),
    -- UserTypeId INT FOREIGN KEY REFERENCES UserType(Id) NOT NULL,
    Name NVARCHAR(450) NOT NULL,
    Email NVARCHAR(450) NOT NULL,
    IsEmployee BIT NOT NULL
);

CREATE TABLE [Order](
    -- Note: Order is a reserved keyword so use [] so that SQL knows your referring to a table.
    Id INT PRIMARY KEY IDENTITY(1, 1),
    UserId INT FOREIGN KEY REFERENCES [User](Id) NOT NULL,
    StorefrontId INT FOREIGN KEY REFERENCES Storefront(Id) NOT NULL,
    OrderNumber Int NOT NULL,
    OrderDate DATE NOT NULL,
    Total DECIMAL NOT NULL,
    Placed BIT NOT NULL
);

CREATE TABLE LineItem(
    -- Note: Order is a reserved keyword so use [] so that SQL knows your referring to a table.
    Id INT PRIMARY KEY IDENTITY(1, 1),
    InventoryId INT FOREIGN KEY REFERENCES Inventory(Id) NOT NULL,
    OrderId INT FOREIGN KEY REFERENCES [Order](Id) NOT NULL,
    Quantity Int NOT NULL,
);

-- use this link to generate random addresses: https://www.randomlists.com/random-addresses

INSERT INTO Storefront (Name, Address, City, State) VALUES
('CrownReady - Pearland', '868 Manor Lane', 'Pearland', 'TX');

INSERT INTO Storefront (Name, Address, City, State) VALUES
('CrownReady - Houston', '24 Wilson Ave.', 'Houston', 'TX');

INSERT INTO Storefront (Name, Address, City, State) VALUES
('CrownReady - Sugar Land', '8327 Country Club Avenue', 'SugarLand', 'TX');

SELECT * FROM Storefront;