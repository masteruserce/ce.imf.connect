CREATE TABLE [dbo].[FinalDetails] (
    Id UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWID(),
    ApplicationNo NVARCHAR(50) NOT NULL,
    SourcingId UNIQUEIDENTIFIER NOT NULL,
    TotalCommAmt DECIMAL(18,2) NULL,
    TotalCommissionReceived DECIMAL(18,2) NULL,
    BaseCommAmt DECIMAL(18,2) NULL,
    TdsAmount DECIMAL(18,2) NULL,
    AmtClaimed DECIMAL(18,2) NULL,
    AmtReceived DECIMAL(18,2) NULL,
    BasePending DECIMAL(18,2) NULL,
    CreatedDate DATETIME2 NOT NULL DEFAULT SYSDATETIME(),
    CreatedBy UNIQUEIDENTIFIER NOT NULL,
    UpdatedDate DATETIME2 NULL,
    UpdatedBy UNIQUEIDENTIFIER NULL,
    CONSTRAINT FK_FinalDetails_Sourcing FOREIGN KEY (SourcingId) REFERENCES SourcingDetails(Id),
    CONSTRAINT FK_FinalDetails_ApplicationNo FOREIGN KEY (ApplicationNo) REFERENCES SourcingDetails(ApplicationNo)
);
