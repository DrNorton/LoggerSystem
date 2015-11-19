CREATE TABLE [dbo].[Registrations]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY(1,1), 
    [ProjectId] INT NOT NULL, 
    [DeviceId] INT NULL, 
	
    [RegistrationTime] DATETIME NULL,
	 
    [AssemblyVersion] NVARCHAR(20) NULL, 
    CONSTRAINT [FK_Registrations_ToPrjects] FOREIGN KEY ([ProjectId]) REFERENCES [Projects]([Id]),
	CONSTRAINT [FK_Registrations_ToDevices] FOREIGN KEY ([DeviceId]) REFERENCES [Devices]([Id])

)
