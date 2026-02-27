CREATE TABLE WorkflowTemplates (
    Id UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWID(),
    ClientId UNIQUEIDENTIFIER NULL,
    FormId UNIQUEIDENTIFIER NOT NULL,
    Name NVARCHAR(200) NOT NULL,
    Version INT NOT NULL DEFAULT 1,
    IsActive BIT NOT NULL DEFAULT 1,
    IsSystemTemplate BIT NOT NULL DEFAULT 0,
    CreatedAt DATETIME2 NOT NULL DEFAULT SYSUTCDATETIME(),
    CreatedBy NVARCHAR(100),
    UpdatedAt DATETIME2 NULL,
    UpdatedBy NVARCHAR(100)
);

CREATE UNIQUE INDEX UX_WorkflowTemplate_Form_Version
ON WorkflowTemplates(FormId, Version);

CREATE TABLE WorkflowStates (
    Id UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWID(),
    TemplateId UNIQUEIDENTIFIER NOT NULL,
    Name NVARCHAR(100) NOT NULL,
    Sequence INT NOT NULL,
    IsStart BIT NOT NULL DEFAULT 0,
    IsEnd BIT NOT NULL DEFAULT 0,
    AllowEdit BIT NOT NULL DEFAULT 0,
    SLAHours INT NULL,
    EscalationRoleId UNIQUEIDENTIFIER NULL,
    CreatedAt DATETIME2 NOT NULL DEFAULT SYSUTCDATETIME(),

    CONSTRAINT FK_WorkflowStates_Template
        FOREIGN KEY (TemplateId)
        REFERENCES WorkflowTemplates(Id)
        ON DELETE CASCADE
);

CREATE INDEX IX_WorkflowStates_TemplateId
ON WorkflowStates(TemplateId);

CREATE TABLE WorkflowTransitions (
    Id UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWID(),
    TemplateId UNIQUEIDENTIFIER NOT NULL,
    FromStateId UNIQUEIDENTIFIER NOT NULL,
    ToStateId UNIQUEIDENTIFIER NOT NULL,
    ActionName NVARCHAR(100) NOT NULL,
    RequiresApproval BIT NOT NULL DEFAULT 0,
    AutoTransition BIT NOT NULL DEFAULT 0,
    CreatedAt DATETIME2 NOT NULL DEFAULT SYSUTCDATETIME(),

    CONSTRAINT FK_Transitions_Template
        FOREIGN KEY (TemplateId)
        REFERENCES WorkflowTemplates(Id)
        ON DELETE CASCADE,

    CONSTRAINT FK_Transitions_FromState
        FOREIGN KEY (FromStateId)
        REFERENCES WorkflowStates(Id),

    CONSTRAINT FK_Transitions_ToState
        FOREIGN KEY (ToStateId)
        REFERENCES WorkflowStates(Id)
);

CREATE INDEX IX_WorkflowTransitions_FromState
ON WorkflowTransitions(FromStateId);

CREATE TABLE WorkflowTransitionRoles (
    Id UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWID(),
    TransitionId UNIQUEIDENTIFIER NOT NULL,
    RoleId UNIQUEIDENTIFIER NOT NULL,

    CONSTRAINT FK_TransitionRoles_Transition
        FOREIGN KEY (TransitionId)
        REFERENCES WorkflowTransitions(Id)
        ON DELETE CASCADE
);

CREATE INDEX IX_WorkflowTransitionRoles_TransitionId
ON WorkflowTransitionRoles(TransitionId);

CREATE TABLE WorkflowInstances (
    Id UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWID(),
    TransactionId NVARCHAR(100) NOT NULL,
    TemplateId UNIQUEIDENTIFIER NOT NULL,
    CurrentStateId UNIQUEIDENTIFIER NOT NULL,
    ClientId UNIQUEIDENTIFIER NULL,
    StartedAt DATETIME2 NOT NULL DEFAULT SYSUTCDATETIME(),
    CompletedAt DATETIME2 NULL,
    IsCompleted BIT NOT NULL DEFAULT 0,

    CONSTRAINT FK_WorkflowInstances_Template
        FOREIGN KEY (TemplateId)
        REFERENCES WorkflowTemplates(Id),

    CONSTRAINT FK_WorkflowInstances_State
        FOREIGN KEY (CurrentStateId)
        REFERENCES WorkflowStates(Id)
);

CREATE INDEX IX_WorkflowInstances_Transaction
ON WorkflowInstances(TransactionId);

CREATE INDEX IX_WorkflowInstances_CurrentState
ON WorkflowInstances(CurrentStateId);

CREATE TABLE WorkflowHistory (
    Id UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWID(),
    InstanceId UNIQUEIDENTIFIER NOT NULL,
    FromStateId UNIQUEIDENTIFIER NOT NULL,
    ToStateId UNIQUEIDENTIFIER NOT NULL,
    ActionName NVARCHAR(100) NOT NULL,
    PerformedBy NVARCHAR(100) NOT NULL,
    Comments NVARCHAR(MAX) NULL,
    PerformedAt DATETIME2 NOT NULL DEFAULT SYSUTCDATETIME(),
    IPAddress NVARCHAR(50) NULL,
    DeviceInfo NVARCHAR(200) NULL,

    CONSTRAINT FK_WorkflowHistory_Instance
        FOREIGN KEY (InstanceId)
        REFERENCES WorkflowInstances(Id)
        ON DELETE CASCADE
);

CREATE INDEX IX_WorkflowHistory_InstanceId
ON WorkflowHistory(InstanceId);

CREATE TABLE WorkflowEventTriggers (
    Id UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWID(),
    SourceTemplateId UNIQUEIDENTIFIER NOT NULL,
    SourceStateId UNIQUEIDENTIFIER NOT NULL,
    TargetFormId UNIQUEIDENTIFIER NOT NULL,
    TargetTemplateId UNIQUEIDENTIFIER NOT NULL,
    IsActive BIT NOT NULL DEFAULT 1,

    CONSTRAINT FK_WorkflowEventTriggers_SourceTemplate
        FOREIGN KEY (SourceTemplateId)
        REFERENCES WorkflowTemplates(Id)
);

CREATE TABLE FieldStateConfigurations (
    Id UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWID(),
    FieldId UNIQUEIDENTIFIER NOT NULL,
    StateId UNIQUEIDENTIFIER NOT NULL,
    IsVisible BIT NOT NULL DEFAULT 1,
    IsEditable BIT NOT NULL DEFAULT 1,
    IsMandatory BIT NOT NULL DEFAULT 0,

    CONSTRAINT FK_FieldStateConfigurations_State
        FOREIGN KEY (StateId)
        REFERENCES WorkflowStates(Id)
        ON DELETE CASCADE
);