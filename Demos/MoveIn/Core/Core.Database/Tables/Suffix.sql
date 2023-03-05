CREATE TABLE Core.Suffix
(
  SuffixId    INT NOT NULL,
  SuffixValue NVARCHAR(100) NOT NULL,
  SortOrder   INT               NULL,
  RowStatusId INT           NOT NULL,
  CONSTRAINT pkcSuffix PRIMARY KEY CLUSTERED (SuffixId)
)
GO