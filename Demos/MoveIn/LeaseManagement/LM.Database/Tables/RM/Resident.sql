CREATE TABLE RM.Resident
(
  ResidentId         INT           NOT NULL IDENTITY(1,1),
  FirstName          NVARCHAR(100)     NULL,
  MiddleName         NVARCHAR(100)     NULL,
  LastName           NVARCHAR(100) NOT NULL,
  LesseeId           INT           NOT NULL,
  ResponsiblePartyId INT           NOT NULL,
  CONSTRAINT pkcResident PRIMARY KEY CLUSTERED (ResidentId),
  CONSTRAINT fkResident_Lessee FOREIGN KEY (LesseeId) REFERENCES LM.Lessee (LesseeId),
  CONSTRAINT fkResident_ResponsibleParty FOREIGN KEY (ResponsiblePartyId) REFERENCES LM.ResponsibleParty(ResponsiblePartyId)
)
GO