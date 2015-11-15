CREATE TABLE [dbo].[Devices] (
    [Id] int IDENTITY(1,1) PRIMARY KEY, 
    [Guid]     NVARCHAR (50)  NOT NULL,
    [Name]     NVARCHAR (50)  NOT NULL,
    [PlatformId] INT  NOT NULL,
    [OsVersion] NVARCHAR(50) NULL, 
    CONSTRAINT [FK_Devices_Platform] FOREIGN KEY ([PlatformId]) REFERENCES [Platforms]([Id]),
  
);

