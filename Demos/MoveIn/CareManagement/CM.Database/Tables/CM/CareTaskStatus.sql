CREATE TABLE CM.CareTaskStatus
(
  CareTaskStatusId   INT           NOT NULL IDENTITY(1,1),
  CareTaskStatusName NVARCHAR(100) NOT NULL,
  IsDefault          BIT           NOT NULL CONSTRAINT dfCareTaskStatus_IsDefault DEFAULT(0),
  RowStatusId        INT           NOT NULL CONSTRAINT dfCareTaskStatus_RowStatusId DEFAULT(1),
  CONSTRAINT pkcCareTaskStatus PRIMARY KEY CLUSTERED (CareTaskStatusId)
)