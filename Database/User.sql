CREATE TABLE [dbo].[User]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [Created] DATETIMEOFFSET NULL, 
    [LastUpdate] DATETIMEOFFSET NULL, 
    [Erased] INT NULL, 
    [Name] NVARCHAR(50) NULL, 
    [Sirname] NVARCHAR(50) NULL, 
    [Email] NVARCHAR(50) NULL, 
    [PhoneNumber] NVARCHAR(50) NULL, 
    [Username] NVARCHAR(50) NOT NULL, 
    [Password] NVARCHAR(50) NOT NULL, 
    [AccessRole] INT NULL, 
    CONSTRAINT [AK_User_Email] UNIQUE ([Email]),
    CONSTRAINT [AK_User_Username] UNIQUE ([Username])
)
