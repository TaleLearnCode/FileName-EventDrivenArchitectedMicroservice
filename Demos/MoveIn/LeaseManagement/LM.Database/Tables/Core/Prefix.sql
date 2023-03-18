CREATE TABLE Core.Prefix
(
  PrefixId INT NOT NULL,
  PrefixValue NVARCHAR(100) NOT NULL,
  SortOrder   INT               NULL,
  RowStatusId INT           NOT NULL,
  CONSTRAINT pkcPrefix PRIMARY KEY CLUSTERED (PrefixId)
)
GO