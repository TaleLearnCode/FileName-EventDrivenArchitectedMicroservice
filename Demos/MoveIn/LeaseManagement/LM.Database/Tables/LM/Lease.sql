CREATE TABLE LM.Lease
(
  LeaseId     INT           NOT NULL IDENTITY(1,1),
  ExternalId  NVARCHAR(100)     NULL,
  ResidentId  INT           NOT NULL,
  LeaseTypeId INT           NOT NULL,
  StartDate   DATE          NOT NULL,
  EndDate     DATE          NOT NULL,
  Rate        SMALLMONEY    NOT NULL,
  CONSTRAINT pkcLease PRIMARY KEY CLUSTERED (LeaseId),
  CONSTRAINT fkLease_Resident  FOREIGN KEY (ResidentId)  REFERENCES RM.Resident (ResidentId),
  CONSTRAINT fkLease_LeaseType FOREIGN KEY (LeaseTypeId) REFERENCES LM.LeaseType (LeaseTypeId)
)