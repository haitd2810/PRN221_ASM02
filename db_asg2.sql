
create DATABASE PRN221_Assignment02;
GO

USE PRN221_Assignment02;
GO


CREATE TABLE Categories (
    CategoryID INT PRIMARY KEY IDENTITY(1,1),
    CategoryName VARCHAR(50) NOT NULL,
    Description TEXT
);


INSERT INTO Categories (CategoryName, Description)
VALUES 
('Standard', 'Basic and classic pizzas'),
('Specialties', 'Unique and gourmet pizzas');


CREATE TABLE Suppliers (
    SupplierID INT PRIMARY KEY IDENTITY(1,1),
    CompanyName VARCHAR(100),
    Address VARCHAR(255),
    Phone VARCHAR(50)
);


INSERT INTO Suppliers (CompanyName, Address, Phone)
VALUES 
('Pizza Supply Co.', '789 Pizza Ln', '555-7890'),
('Gourmet Ingredients Ltd.', '987 Gourmet St', '555-9876');


CREATE TABLE Products (
    ProductID INT PRIMARY KEY IDENTITY(1,1),
    ProductName VARCHAR(100) NOT NULL,
    SupplierID INT,
    CategoryID INT,
    QuantityPerUnit VARCHAR(50),
    UnitPrice DECIMAL(10, 2),
    ProductImage VARCHAR(100),
    IsPizzaOfTheWeek BIT DEFAULT 0,
    FOREIGN KEY (SupplierID) REFERENCES Suppliers(SupplierID),
    FOREIGN KEY (CategoryID) REFERENCES Categories(CategoryID)
);


INSERT INTO Products (ProductName, SupplierID, CategoryID, QuantityPerUnit, UnitPrice, ProductImage, IsPizzaOfTheWeek)
VALUES 

('Capricciosa', 1, 1, '1 pizza', 70.00, 'https://s.net.vn/EjLp', 1),
('Hawaii', 1, 1, '1 pizza', 75.00, 'https://s.net.vn/a2z0', 1),
('Margarita', 2, 1, '1 pizza', 65.00, 'https://s.net.vn/j8wi', 1),
('Pescatore', 2, 1, '1 pizza', 80.00, 'https://s.net.vn/5pYD', 1),
('Pepperoni', 1, 1, '1 pizza', 68.00, 'https://s.net.vn/1u5j', 1),


('Barcelona', 2, 2, '1 pizza', 70.00, 'https://s.net.vn/Fpt9', 1),
('Four Seasons', 2, 2, '1 pizza', 85.00, 'https://s.net.vn/bX8U', 1),
('Quattro Formaggi', 2, 2, '1 pizza', 90.00, 'https://s.net.vn/Ohgj', 1),
('Calzone', 1, 2, '1 pizza', 75.00, 'https://s.net.vn/XOLE', 1),
('Diavola', 2, 2, '1 pizza', 85.00, 'https://s.net.vn/CU97', 1);


CREATE TABLE Customers (
    CustomerID INT PRIMARY KEY IDENTITY(1,1),
    Password VARCHAR(100),
    ContactName VARCHAR(100),
    Address VARCHAR(255),
    Phone VARCHAR(50)
);


INSERT INTO Customers (Password, ContactName, Address, Phone)
VALUES 
('password123', 'John Doe', '123 Main St', '555-1234'),
('password456', 'Jane Smith', '456 Maple Rd', '555-5678');


CREATE TABLE Orders (
    OrderID INT PRIMARY KEY IDENTITY(1,1),
    CustomerID INT,
    OrderDate DATE,
    RequiredDate DATE,
    ShippedDate DATE,
    Freight DECIMAL(10, 2),
    ShipAddress VARCHAR(255),
    FOREIGN KEY (CustomerID) REFERENCES Customers(CustomerID)
);


INSERT INTO Orders (CustomerID, OrderDate, RequiredDate, ShippedDate, Freight, ShipAddress)
VALUES 
(1, '2024-10-10', '2024-10-12', '2024-10-11', 5.00, '123 Main St'),
(2, '2024-10-11', '2024-10-14', '2024-10-12', 7.50, '456 Maple Rd');


CREATE TABLE OrderDetails (
    OrderID INT,
    ProductID INT,
    UnitPrice DECIMAL(10, 2),
    Quantity INT,
    PRIMARY KEY (OrderID, ProductID),
    FOREIGN KEY (OrderID) REFERENCES Orders(OrderID),
    FOREIGN KEY (ProductID) REFERENCES Products(ProductID)
);


INSERT INTO OrderDetails (OrderID, ProductID, UnitPrice, Quantity)
VALUES 
(1, 1, 70.00, 2),
(1, 3, 65.00, 1),
(2, 2, 75.00, 1);


CREATE TABLE Account (
    AccountID INT PRIMARY KEY IDENTITY(1,1),
    UserName VARCHAR(50) NOT NULL UNIQUE,
    Password VARCHAR(50) NOT NULL,
    FullName VARCHAR(100) NOT NULL,
    Type VARCHAR(20) NOT NULL
);


INSERT INTO Account (UserName, Password, FullName, Type)
VALUES 
('admin', 'admin123', 'Admin User', 'Admin'),
('staff1', 'password1', 'Staff One', 'Staff'),
('staff2', 'password2', 'Staff Two', 'Staff'),
('user1', 'password3', 'User One', 'User'),
('user2', 'password4', 'User Two', 'User'),
('user3', 'password5', 'User Three', 'User');
