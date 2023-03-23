CREATE TABLE LM.ResponsibleParty
(
  ResponsiblePartyId INT           NOT NULL,
  ExternalId         NVARCHAR(100)     NULL,
  FirstName          NVARCHAR(100)     NULL,
  MiddleName         NVARCHAR(100)     NULL,
  LastName           NVARCHAR(100) NOT NULL,
  EmailAddress       NVARCHAR(200)     NULL,
  CONSTRAINT pkcResponsibleParty PRIMARY KEY CLUSTERED (ResponsiblePartyId)
)