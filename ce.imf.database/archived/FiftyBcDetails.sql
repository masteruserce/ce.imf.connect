CREATE TABLE [dbo].[FiftyBcDetails] (
    Id UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWID(),
    ApplicationNo NVARCHAR(50) NOT NULL,
    SourcingId UNIQUEIDENTIFIER NOT NULL,
    FiftyBcPcAmt DECIMAL(18,2) NULL,
    TdsAmount DECIMAL(18,2) NULL,
    AmountClaimed DECIMAL(18,2) NULL,
    AmountReceived DECIMAL(18,2) NULL,
    FiftyBcPcPending DECIMAL(18,2) NULL,
    CreatedDate DATETIME2 NOT NULL DEFAULT SYSDATETIME(),
    CreatedBy UNIQUEIDENTIFIER NOT NULL,
    UpdatedDate DATETIME2 NULL,
    UpdatedBy UNIQUEIDENTIFIER NULL,
    CONSTRAINT FK_FiftyBcDetails_Sourcing FOREIGN KEY (SourcingId) REFERENCES SourcingDetails(Id),
    CONSTRAINT FK_FiftyBcDetails_ApplicationNo FOREIGN KEY (ApplicationNo) REFERENCES SourcingDetails(ApplicationNo)
);
