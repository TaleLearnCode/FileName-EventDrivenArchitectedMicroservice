CREATE TABLE PM.AncillaryCareCategory
(
  AncillaryCareCategoryId   INT           NOT NULL IDENTITY(1,1),
  AncillaryCareCategoryName NVARCHAR(100) NOT NULL,
  AncillaryCareCategoryCode NVARCHAR(20)      NULL,
  ForegroundColor           CHAR(7)           NULL,
  BackgroundColor           CHAR(7)           NULL,
  SortOrder                 INT               NULL,
  CONSTRAINT pkcAncillaryCareCategory PRIMARY KEY CLUSTERED (AncillaryCareCategoryId),
)
GO