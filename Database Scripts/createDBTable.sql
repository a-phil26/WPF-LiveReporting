-- File: createDBTable.sql
-- Project: BI-A02
-- Programmer: Addison Phillips
-- Description: This file contains the script to create the data base, tables, and indecies i used. 


CREATE DATABASE YoYo;
go
USE YoYo

CREATE TABLE YoYoData (
	id int IDENTITY(1,1) Primary Key,
	work_area nvarchar(60),
	serial_number nvarchar(60),
	production_line nvarchar(60),
	current_state nvarchar(60),
	defect_reason nvarchar(60),
	date_timestamp nvarchar(60),
	product_id nvarchar(10)
);

CREATE NONCLUSTERED INDEX [defectIdx-20240206-091534] ON [dbo].[YoYoData]
(
	[defect_reason] ASC,
	[product_id] ASC
)


-- just raw data, then have a trigger for it to format it and add it to the real database. 
CREATE TABLE RawDataDump(
	id int IDENTITY(1,1) Primary Key,
	data_string nvarchar(MAX),
	processed bit NOT NULL DEFAULT 0
);

CREATE NONCLUSTERED INDEX [NonClusteredIndex-20240206-100223] ON [dbo].[RawDataDump]
(
	[processed] ASC
)


CREATE TABLE Products (
product_id int Primary Key,
product_name nvarchar(25)
);

INSERT INTO Products values 
(1, 'Original Sleeper'),
(2, 'Black Beauty'),
(3, 'Firecracker'),
(4, 'Lemon Yellow'),
(5, 'Midnight Blue'),
(6, 'Screaming Orange'),
(7, 'Gold Glitter'),
(8, 'White Lightening')



