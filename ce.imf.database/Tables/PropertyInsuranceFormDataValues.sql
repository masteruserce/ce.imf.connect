CREATE TABLE dbo.PropertyInsuranceFormDataValues
(
    Id UNIQUEIDENTIFIER NOT NULL PRIMARY KEY DEFAULT NEWID(),
    TransactionId NVARCHAR(100) NOT NULL,
    ClientId UNIQUEIDENTIFIER NULL,        -- FK to Clients
    FormId UNIQUEIDENTIFIER NOT NULL,      -- FK to Forms
    SectionId UNIQUEIDENTIFIER NOT NULL,   -- FK to Sections
    FieldId UNIQUEIDENTIFIER NOT NULL,     -- FK to FieldConfig
    DataValue NVARCHAR(MAX) NULL,          -- value submitted
    Active BIT NOT NULL DEFAULT 1,         -- soft delete flag
    IsDraft BIT NOT NULL DEFAULT 1,      -- indicates if the value is part of a draft
    CreatedAt DATETIME2 NOT NULL DEFAULT SYSUTCDATETIME(),
    UpdatedAt DATETIME2 NULL,
    CreatedBy nvarchar(50) NOT NULL,
    UpdatedBy nvarchar(50) NULL
);
GO
CREATE INDEX IX_PropertyInsuranceFormDataValues_FormId ON dbo.PropertyInsuranceFormDataValues(FormId);
GO
CREATE INDEX IX_PropertyInsuranceFormDataValues_SectionId ON dbo.PropertyInsuranceFormDataValues(SectionId);
GO
CREATE INDEX IX_PropertyInsuranceFormDataValues_FieldId ON dbo.PropertyInsuranceFormDataValues(FieldId);
