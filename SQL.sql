USE master;
GO
DROP DATABASE SupplyChainDb;
GO

CREATE DATABASE SupplyChainDb;
GO

USE SupplyChainDb;
GO
DROP TABLE IF EXISTS Furniture;
CREATE TABLE Furniture (
    ItemID            INT             PRIMARY KEY IDENTITY(10001,1),
    Name              VARCHAR(100)    NOT NULL,
    Category          VARCHAR(50)     NOT NULL,
    Price             DECIMAL(10,2)   NOT NULL,
    StockLevel        INT             NOT NULL DEFAULT 0,
    WarehouseZone     VARCHAR(50)     NOT NULL,
    QuantitySold      INT             NOT NULL DEFAULT 0,
    QuantityRestocked INT             NOT NULL DEFAULT 0
);
GO

INSERT INTO Furniture (Name, Category, Price, StockLevel, WarehouseZone, QuantitySold, QuantityRestocked) VALUES
('Oak Dining Table',      'Tables',  499.99, 15, 'Zone A - Aisle 1', 0, 0),
('Leather Sofa',          'Seating', 899.50,  4, 'Zone B - Aisle 3', 0, 0),
('Queen Bed Frame',       'Beds',    299.00, 20, 'Zone C - Aisle 2', 0, 0),
('Glass Coffee Table',    'Tables',  150.00,  8, 'Zone A - Aisle 2', 0, 0),
('Recliner Chair',        'Seating', 350.00,  2, 'Zone B - Aisle 1', 0, 0),
('Wooden Bookshelf',      'Storage', 199.99, 12, 'Zone D - Rack 4',  0, 0),
('Memory Foam Mattress',  'Beds',    450.00, 30, 'Zone C - Aisle 4', 0, 0),
('TV Stand',              'Storage', 120.00,  5, 'Zone D - Rack 1',  0, 0),
('Office Desk',           'Tables',  250.00, 18, 'Zone A - Aisle 3', 0, 0),
('Ergonomic Chair',       'Seating', 180.00, 25, 'Zone B - Aisle 4', 0, 0),
('Velvet Accent Chair',   'Seating', 220.00,  3, 'Zone B - Aisle 2', 0, 0),
('King Size Bed Frame',   'Beds',    599.99,  6, 'Zone C - Aisle 1', 0, 0),
('Corner Sofa',           'Seating', 999.50,  2, 'Zone B - Aisle 5', 0, 0),
('Nest of Tables',        'Tables',  179.00,  9, 'Zone A - Aisle 4', 0, 0),
('Wardrobe 3-Door',       'Storage', 449.99,  4, 'Zone D - Rack 2',  0, 0),
('Chest of Drawers',      'Storage', 189.99, 10, 'Zone D - Rack 3',  0, 0),
('Bunk Bed Frame',        'Beds',    349.00,  7, 'Zone C - Aisle 3', 0, 0),
('Standing Desk',         'Tables',  399.99,  1, 'Zone A - Aisle 5', 0, 0),
('Dining Chair Set of 4', 'Seating', 299.00,  0, 'Zone B - Aisle 6', 0, 0),
('Floating Wall Shelf',   'Storage',  59.99, 22, 'Zone D - Rack 5',  0, 0);
GO
