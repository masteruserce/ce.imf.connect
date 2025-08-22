CREATE TABLE [dbo].[OtherAmountDetails] (
    Id UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWID(),
    ApplicationNo NVARCHAR(50) NOT NULL,
    SourcingId UNIQUEIDENTIFIER NOT NULL,
    OrcCommAmt DECIMAL(18,2) NULL,
    TdsAmt DECIMAL(18,2) NULL,
    AmountClaimed DECIMAL(18,2) NULL,
    AmountReceived DECIMAL(18,2) NULL,
    OrcPending DECIMAL(18,2) NULL,
    ApartBcOrcComm DECIMAL(18,2) NULL,
    TotalPending DECIMAL(18,2) NULL,
    CreatedDate DATETIME2 NOT NULL DEFAULT SYSDATETIME(),
    CreatedBy UNIQUEIDENTIFIER NOT NULL,
    UpdatedDate DATETIME2 NULL,
    UpdatedBy UNIQUEIDENTIFIER NULL,
    CONSTRAINT FK_OtherAmountDetails_Sourcing FOREIGN KEY (SourcingId) REFERENCES SourcingDetails(Id),
    CONSTRAINT FK_OtherAmountDetails_ApplicationNo FOREIGN KEY (ApplicationNo) REFERENCES SourcingDetails(ApplicationNo)
);