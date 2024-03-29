﻿IF NOT EXISTS (SELECT * FROM sys.schemas WHERE name = 'catalog')
BEGIN
	EXEC('CREATE SCHEMA [catalog]')
END
GO


IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'Books' AND TABLE_SCHEMA = 'catalog')
BEGIN
	CREATE TABLE [catalog].[Books](
			[Id]			      UNIQUEIDENTIFIER	NOT NULL CONSTRAINT [DF_Product_Id] DEFAULT (NEWSEQUENTIALID()),
			[Title]	              NVARCHAR(120)		NOT NULL,
			[Author]              NVARCHAR(50)		NOT NULL,
			[CategoryId]          int               NOT NULL,
			[Price]			      decimal(10,2)		NOT NULL,
			[Stock]			      int		        NOT NULL,
			[AvailableToBorrow] int               NOT NULL,
	 CONSTRAINT [PK_Books] PRIMARY KEY CLUSTERED ([Id] ASC)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
	) ON [PRIMARY]
END

IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'Category' AND TABLE_SCHEMA = 'catalog')
BEGIN
	CREATE TABLE [catalog].[Category](
			[Id]			      UNIQUEIDENTIFIER	NOT NULL CONSTRAINT [DF_Product_Id] DEFAULT (NEWSEQUENTIALID()),
			[Name]	              NVARCHAR(20)		NOT NULL,
	 CONSTRAINT [PK_Books] PRIMARY KEY CLUSTERED ([Id] ASC)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
	) ON [PRIMARY]
END
