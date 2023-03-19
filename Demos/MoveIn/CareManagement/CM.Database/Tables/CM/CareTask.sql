CREATE TABLE CM.CareTask
(
  CareTaskId            INT       NOT NULL IDENTITY(1,1),
  CareTaskTypeId        INT       NOT NULL,
  CareTaskStatusId      INT       NOT NULL,
  PrimaryEmployeeId     INT           NULL,
  AssignedDateTime      DATETIME2 NOT NULL,
  ExpectedStartDateTime DATETIME2 NOT NULL,
  ExpectetdEndDateTime  DATETIME2 NOT NULL,
  ActualStartDateTime   DATETIME2     NULL,
  ActualEndDateTime     DATETIME2     NULL,
  CONSTRAINT pkcCareTask PRIMARY KEY CLUSTERED (CareTaskId),
  CONSTRAINT fkCareTask_CareTaskType FOREIGN KEY (CareTaskTypeId) REFERENCES CM.CareTaskType (CareTaskTypeId),
  CONSTRAINT fkCareTask_CareTaskStatus FOREIGN KEY (CareTaskStatusId) REFERENCES CM.CareTaskStatus (CareTaskStatusId),
  CONSTRAINT fkCareTask_PrimaryEmployee FOREIGN KEY (PrimaryEmployeeId) REFERENCES CM.Employee (EmployeeId)
)