CREATE TABLE CM.CareTask
(
  CareTaskId            INT       NOT NULL IDENTITY(1,1),
  CareTaskTypeId        INT       NOT NULL,
  CareTaskStatusId      INT       NOT NULL,
  PrimaryEmployeeId     INT       NOT NULL,
  AssignedDateTime      DATETIME2 NOT NULL,
  ExpectedStartDateTime DATETIME2 NOT NULL,
  ExpectetdEndDateTime  DATETIME2 NOT NULL,
  ActualStartDateTime   DATETIME2     NULL,
  ActualEndDateTime     DATETIME2     NULL
)