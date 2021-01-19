CREATE TABLE [Treatment].[TreatmentFiles]
(
	[Id] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY,
    [TreatmentId] UNIQUEIDENTIFIER NOT NULL,
    [Path] NVARCHAR(MAX) NOT NULL, 
    [Name] NVARCHAR(MAX) NOT NULL, 
    [Type] NVARCHAR(MAX) NOT NULL,
    [Size] BIGINT NOT NULL,
    [CreationDate] DATETIME2 NOT NULL DEFAULT GETUTCDATE(), 
    [FileData] VARBINARY(MAX) NOT NULL, 
    CONSTRAINT [FK_TreatmentFiles_Treatment] FOREIGN KEY ([TreatmentId]) REFERENCES [Treatment].[TreatmentInformation]([Id]),
)
