CREATE TABLE dbo.FieldConfigs (
    Id UNIQUEIDENTIFIER NOT NULL PRIMARY KEY DEFAULT NEWID(),
    ClientId UNIQUEIDENTIFIER NULL,
    SectionId UNIQUEIDENTIFIER NOT NULL,
    FieldName NVARCHAR(200) NOT NULL,
    FieldOrder INT NOT NULL DEFAULT 0,
    Type NVARCHAR(50) NOT NULL DEFAULT 'text',
    Label NVARCHAR(200) NULL,
    Placeholder NVARCHAR(500) NULL,
    Options NVARCHAR(MAX) NULL, -- CSV or JSON array
    Required BIT NOT NULL DEFAULT 0,
    ValidationMessage NVARCHAR(MAX) NULL,
    DefaultValue NVARCHAR(MAX) NULL,
    CreatedAt DATETIME2 NOT NULL DEFAULT GETDATE(),
    CONSTRAINT FK_FieldConfigs_Section FOREIGN KEY (SectionId) REFERENCES dbo.Sections(Id),
    CONSTRAINT FK_FieldConfigs_Client FOREIGN KEY (ClientId) REFERENCES dbo.Clients(ClientId)
);
GO

-- Indexes
CREATE INDEX IX_Forms_ClientId ON dbo.Forms(ClientId);
GO
CREATE INDEX IX_Sections_FormId ON dbo.Sections(FormId);
GO
CREATE INDEX IX_Sections_ClientId ON dbo.Sections(ClientId);
GO
CREATE INDEX IX_FieldConfigs_SectionId ON dbo.FieldConfigs(SectionId);
GO
CREATE INDEX IX_FieldConfigs_ClientId ON dbo.FieldConfigs(ClientId);
GO
CREATE INDEX IX_FieldConfigs_FieldName ON dbo.FieldConfigs(FieldName);
GO