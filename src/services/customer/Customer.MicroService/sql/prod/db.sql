USE master
GO
DROP DATABASE IF EXISTS CustomerDB
GO

CREATE DATABASE CustomerDB
GO 
USE CustomerDB
GO 

----------------------------------------------------------------------------
--- TABLE CREATION
----------------------------------------------------------------------------
PRINT 'Executing SQL script in PROD...'

SET NOCOUNT ON
GO

set quoted_identifier on
GO

if exists (select * from sysobjects where id = object_id('dbo.Customers') and sysstat & 0xf = 3)
	drop table "dbo"."Customers"
GO


CREATE TABLE "Customers" (
	"Id" int,
	"CompanyName" nvarchar (40) NOT NULL ,
	"ContactName" nvarchar (30) NULL ,
	"ContactTitle" nvarchar (30) NULL ,
	"Address" nvarchar (60) NULL ,
	"City" nvarchar (15) NULL ,
	"Region" nvarchar (15) NULL ,
	"PostalCode" nvarchar (10) NULL ,
	"Country" nvarchar (15) NULL ,
	"Phone" nvarchar (24) NULL ,
	"Fax" nvarchar (24) NULL ,
	CONSTRAINT "PK_Customers" PRIMARY KEY  CLUSTERED 
	(
		"Id"
	)
)
GO
 CREATE  INDEX "City" ON "dbo"."Customers"("City")
GO
 CREATE  INDEX "CompanyName" ON "dbo"."Customers"("CompanyName")
GO
 CREATE  INDEX "PostalCode" ON "dbo"."Customers"("PostalCode")
GO
 CREATE  INDEX "Region" ON "dbo"."Customers"("Region")
GO

set quoted_identifier on
go
ALTER TABLE "Customers" NOCHECK CONSTRAINT ALL
go
INSERT INTO dbo.Customers(Id, CompanyName, ContactName, ContactTitle, Address, City, Region, PostalCode, Country, Phone, Fax) VALUES(1, 'Alfreds Futterkiste','Maria Anders','Sales Representative','Obere Str. 57','Berlin',NULL,'12209','Germany','030-0074321','030-0076545')
INSERT INTO dbo.Customers(Id, CompanyName, ContactName, ContactTitle, Address, City, Region, PostalCode, Country, Phone, Fax) VALUES(91, 'Wolski  Zajazd','Zbyszek Piestrzeniewicz','Owner','ul. Filtrowa 68','Warszawa',NULL,'01-012','Poland','(26) 642-7012','(26) 642-7012')

ALTER TABLE "Customers" CHECK CONSTRAINT ALL
go
set quoted_identifier on
go

PRINT 'SQL script execution completed.'

-- ----------------------------------------------------------------------------
-- --- DB USER CREATION
-- ----------------------------------------------------------------------------
-- USE master;
-- GO
-- CREATE LOGIN [microshop_dbuser] WITH PASSWORD=N'Sql1nContainersR0cks!', CHECK_EXPIRATION=OFF, CHECK_POLICY=ON;
-- GO
-- USE MicroshopCustomerDb;
-- GO
-- CREATE USER [microshop_dbuser] FOR LOGIN [microshop_dbuser];
-- GO
-- EXEC sp_addrolemember N'db_owner', [microshop_dbuser];
-- GO
