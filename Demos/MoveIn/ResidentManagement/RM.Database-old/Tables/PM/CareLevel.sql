CREATE TABLE PM.CareLevel
(
  CareLevelId            INT           NOT NULL,
  CareTypeId             INT           NOT NULL,
  CareLevelName          NVARCHAR(100) NOT NULL,
  SortOrder              INT               NULL,
  CONSTRAINT pkcCareLevel PRIMARY KEY CLUSTERED (CareLevelId),
  CONSTRAINT fkCareLevel_CareType FOREIGN KEY (CareTypeId) REFERENCES PM.CareType (CareTypeId)
)
GO