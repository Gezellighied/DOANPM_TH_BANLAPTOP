	CREATE TABLE Laptops (
    LaptopID INT identity (1, 1) PRIMARY KEY ,
	LaptopName Nvarchar (50) not null,
    Brand NVARCHAR(50) NOT NULL,
    ScreenSize NVARCHAR(400) NOT NULL,
    Processor NVARCHAR(400) NOT NULL,
    RAM NVARCHAR (400) NOT NULL,
    Price int NOT NULL,
	Image NVARCHAR (100) NOT NULL
)

Create table Brand
(
	BrandID int identity (1, 1) primary key,
	Name nvarchar(100) not null,
)

CREATE TABLE Orders (
    OrderID INT PRIMARY KEY,
    CustomerID INT,
    LaptopID INT,
    FOREIGN KEY (CustomerID) REFERENCES AccountCustomer(CustomerID),
    FOREIGN KEY (LaptopID) REFERENCES Laptops(LaptopID)
)

Create table Carts
(
	CartID int identity (1, 1) primary key,
	CustomerID int constraint FK_Cart_AccountCustomer foreign key references AccountCustomer(CustomerID),
	LaptopID int constraint FK_Cart_Laptops foreign key references Laptops(LaptopID),
	SoLuong int,
	Tensp nvarchar(50),
	DonGia decimal(18,0),
	ThanhTien decimal(18,2),
	Image nvarchar(550),
)
go



CREATE TABLE AccountCustomer (
    CustomerID INT PRIMARY KEY,
    Name NVARCHAR(255),
    Email NVARCHAR(255),
    Password NVARCHAR(255),
	Role int,
);

Create Table AdminUser(
	AdminUserID int identity (1, 1) Primary key,
	Name NVARCHAR(255),
    Email NVARCHAR(255),
    Password NVARCHAR(255),
)

Insert Into Laptops (LaptopName,Brand,ScreenSize,Processor,RAM,Price,Image)
Values
	(N'Laptop Acer Aspire 3 A315 59 321N',	N'Acer',N'15.6 FHD (1920 x 1080), 60Hz, Acer ComfyView LED-backlit TFT LCD',N'Intel® Core™ i3-1215U, upto 4.40GHz, 10 MB Intel® Smart Cache',N'8GB (1 x 8GB) DDR4 2400MHz (2x SO-DIMM socket, up to 32GB SDRAM)','11990000','acernitro.jpg'),
	(N'Laptop Acer Aspire 5 A514 56P 55K5',	N'Acer',N'14" WUXGA (1920 x 1200), IPS SlimBezel, 60Hz, Acer ComfyView™',	N'Intel® Core™ i5-1335U 1.3GHz up to 4.6GHz 12MB',	N'16GB LPDDR5 4800MHz (không nâng cấp)',	'20000000','acernitro.jpg');