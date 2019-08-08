CREATE TABLE [dbo].[Person]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [FirstName] NVARCHAR(50) NOT NULL, 
    [LastName] NVARCHAR(50) NOT NULL, 
    [FamilyId] INT NULL, 
    [Adress] NVARCHAR(50) NULL, 
    [PresentId] INT NULL, 
    CONSTRAINT [FK_Person_Present] FOREIGN KEY ([PresentId]) REFERENCES [Present]([Id])
)
