﻿IF NOT EXISTS (SELECT * FROM sys.schemas WHERE name = 'order')
BEGIN
	EXEC('CREATE SCHEMA [order]')
END
GO


IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'Order' AND TABLE_SCHEMA = 'order')
BEGIN
	CREATE TABLE [order].[Order](
			[Id]			UNIQUEIDENTIFIER	NOT NULL CONSTRAINT [DF_Order_Id] DEFAULT (NEWSEQUENTIALID()),
			[CustomerId]	UNIQUEIDENTIFIER	NOT NULL,
			[OrderDateUtc]			DATETIME2(7)	NOT NULL,
			[UserName]			int		NOT NULL,
			[Price]            decimal(18,2) NOT NULL,
			[StreetName] NVARCHAR(50) NOT NULL,
			[StreetNumber] NVARCHAR(50) NOT NULL,
			[City] NVARCHAR(50) NOT NULL,
	 CONSTRAINT [PK_Order] PRIMARY KEY CLUSTERED ([Id] ASC)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
	) ON [PRIMARY]
END

IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'Item' AND TABLE_SCHEMA = 'order')
BEGIN
	CREATE TABLE [order].[Item](
			[Id]			UNIQUEIDENTIFIER	NOT NULL CONSTRAINT [DF_Item_Id] DEFAULT (NEWSEQUENTIALID()),
			[OrderId]			UNIQUEIDENTIFIER	NOT NULL,
			[ProductId]			UNIQUEIDENTIFIER	NOT NULL,
			[Name] NVARCHAR(50) NOT NULL,
			[Price]			decimal(10,2)		NOT NULL,
			[Quantity]			int					NOT NULL,
	 CONSTRAINT [PK_Item] PRIMARY KEY CLUSTERED ([Id] ASC)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
	) ON [PRIMARY]
	ALTER TABLE [order].[Item]
	ADD CONSTRAINT [Item_OrderId_FK] FOREIGN KEY ( OrderId ) REFERENCES [Order](Id)
END

