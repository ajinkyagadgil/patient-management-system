CREATE TABLE [Patient].[PatientPhoto]
(
	[Id] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY,
    [PatientId] UNIQUEIDENTIFIER NOT NULL,
	[Path] NVARCHAR(MAX) NOT NULL, 
    [Name] NVARCHAR(MAX) NOT NULL, 
    [Type] NVARCHAR(MAX) NOT NULL,
    [Size] BIGINT NOT NULL,
    [CreationDate] DATETIME2 NOT NULL DEFAULT GETUTCDATE(), 
    [FileData] VARBINARY(MAX) NOT NULL, 
    CONSTRAINT [FK_PatientPhoto_PatientInformation] FOREIGN KEY ([PatientId]) REFERENCES [Patient].[PatientInformation]([Id]), 
)
