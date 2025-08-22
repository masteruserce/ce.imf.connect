CREATE TABLE [dbo].[SourcingDetails] (
    Id UNIQUEIDENTIFIER NOT NULL PRIMARY KEY,
    ItemType NVARCHAR(100) NULL,
    SourceNumber NVARCHAR(50) NOT NULL UNIQUE,  -- Unique identifier for sourcing
    Fy NVARCHAR(20) NOT NULL,                      -- e.g., "2024-25"
    [Year] INT NOT NULL,                           -- e.g., 2025
    LoginMonth NVARCHAR(20) NOT NULL,              -- e.g., "July"
    PremiumMonth NVARCHAR(20) NOT NULL,            -- e.g., "August"
    Location NVARCHAR(100) NOT NULL,               -- e.g., "Mumbai"
    Department NVARCHAR(100) NOT NULL,             -- e.g., "Sales"
    InsuranceHead NVARCHAR(150) NOT NULL,          -- Name of Insurance Head
    BusinessHead NVARCHAR(150) NOT NULL,           -- Name of Business Head
    Presentator NVARCHAR(150) NOT NULL,            -- Name of person presenting the case
    BusinessPartner NVARCHAR(150) NOT NULL,        -- Partner company/person
    InsuranceCategory NVARCHAR(50) NOT NULL,       -- Life / Health / General
    FreshRenewal NVARCHAR(50) NOT NULL,            -- Fresh / Renewal
    PrincipalCo NVARCHAR(150) NOT NULL,            -- Name of principal company
    PlanType NVARCHAR(50) NOT NULL,                -- ULIP / Non-ULIP / Term
    EmpCode NVARCHAR(50) NOT NULL,                 -- Alphanumeric employee code
    ApplicationNo NVARCHAR(50) NOT NULL,            -- Application reference number
    CreatedDate DATETIME2 NOT NULL DEFAULT GETDATE(),
    CreatedBy NVARCHAR(100) NULL,
    UpdatedDate DATETIME2 NULL DEFAULT GETDATE(),
    UpdatedBy NVARCHAR(100) NULL,
    IsActive BIT NOT NULL,
    CONSTRAINT UQ_SourcingDetails_ApplicationNo UNIQUE (ApplicationNo)
);
