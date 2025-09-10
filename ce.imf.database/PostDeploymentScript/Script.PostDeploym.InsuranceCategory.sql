-- Life Insurance Subtypes
INSERT INTO InsuranceCategory (CategoryId, CategoryName, Description, InsuranceType)
VALUES
(NEWID(), 'Life Insurance-Term Insurance', 'Pure life cover', 'Life'),
(NEWID(), 'Life Insurance-Whole Life Insurance', 'Covers entire lifetime', 'Life'),
(NEWID(), 'Life Insurance-Endowment Plan', 'Life cover + savings', 'Life'),
(NEWID(), 'Life Insurance-ULIP', 'Investment linked insurance plan', 'Life'),
(NEWID(), 'Life Insurance-Retirement Plan', 'Pension oriented', 'Life'),
(NEWID(), 'Life Insurance-Child Plan', 'Future planning for children', 'Life');

-- Health Insurance Subtypes
INSERT INTO InsuranceCategory (CategoryId, CategoryName, Description, InsuranceType)
VALUES
(NEWID(), 'Health Insurance-Individual Health', 'Covers a single individual', 'Health'),
(NEWID(), 'Health Insurance-Family Floater', 'Covers whole family under one sum insured', 'Health'),
(NEWID(), 'Health Insurance-Senior Citizen Policy', 'Special cover for elderly', 'Health'),
(NEWID(), 'Health Insurance-Critical Illness Plan', 'Fixed payout on diagnosis', 'Health'),
(NEWID(), 'Health Insurance-Personal Accident Cover', 'Accident and disability cover', 'Health');

-- Motor Insurance Subtypes
INSERT INTO InsuranceCategory (CategoryId, CategoryName, Description, InsuranceType)
VALUES
(NEWID(), 'Motor Insurance-Private Car Insurance', 'Covers personal cars', 'Motor'),
(NEWID(), 'Motor Insurance-Two-Wheeler Insurance', 'Covers motorbikes/scooters', 'Motor'),
(NEWID(), 'Motor Insurance-Commercial Vehicle Insurance', 'Covers taxis, trucks, buses', 'Motor');

-- General Insurance Subtypes
INSERT INTO InsuranceCategory (CategoryId, CategoryName, Description, InsuranceType)
VALUES
(NEWID(), 'General Insurance-Property Insurance', 'Home, office, shop insurance', 'General'),
(NEWID(), 'General Insurance-Travel Insurance', 'Covers travel risks', 'General'),
(NEWID(), 'General Insurance-Marine Insurance', 'Cargo and hull cover', 'General'),
(NEWID(), 'General Insurance-Crop Insurance', 'Agriculture risk coverage', 'General'),
(NEWID(), 'General Insurance-Liability Insurance', 'Public, product, professional liability', 'General');

-- Commercial Insurance Subtypes
INSERT INTO InsuranceCategory (CategoryId, CategoryName, Description, InsuranceType)
VALUES
(NEWID(), 'Commercial Insurance-Group Health', 'Health cover for employees', 'Commercial'),
(NEWID(), 'Commercial Insurance-Workmen Compensation', 'Employer liability towards workers', 'Commercial'),
(NEWID(), 'Commercial Insurance-Cyber Insurance', 'Covers digital/cyber risks', 'Commercial'),
(NEWID(), 'Commercial Insurance-Trade Credit Insurance', 'Default/non-payment protection', 'Commercial');
