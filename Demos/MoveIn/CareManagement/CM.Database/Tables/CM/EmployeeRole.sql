CREATE TABLE CM.EmployeeRole
(
  EmployeeRoleId   INT           NOT NULL IDENTITY(1,1),
  EmployeeRoleName NVARCHAR(100) NOT NULL,
  EmployeeRoleCode VARCHAR(20)       NULL,
  RowStatusId      INT           NOT NULL CONSTRAINT dfEmployeeRole_RowStatusId DEFAULT(1),
  CONSTRAINT pkcEmployeeRole PRIMARY KEY CLUSTERED (EmployeeRoleId)
)