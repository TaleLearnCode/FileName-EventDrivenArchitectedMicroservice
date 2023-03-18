CREATE TABLE CM.CareTaskType
(
  CareTaskTypeId         INT           NOT NULL IDENTITY(1,1),
  CareTaskTypeName       NVARCHAR(100) NOT NULL,
  EmployeeRoleId         INT           NOT NULL,
  AssignToNewResidents   BIT           NOT NULL CONSTRAINT dfCareTaskType_AssignToNewResidents DEFAULT(0),
  RowStatusId            INT           NOT NULL CONSTRAINT dfCareTaskType_RowStatus DEFAULT(1),
  CONSTRAINT pkcCareTaskType PRIMARY KEY CLUSTERED (CareTaskTypeId)
)