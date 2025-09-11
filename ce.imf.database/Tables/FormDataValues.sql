CREATE TABLE dbo.FormDataValues
(
    Id UNIQUEIDENTIFIER NOT NULL PRIMARY KEY DEFAULT NEWID(),
    ClientId UNIQUEIDENTIFIER NULL,        -- FK to Clients
    FormId UNIQUEIDENTIFIER NOT NULL,      -- FK to Forms
    SectionId UNIQUEIDENTIFIER NOT NULL,   -- FK to Sections
    FieldId UNIQUEIDENTIFIER NOT NULL,     -- FK to FieldConfig
    DataValue NVARCHAR(MAX) NULL,          -- value submitted
    Active BIT NOT NULL DEFAULT 1,         -- soft delete flag
    CreatedAt DATETIME2 NOT NULL DEFAULT SYSUTCDATETIME(),
    UpdatedAt DATETIME2 NULL
);
GO
CREATE INDEX IX_FormDataValues_FormId ON dbo.FormDataValues(FormId);
GO
CREATE INDEX IX_FormDataValues_SectionId ON dbo.FormDataValues(SectionId);
GO
CREATE INDEX IX_FormDataValues_FieldId ON dbo.FormDataValues(FieldId);
