CREATE TABLE PM.AncillaryCareCategory
(
  AncillaryCareCategoryId   INT           NOT NULL IDENTITY(1,1),
  ExternalId                NVARCHAR(100)     NULL,
  AncillaryCareCategoryName NVARCHAR(100) NOT NULL,
  AncillaryCareCategoryCode NVARCHAR(20)      NULL,
  ForegroundColor           CHAR(7)           NULL,
  BackgroundColor           CHAR(7)           NULL,
  AssignToNewCommunities    BIT           NOT NULL CONSTRAINT dfAncillaryCareCategory_AssignToNewCommunities DEFAULT (0),
  SortOrder                 INT               NULL,
  RowStatusId               INT           NOT NULL CONSTRAINT dfAncillaryCareCategory_RowStatusId DEFAULT (1),
  CONSTRAINT pkcAncillaryCareCategory PRIMARY KEY CLUSTERED (AncillaryCareCategoryId),
)
GO

CREATE UNIQUE NONCLUSTERED INDEX unqAncillaryCareCategory_ExternalId ON PM.AncillaryCareCategory (ExternalId) WHERE ExternalId IS NOT NULL
GO