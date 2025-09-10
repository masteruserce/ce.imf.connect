CREATE TABLE dbo.Clients
(
    ClientId UNIQUEIDENTIFIER NOT NULL PRIMARY KEY,
    Name NVARCHAR(200) NOT NULL,
    Description NVARCHAR(500) NULL,
    LogoBase64 NVARCHAR(MAX) NULL,
    UserName NVARCHAR(100) NOT NULL,
    UserPassword NVARCHAR(200) NOT NULL, -- hashed password recommended
    Email NVARCHAR(200) NOT NULL,
    Phone NVARCHAR(50) NOT NULL,
    Address NVARCHAR(500) NOT NULL,
    City NVARCHAR(100) NOT NULL,
    State NVARCHAR(100) NOT NULL,
    Country NVARCHAR(100) NOT NULL,
    ZipCode NVARCHAR(20) NOT NULL,
    CreatedAt DATETIME2 NOT NULL DEFAULT GETDATE(),
    UpdatedAt DATETIME2 NULL
);
GO
-- Helpful indexes
CREATE INDEX IX_Clients_Email ON dbo.Clients(Email);
GO
CREATE INDEX IX_Clients_UserName ON dbo.Clients(UserName);
