CREATE TABLE [dbo].[InsuranceProduct] (
    Id UNIQUEIDENTIFIER NOT NULL PRIMARY KEY, -- PK
    Name NVARCHAR(200) NOT NULL,              -- Product name
    Manufacturer NVARCHAR(200) NOT NULL,      -- Manufacturer/Insurer
    Term NVARCHAR(50) NOT NULL,               -- e.g., 10 years / 20 years
    PaymentTerm NVARCHAR(50) NOT NULL,        -- e.g., 5 years / 10 years
    PaymentMode NVARCHAR(50) NOT NULL,        -- e.g., Monthly, Yearly
    CreatedDate DATETIME2 NOT NULL DEFAULT GETDATE(),
    UpdatedDate DATETIME2 NULL,
    CreatedBy NVARCHAR(100) NULL,
    UpdatedBy NVARCHAR(100) NULL,
    IsActive BIT NOT NULL DEFAULT 1           -- Active flag
);
