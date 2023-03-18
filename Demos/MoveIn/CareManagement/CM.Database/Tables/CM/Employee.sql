CREATE TABLE CM.Employee
(
  EmployeeId     INT           NOT NULL,
  EmployeeRoleId INT           NOT NULL,
  FirstName      NVARCHAR(100) NOT NULL,
  LastName       NVARCHAR(100) NOT NULL,
  RowStatusId    INT           NOT NULL CONSTRAINT dfEmployee_RowStatusId DEFAULT(1),
  CONSTRAINT pkcEmployee PRIMARY KEY CLUSTERED (EmployeeId)
)