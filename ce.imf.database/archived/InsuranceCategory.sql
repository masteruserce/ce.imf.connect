CREATE TABLE [dbo].[InsuranceCategory]
(
	CategoryId uniqueidentifier PRIMARY KEY,
    CategoryName NVARCHAR(100) NOT NULL,        -- e.g., Life, Health, Motor, General, Commercial
    Description NVARCHAR(255) NULL,
    InsuranceType NVARCHAR(100) NOT NULL,    -- e.g., Term Life, Whole Life, Health Insurance, Car Insurance    
    IsActive BIT DEFAULT 1,
    CreatdDate Datetime not null default GetDate(),
    CreatedBy Nvarchar(100) not null Default 'System'
)

