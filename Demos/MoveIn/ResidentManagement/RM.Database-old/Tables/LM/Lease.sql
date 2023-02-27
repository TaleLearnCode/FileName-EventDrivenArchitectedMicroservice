CREATE TABLE LM.Lease
(
  LeaseId     INT           NOT NULL IDENTITY(1,1),
  ExternalId  NVARCHAR(100) NOT NULL,
  ResidentId  INT           NOT NULL,
  StartDate   DATE          NOT NULL,
  EndDate     DATE          NOT NULL,
  CONSTRAINT pkcLease PRIMARY KEY CLUSTERED (LeaseId),
  CONSTRAINT fkLease_Resident  FOREIGN KEY (ResidentId)  REFERENCES RM.Resident (ResidentId)
)