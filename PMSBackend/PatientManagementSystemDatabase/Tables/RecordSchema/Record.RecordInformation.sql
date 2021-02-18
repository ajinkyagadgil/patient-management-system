CREATE TABLE [Record].[RecordInformation]
(
	[Id] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY, 
    [PatientId] UNIQUEIDENTIFIER NOT NULL, 
    [Treatment] NVARCHAR(MAX) NOT NULL,
    [Amount] INT NOT NULL,
    [RecordDate] DATETIME2 NOT NULL DEFAULT GETUTCDATE(), 
    CONSTRAINT [FK_RecordInformation_PatientInformation] FOREIGN KEY ([PatientId]) REFERENCES [Patient].[PatientInformation]([Id])

)
