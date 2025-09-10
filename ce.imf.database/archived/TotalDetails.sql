CREATE TABLE [dbo].[TotalDetails] (
    Id UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWID(),
    ApplicationNo NVARCHAR(50) NOT NULL,
    SourcingId UNIQUEIDENTIFIER NOT NULL,
    TotalReceivable DECIMAL(18,2) NULL,
    TotalReceived DECIMAL(18,2) NULL,
    PendingTotal DECIMAL(18,2) NULL,
    CreatedDate DATETIME2 NOT NULL DEFAULT SYSDATETIME(),
    CreatedBy UNIQUEIDENTIFIER NOT NULL,
    UpdatedDate DATETIME2 NULL,
    UpdatedBy UNIQUEIDENTIFIER NULL,
    CONSTRAINT FK_TotalDetails_Sourcing FOREIGN KEY (SourcingId) REFERENCES SourcingDetails(Id),
    CONSTRAINT FK_TotalDetails_ApplicationNo FOREIGN KEY (ApplicationNo) REFERENCES SourcingDetails(ApplicationNo)
);