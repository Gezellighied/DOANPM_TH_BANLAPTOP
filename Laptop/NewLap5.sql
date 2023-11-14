use Laptop5
go

drop table Orders

CREATE TABLE Orders (
    OrderID INT identity (1, 1) PRIMARY KEY,
    CustomerID INT,
	RecipientName nvarchar(30),
	Phone nvarchar (30),
	AddressDeliverry nvarchar(max) not null,
	Total int not null,
	Status nvarchar(max)
    FOREIGN KEY (CustomerID) REFERENCES Customer(CustomerID),
)