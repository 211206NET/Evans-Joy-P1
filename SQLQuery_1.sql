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

INSERT INTO [User] (Name, Email, IsEmployee) VALUES
('Joy', 'joy@email.com', 0);

INSERT INTO [User] (Name, Email, IsEmployee) VALUES
('Admin', 'admin@email.com', 1);

SELECT * FROM [User];

-- Replace Palmer's to Palmer''s to prevent error
INSERT INTO Product (Name, Description, Price) VALUES
('Palmer''s Coconut Oil Formula Moisture Boost Leave-in Conditioner, 8.5 oz.', 
'Palmer''s Coconut Oil Formula Leave-In Conditioner spray instantly detangles, putting an end to tugging and pulling at knotty, unruly hair. With just a few light sprays after towel drying, your hair has instant slip and silkiness for easier comb-through and styling. Hair-nourishing emollients fortify hair, control frizz, reduce split ends and give hair healthy-looking shine. Spray product throughout towel dried or damp hair. Comb through to ends to coat hair with conditioning proteins. Do not rinse. Style as desired. Can be used throughout the day as needed. 
Palmer''s Coconut Oil Formula products contain ethically and sustainably sourced Coconut Oil and Tahitian Monoi, infused with Tiare flower petals. These raw, natural ingredients deeply hydrate, repair damage and give hair incredible shine.',
 5.68);

ALTER TABLE Product
ALTER COLUMN Price DECIMAL(10,2);

UPDATE Product
SET Price = 5.68
WHERE ID = 2;

INSERT INTO Product (Name, Description, Price) VALUES
('OGX Hydrating + Tea Tree Mint Shampoo, Nourishing & Invigorating Scalp Shampoo with Tea Tree & Peppermint Oil & Milk Proteins, Paraben-Free, Sulfate-Free Surfactants, 13 fl. oz', 
'Hydrate with a burst of freshness with this tea tree mint scalp shampoo. Blended with peppermint & tea tree oil, the moisturizing shampoo invigorates the senses with a refreshing tingle on the scalp.',
 5.74);

INSERT INTO Product (Name, Description, Price) VALUES
('Palmer''s Coconut Oil Formula Curl Styler Cream Pudding 14 oz.', 
'Palmer''s Coconut Oil Formula products contain ethically and sustainably sourced Coconut Oil and Tahitian Monoï, infused with Tiaré flower petals. These raw, natural ingredients deeply hydrate, repair damage and give hair incredible shine. 
Palmer''s Coconut Oil Formula Coconut Oil Curl Styler Cream Pudding instantly boosts hydration and adds shine transforming dry, frizzy hair into bouncy, defined curls. Maximizes curl length for longer lasting styles.',
 11.07);

INSERT INTO Product (Name, Description, Price) VALUES
('Cantu Shea Butter Coconut Curling Cream for Natural Hair, 12 oz', 
'Get damaged hair under control with Cantu Shea Butter for Natural Hair Coconut Curling Cream. Made without harsh ingredients, Cantu for Natural Hair restores your real, authentic beauty, bringing out the best curly, kinky, or wavy hair. This richly-hydrating solution for dry hair and damaged hair defines, conditions and adds manageability without any harsh ingredients that can cause more damage. The nourishing formula is 100 percent pure shea butter and real coconut to smooth, soften and hydrate parched, frizzy hair and contains no mineral oil, sulfates, parabens, silicone, phthalates, gluten, paraffin, propylene glycol, PABA or DEA. Its rich, natural scent makes every use more enjoyable. Cantu hair care products are also not tested on animals. 
It''s available in a convenient two pack or as a single container; each jar contains 12 oz.',
 5.87);

SELECT * FROM Product;

INSERT INTO Inventory (StorefrontId, ProductId, Quantity, Markup) VALUES (1, 2, 10, .50);

SELECT * FROM Inventory;

ALTER TABLE [User]
DROP COLUMN IsEmployee;


SELECT * FROM [User] WHERE ID = -1;

ALTER TABLE [User]
ADD IsEmployee BIT;

UPDATE [User]
SET IsEmployee = 0
WHERE ID = 1;

UPDATE [User]
SET IsEmployee = 0
WHERE ID = 2;

UPDATE [User]
SET IsEmployee = 0
WHERE ID = 3;

UPDATE [User]
SET IsEmployee = 0
WHERE ID = 6;

SELECT * FROM [User];