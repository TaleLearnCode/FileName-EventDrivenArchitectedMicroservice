CREATE TABLE RM.Resident
(
  ResidentId  INT           NOT NULL IDENTITY(1,1),
  FirstName   NVARCHAR(100)     NULL,
  MiddleName  NVARCHAR(100)     NULL,
  LastName    NVARCHAR(100) NOT NULL,
  DateOfBirth DATE          NOT NULL,
  CONSTRAINT pkcResident PRIMARY KEY CLUSTERED (ResidentId)
)
GO