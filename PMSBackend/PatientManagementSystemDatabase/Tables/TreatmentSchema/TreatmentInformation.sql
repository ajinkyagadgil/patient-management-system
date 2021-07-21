CREATE TABLE [Treatment].[TreatmentInformation]
(
	[Id] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY,
    [PatientId] UNIQUEIDENTIFIER NOT NULL,
    [Title] NVARCHAR(MAX) NOT NULL, 
    [Summary] NVARCHAR(MAX) NULL, 
    [Date] DATETIME2 NOT NULL, 
    CONSTRAINT [FK_TreatmentInformation_PatientInformation] FOREIGN KEY ([PatientId]) REFERENCES [Patient].PatientInformation([Id])
)
