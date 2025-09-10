CREATE TABLE [dbo].[RevenueDetails] (
    Id UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWID(),
    ApplicationNo NVARCHAR(50) NOT NULL,
    SourcingId UNIQUEIDENTIFIER NOT NULL,
    TotalRevenuePercent DECIMAL(5,2) NULL,
    BasePercent DECIMAL(5,2) NULL,
    PcPercent DECIMAL(5,2) NULL,
    Bc50Percent DECIMAL(5,2) NULL,
    OrcPercent DECIMAL(5,2) NULL,
    ContestPercent DECIMAL(5,2) NULL,
    PliPercent DECIMAL(5,2) NULL,
    CreatedDate DATETIME2 NOT NULL DEFAULT SYSDATETIME(),
    CreatedBy UNIQUEIDENTIFIER NOT NULL,
    UpdatedDate DATETIME2 NULL,
    UpdatedBy UNIQUEIDENTIFIER NULL,
    CONSTRAINT FK_RevenueDetails_Sourcing FOREIGN KEY (SourcingId) REFERENCES SourcingDetails(Id),
    CONSTRAINT FK_RevenueDetails_ApplicationNo FOREIGN KEY (ApplicationNo) REFERENCES SourcingDetails(ApplicationNo)
);