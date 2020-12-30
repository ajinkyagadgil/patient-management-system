CREATE TABLE [Patient].[PatientInformation]
(
	[Id] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY, 
    [Name] NVARCHAR(MAX) NOT NULL, 
    [Age] INT NOT NULL, 
    [Phone] NVARCHAR(MAX) NOT NULL, 
    [Gender] INT NOT NULL, 
    [History] NVARCHAR(MAX) NULL,
    [CaseNo] NVARCHAR(20) NULL,
    [PhotoPath] NVARCHAR(MAX) NULL
)
