﻿--USE master
--drop DATABASE RICE_MANAGEMENT

--CREATE DATABASE RICE_MANAGEMENT
--GO
---USE RICE_MANAGEMENT

--DROP DATABASE RICE_MANAGEMENT

CREATE TABLE ROLE
(
	ROLEID INT IDENTITY(1,1) PRIMARY KEY,
	ROLENAME NVARCHAR(200)
)

CREATE TABLE ACCOUNT
(
	USERNAME VARCHAR(50) PRIMARY KEY,
	PASSWORD VARCHAR(50),
)

CREATE TABLE ROLE_ACCOUNT
(
	USERNAME VARCHAR(50) REFERENCES ACCOUNT(USERNAME),
	ROLEID INT REFERENCES ROLE(ROLEID),
	PRIMARY KEY(USERNAME,ROLEID)
)
 
CREATE TABLE CUSTOMER	
(
	CUSTOMERID INT IDENTITY(1,1) PRIMARY KEY,
	USERNAME VARCHAR(50) REFERENCES ACCOUNT(USERNAME),
	EMAIL VARCHAR(50), 
	PHONE VARCHAR(12),
	COMPANY_NAME NVARCHAR(200),
	LOCATION NVARCHAR(200)
)

CREATE TABLE PRODUCT_TYPE
(
	TYPEID VARCHAR(50) PRIMARY KEY,
	TYPENAME NVARCHAR(200)
)

CREATE TABLE PRODUCT
(
	PRODUCTID INT IDENTITY(1,1) PRIMARY KEY,
	PRODUCT_NAME NVARCHAR(100),
	QUANTITY INT,
	PRICE INT,
	BRAND NVARCHAR(100),
	WEIGHT INT,
	COUNTRY NVARCHAR(100),
	IMG_PATH VARCHAR(200)
)

CREATE TABLE PRODUCT_PTYPE
(
	PRODUCTID INT REFERENCES PRODUCT(PRODUCTID),
	TYPEID VARCHAR(50) REFERENCES PRODUCT_TYPE(TYPEID),
	PRIMARY KEY(PRODUCTID, TYPEID)
)


CREATE TABLE STAFF
(
	STAFFID INT IDENTITY(1,1) PRIMARY KEY,
	USERNAME VARCHAR(50) REFERENCES ACCOUNT(USERNAME), 
	FULLNAME NVARCHAR(200),
	PHONE VARCHAR(12),
)


CREATE TABLE BILL_TYPE
(
	TYPEID INT IDENTITY(1,1) PRIMARY KEY,
	TYPE_NAME NVARCHAR(100)
)

CREATE TABLE BILL
(
	BILLID INT IDENTITY(1,1) PRIMARY KEY,
	CUSTOMERID INT REFERENCES CUSTOMER(CUSTOMERID),
	STATUS NVARCHAR(100) DEFAULT 'UNPAID',
	DATE_CREATED DATE,
	DATE_CLOSED DATE,
	PAYMENT_METHOD NVARCHAR(100),
	TYPEID INT REFERENCES BILL_TYPE(TYPEID)

	--DISCOUNTID VARCHAR(20) REFERENCES DISCOUNT(DISCOUNTID),
)

CREATE TABLE BILL_PRODUCTS
(
	BILLID INT REFERENCES BILL(BILLID),
	PRODUCTID INT REFERENCES PRODUCT(PRODUCTID),
	PRICE INT,
	QUANTITY INT,
	PRIMARY KEY(BILLID,PRODUCTID)
)

CREATE TABLE CART
(
	USERNAME VARCHAR(50) REFERENCES ACCOUNT(USERNAME),
	PRODUCTID INT REFERENCES PRODUCT(PRODUCTID),
	QUANTITY INT,
	PRIMARY KEY(USERNAME,PRODUCTID)
)


--CREATE TABLE DISCOUNT
--(
--	DISCOUNTID VARCHAR(20) PRIMARY KEY,
--	QUANTITY INT,
--	DATE_CREATED DATE DEFAULT GETDATE(),
--	DATE_EXPIRED DATE DEFAULT NULL
--)

--SELECT * FROM PRODUCT_PTYPE


INSERT INTO ROLE VALUES ('Admin'),('Customer'),('Accountant')
INSERT INTO ACCOUNT VALUES ('admin','123456'), ('staff','123456'), ('demo','123456'), ('demo1','111111')
INSERT INTO ROLE_ACCOUNT VALUES ('admin',1),('staff',3), ('demo',2), ('demo1',2)
INSERT INTO CUSTOMER VALUES ('demo','de1@gmail.com','0909123123','Heaven Corp','10 CMT8 P.6 Q.3, TP.HCM'),
('demo1','xuanmike123@gmail.com','0909987987','Xuan Mike Corp','27 Truong Chinh, P.14, Q. Tan Binh, TP.HCM')

INSERT INTO STAFF VALUES ('admin','Administrator','079980980'),
('staff','Phuong My Chi','0123555444')

INSERT INTO PRODUCT_TYPE VALUES ('thom',N'Gạo thơm'),('deo',N'Gạo dẻo'),('tam',N'Gạo tấm'),('luc',N'Gạo lức'),('nep',N'Gạo nếp')

INSERT INTO PRODUCT VALUES (N'Gạo tám thơm 20kg',241,450000,'Vinarice',20,'Vietnam','https://th.bing.com/th/id/R.93b14bfa573310f775c01cfe6d81ffd4?rik=sBHPJoCfiPaZ%2fA&pid=ImgRaw&r=0'),
(N'Gạo thơm lài 15kg',132,275000,'Vinarice',13,'Vietnam','https://cdn.tgdd.vn/Products/Images/2513/230183/bhx/gao-hoa-lua-vang-tui-2kg-202103040805536182_300x300.jpg'),
(N'Gạo lức loại I 5kg',140,105000,'GrandmaRice',5,'Vietnam','https://cdn.tgdd.vn/Products/Images/2513/182765/bhx/gao-thom-vua-gao-huong-viet-tui-5kg-202105041532553509_300x300.jpeg'),
(N'Gạo tấm dẻo 20kg',65,310000,'AdaptX',20,'Vietnam','https://cdn.tgdd.vn/Products/Images/2513/234580/bhx/gao-no-xop-504-bach-hoa-xanh-tui-2kg-202101232024527630_300x300.jpg'),
(N'Gạo nếp loại I 5kg',105,60000,'AdaptX',5,'Vietnam','https://cdn.tgdd.vn/Products/Images/3361/161262/bhx/banh-gao-vi-ngot-richy-goi-315g-202104212209454824_300x300.jpg'),
(N'Gạo dẻo Cửu Long 15kg',84,400000,'RiceEco',15,'Vietnam','https://cdn.tgdd.vn/Products/Images/3361/161262/bhx/banh-gao-vi-ngot-richy-goi-315g-202104212209454824_300x300.jpg'),
(N'Gạo nếp loại II 5kg',213,85000,'GrandmaRice',5,'Vietnam','https://cdn.tgdd.vn/Products/Images/5231/157934/bhx/gao-muc-nuoc-nhua-duy-tan-873-giao-mau-ngau-nhien-202103031055502229_300x300.jpg'),
(N'Gạo thơm Thái 20kg',225,520000,'ThaiRice',20,'Thailand','https://cdn.tgdd.vn/Products/Images/2513/232810/bhx/gao-lut-home-rice-tui-2kg-202103040827108785_300x300.jpg')

INSERT INTO PRODUCT_PTYPE VALUES (1,'thom'),(2,'thom'),(4,'tam'),(4,'deo'),(3,'luc'),(5,'nep'),(6,'deo'),(7,'nep'),(8,'thom')

INSERT INTO BILL_TYPE VALUES ('Import'),('Export')

INSERT INTO BILL VALUES (1,'Pending',GETDATE(),NULL, 'COD',2),
(NULL,NULL,GETDATE(),GETDATE(), NULL,1)

INSERT INTO BILL_PRODUCTS VALUES (1,1,450000,43),
(1,2,275000,25),
(2,3,105000,60),
(2,4,310000,30)

select * from ACCOUNT