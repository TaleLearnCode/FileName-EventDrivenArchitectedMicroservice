CREATE TABLE LM.LeaseTermType
(
  LeaseTermTypeId   INT           NOT NULL,
  LeaseTermTypeName NVARCHAR(100) NOT NULL,
  CONSTRAINT pkcLeaseTermType PRIMARY KEY CLUSTERED (LeaseTermTypeId)
)