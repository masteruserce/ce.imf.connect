CREATE TABLE Customer (
    Id UNIQUEIDENTIFIER NOT NULL PRIMARY KEY,
    
    -- BaseModel fields
    CustomerNumber NVARCHAR(50) NOT NULL UNIQUE,
    ItemType NVARCHAR(100) NULL,
    CreatedDate DATETIME2 NOT NULL DEFAULT GETDATE(),
    UpdatedDate DATETIME2 NULL DEFAULT GETDATE(),
    CreatedBy NVARCHAR(100) NULL,
    UpdatedBy NVARCHAR(100) NULL,
    IsActive BIT NOT NULL,

    -- Proposer Details
    Proposer NVARCHAR(150) NOT NULL,
    ProposerDob DATE NOT NULL,
    ProposerPan NVARCHAR(20) NOT NULL,
    ProposerAadhar NVARCHAR(20) NOT NULL,
    ProposerGender NVARCHAR(10) NOT NULL,
    -- Contact Details
    ProposerPhone NVARCHAR(20) NOT NULL,
    ProposerEmail NVARCHAR(100) NOT NULL,
    ProposerAddress NVARCHAR(500) NOT NULL,
    ProposerDistrict NVARCHAR(100) NOT NULL,
    ProposerPincode NVARCHAR(10) NOT NULL,
    ProposerState NVARCHAR(100) NOT NULL,

    -- Life Assured Details
    LifeAssured NVARCHAR(150) NOT NULL,
    LifeAssuredDob DATE NOT NULL,
    LifeAssuredPan NVARCHAR(20) NOT NULL,
    LifeAssuredAadhar NVARCHAR(20) NOT NULL,
    LifeAssuredGender NVARCHAR(10) NOT NULL,

    LifeAssuredPhone NVARCHAR(20) NOT NULL,
    LifeAssuredEmail NVARCHAR(100) NOT NULL,
    LifeAssuredAddress NVARCHAR(500) NOT NULL,
    LifeAssuredDistrict NVARCHAR(100) NOT NULL,
    LifeAssuredPincode NVARCHAR(10) NOT NULL,
    LifeAssuredState NVARCHAR(100) NOT NULL,

        -- Nominee Details
    Nominee NVARCHAR(150) NULL,
    NomineeDob DATE NULL,
    NomineePan NVARCHAR(20) NULL,
    NomineeAadhar NVARCHAR(20) NULL,
    NomineeGender NVARCHAR(10) NOT NULL,
    
    NomineePhone NVARCHAR(20)  NULL,
    NomineeEmail NVARCHAR(100)  NULL,
    NomineeAddress NVARCHAR(500) NOT NULL,
    NomineeDistrict NVARCHAR(100) NOT NULL,
    NomineePincode NVARCHAR(10) NOT NULL,
    NomineeState NVARCHAR(100) NOT NULL,

        -- Appointee Assured Details
    Appointee NVARCHAR(150)  NULL,
    AppointeeDob DATE  NULL,
    AppointeePan NVARCHAR(20)  NULL,
    AppointeeAadhar NVARCHAR(20)  NULL,
    AppointeeGender NVARCHAR(10) NOT NULL,
    
    AppointeePhone NVARCHAR(20)  NULL,
    AppointeeEmail NVARCHAR(100)  NULL,
    AppointeeAddress NVARCHAR(500)  NULL,
    AppointeeDistrict NVARCHAR(100)  NULL,
    AppointeePincode NVARCHAR(10)  NULL,
    AppointeeState NVARCHAR(100)  NULL,

    CustomerType varchar(50)  NULL
);
