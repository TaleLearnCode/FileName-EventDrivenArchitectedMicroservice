CREATE TABLE RM.Relation
(
  RelationId   INT           NOT NULL,
  RelationName NVARCHAR(100) NOT NULL,
  SortOrder    INT           NOT NULL,
  RowStatusId  INT           NOT NULL,
  CONSTRAINT pkcRelation PRIMARY KEY CLUSTERED (RelationId)
)
GO