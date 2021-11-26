DECLARE @BookId1 UNIQUEIDENTIFIER = '2f1d7f29-711f-4beb-a33e-b25a4ac5f854';
DECLARE @BookId2 UNIQUEIDENTIFIER = '7060dbf2-dec8-4286-b76a-cb59f934c2cb';
DECLARE @BookId3 UNIQUEIDENTIFIER = '9929548d-6379-4e03-90dc-1870ac79e6d2';
DECLARE @BookId4 UNIQUEIDENTIFIER = '31b72538-4c01-4739-b8e2-a1f2ac93fea2';

INSERT INTO [catalog].[Books]
           ([Id]
		   ,[Title]
           ,[Author]
           ,[CategoryId]
           ,[Price]
           ,[Stock]
           ,[IsAvailableToBorrow])
     VALUES
           (@ProductId1
		   ,'Everybody Lies'
           ,'Seth Stephens-Davidowitz'
           ,3
           ,27.99
           ,10
           ,1)

INSERT INTO [catalog].[Books]
           ([Id]
		   ,[Title]
           ,[Author]
           ,[CategoryId]
           ,[Price]
           ,[Stock]
           ,[IsAvailableToBorrow])
     VALUES
           (@ProductId1
		   ,'Everybody Lies'
           ,'Seth Stephens-Davidowitz'
           ,2
           ,27.99
           ,10
           ,1)

INSERT INTO [catalog].[Books]
           ([Id]
		   ,[Title]
           ,[Author]
           ,[CategoryId]
           ,[Price]
           ,[Stock]
           ,[IsAvailableToBorrow])
     VALUES
           (@ProductId2
		   ,'Harry Potter and the Philosophers Stone'
           ,'J. K. Rowling'
           ,1
           ,30.99
           ,10
           ,1)

INSERT INTO [catalog].[Books]
           ([Id]
		   ,[Title]
           ,[Author]
           ,[CategoryId]
           ,[Price]
           ,[Stock]
           ,[IsAvailableToBorrow])
     VALUES
           (@ProductId3
		   ,'Harry Potter and the Goblet of Fire'
           ,'J. K. Rowling'
           ,1
           ,30.99
           ,10
           ,1)

INSERT INTO [catalog].[Books]
           ([Id]
		   ,[Title]
           ,[Author]
           ,[CategoryId]
           ,[Price]
           ,[Stock]
           ,[IsAvailableToBorrow])
     VALUES
           (@ProductId4
		   ,'Harry Potter and the Order of the Phoenix'
           ,'J. K. Rowling'
           ,1
           ,30.99
           ,10
           ,1)