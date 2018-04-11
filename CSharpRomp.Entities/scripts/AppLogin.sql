CREATE TABLE [dbo].[AppLogin]
(
	[id] INT NOT NULL IDENTITY PRIMARY KEY, 
    [username] NCHAR(100) NULL, 
    [password] NCHAR(100) NULL 
)
