create  database PHAMTHITHUTRANGDB
Use PHAMTHITHUTRANGDB
CREATE TABLE UserAccount(
    UserID char(5) NOT NULL primary key ,	
    UserName nvarchar(50) ,
    Password nvarchar(50) ,
	Status nvarchar(255) NULL    
)
DROP  table UserAccount
CREATE TABLE Category (
    CategoryID char(5) NOT NULL primary key,
    CategoryName nvarchar(255),
    Description nvarchar(255)
) 
CREATE TABLE Product(
    ProductID char(5) NOT NULL primary key ,
    CategoryID char(5)foreign key (CategoryID) references Category(CategoryID),
	ProductName nvarchar(255) ,
    UnitCost decimal(18,0) null
		Default  100000,
    Quantity int,    
	Description nvarchar(255) ,
	Status nvarchar(255),	 
)
INSERT INTO UserAccount(UserID,UserName,Password,Status) 
	VALUES ('us001','ThuTrang','12345','ADMIN'),
           ('us002','ThuTien','12345',null),
           ('us003','ThuTram','12345','ad'),
           ('us004','ad','12345',null),
           ('us005','ad1','12345','ADMIN'),
           ('us006','ad2','12345',null),
           ('us007','ad3','12345',null),
           ('us008','ad4','12345',null)
	
INSERT INTO Category(CategoryID,CategoryName,Description)
	VALUES ('LSP01','Adidas',N'Nhìu mẫu mã'),
		   ('LSP02','Puma',N'Đẹp'),
		   ('LSP03','Vans',N'Phổ biến'),
		   ('LSP04','Nike',N'Thương hiệu thế giới')
INSERT INTO Product(ProductID,CategoryID,ProductName,UnitCost,Quantity,Description,Status)
	VALUES ('SP001','LSP02','Puma Skye Stripes',default,5,N'Puma Skye Stripes có 3 màu',N'Còn'),
		   ('SP002','LSP01','Adidas Yeezy 350 V2',200000,10,N'Adidas Yeezy 350 V2 có 3 màu',N'Còn'),
		   ('SP003','LSP04','Nike Air Jordan',150000,5,N'Nike Air Jordan có 5 màu',N'Còn')
       
       