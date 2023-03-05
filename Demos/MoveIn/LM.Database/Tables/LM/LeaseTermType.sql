CREATE TABLE LM.LeaseTermType
(
  LeaseTermTypeId  INT           NOT NULL,
  LeaseTermName    NVARCHAR(100) NOT NULL,
  CONSTRAINT pkcLeaseTermType PRIMARY KEY CLUSTERED (LeaseTermTypeId)
)