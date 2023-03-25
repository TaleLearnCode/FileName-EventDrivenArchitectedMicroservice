CREATE TABLE LM.Lessee
(
  LesseeId     INT           NOT NULL IDENTITY(1,1),
  ExternalId   NVARCHAR(100)     NULL,
  FirstName    NVARCHAR(100)     NULL,
  MiddleName   NVARCHAR(100)     NULL,
  LastName     NVARCHAR(100) NOT NULL,
  EmailAddress NVARCHAR(200)     NULL,
  CONSTRAINT pkcLessee PRIMARY KEY CLUSTERED (LesseeId)
)