CREATE TABLE RM.Resident
(
  ResidentId  INT           NOT NULL IDENTITY(1,1),
  FirstName   NVARCHAR(100) NOT NULL,
  MiddleName  NVARCHAR(100)     NULL,
  LastName    NVARCHAR(100) NOT NULL,
  DateOfBirth DATE          NOT NULL,
  IsActive    BIT           NOT NULL CONSTRAINT dfResident_IsActive DEFAULT(1)
)