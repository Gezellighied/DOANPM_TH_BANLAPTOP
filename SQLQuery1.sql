CREATE TABLE Laptops (
    LaptopID INT PRIMARY KEY ,
	LaptopName Nvarchar (50) not null,
    Brand NVARCHAR(50) NOT NULL,
    ScreenSize int NOT NULL,
    Processor NVARCHAR(50) NOT NULL,
    RAM INT NOT NULL,
    Price int NOT NULL,
	Image NVARCHAR (100) NOT NULL
)

CREATE TABLE Customers (
    CustomerID INT PRIMARY KEY,
    Name NVARCHAR(50) NOT NULL,
    Email NVARCHAR(100) NOT NULL,
    Phone NVARCHAR(15) NOT NULL,
)

CREATE TABLE Orders (
    OrderID INT PRIMARY KEY,
    CustomerID INT,
    LaptopID INT,
    FOREIGN KEY (CustomerID) REFERENCES Customers(CustomerID),
    FOREIGN KEY (LaptopID) REFERENCES Laptops(LaptopID)
)

Create table OrderDetails
(
	OrderID int,
	LaptopID int,
	Quantity int,
	Total float,
	primary key (OrderID, LaptopID)
)

Create table Carts
(
	CartID int identity (1, 1) primary key,
	CustomerID int constraint FK_Cart_Customers foreign key references Customers(CustomerID),
	ProductID int constraint FK_Cart_Products foreign key references Laptops(LaptopID),
	Quantity int,
	Total float,
)

Create table Brand
(
	BrandID int primary key,
	Name nvarchar(100) not null,
)