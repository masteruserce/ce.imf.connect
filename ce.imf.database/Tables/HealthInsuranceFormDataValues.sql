CREATE TABLE dbo.HealthInsuranceFormDataValues
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
CREATE INDEX IX_HealthInsuranceFormDataValues_FormId ON dbo.HealthInsuranceFormDataValues(FormId);
GO
CREATE INDEX IX_HealthInsuranceFormDataValues_SectionId ON dbo.HealthInsuranceFormDataValues(SectionId);
GO
CREATE INDEX IX_HealthInsuranceFormDataValues_FieldId ON dbo.HealthInsuranceFormDataValues(FieldId);
