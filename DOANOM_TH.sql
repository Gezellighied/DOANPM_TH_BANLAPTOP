CREATE TABLE Laptops (
    LaptopID INT PRIMARY KEY ,
    Brand NVARCHAR(50) NOT NULL,
    Model NVARCHAR(50) NOT NULL,
    ScreenSize DECIMAL(4, 2) NOT NULL,
    Processor VARCHAR(50) NOT NULL,
    RAM INT NOT NULL,
    Price DECIMAL(10, 2) NOT NULL,
	Image NVARCHAR (100) NOT NULL
)

CREATE TABLE Customers (
    CustomerID INT PRIMARY KEY,
    Name NVARCHAR(50) NOT NULL,
    Email VARCHAR(100) NOT NULL,
    Phone VARCHAR(15) NOT NULL,
    Address VARCHAR(255) NOT NULL
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
	CartId int identity (1, 1) primary key,
	CustomerId int constraint FK_Cart_Customers foreign key references Customers(CustomerId),
	ProductId int constraint FK_Cart_Products foreign key references Laptops(LaptopId),
	Quantity int,
	Total float,
	UpdateDay date,
)

Create table Brand
(
	BrandId int primary key,
	Name nvarchar(100) not null,
)