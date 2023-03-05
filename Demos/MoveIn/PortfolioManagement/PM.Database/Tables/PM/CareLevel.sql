CREATE TABLE PM.CareLevel
(
  CareLevelId            INT           NOT NULL,
  ExternalId             NVARCHAR(100)     NULL,
  CareTypeId             INT           NOT NULL,
  CareLevelName          NVARCHAR(100) NOT NULL,
  SortOrder              INT               NULL,
  AssignToNewCommunities BIT           NOT NULL CONSTRAINT dfCareLevel_AssignToNewCommunities DEFAULT (1),
  RowStatusId            INT           NOT NULL CONSTRAINT dfCareLevel_RowStatusId DEFAULT (0),
  CONSTRAINT pkcCareLevel PRIMARY KEY CLUSTERED (CareLevelId),
  CONSTRAINT fkCareLevel_CareType FOREIGN KEY (CareTypeId) REFERENCES PM.CareType (CareTypeId)
)
GO

CREATE UNIQUE NONCLUSTERED INDEX unqCareLevel_ExternalId ON PM.CareLevel (ExternalId) WHERE ExternalId IS NOT NULL
GO
