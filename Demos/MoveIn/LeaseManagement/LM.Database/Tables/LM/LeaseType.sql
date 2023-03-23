CREATE TABLE LM.LeaseType
(
  LeaseTypeId     INT           NOT NULL IDENTITY(1,1),
  ExternalId      NVARCHAR(100)     NULL,
  LeaseTermTypeId INT           NOT NULL,
  LeaseTypeName   NVARCHAR(100) NOT NULL,
  RowStatusId     INT           NOT NULL CONSTRAINT dfLeaseType_RowStatusId DEFAULT (0),
  CONSTRAINT pkcLeaseType PRIMARY KEY CLUSTERED (LeaseTypeId),
  CONSTRAINT fkLeaseType_LeaseTermType FOREIGN KEY (LeaseTermTypeId) REFERENCES LM.LeaseTermType (LeaseTermTypeId)
)
GO

CREATE UNIQUE NONCLUSTERED INDEX unqLeaseType_ExternalId ON LM.LeaseType (ExternalId) WHERE ExternalId IS NOT NULL
GO