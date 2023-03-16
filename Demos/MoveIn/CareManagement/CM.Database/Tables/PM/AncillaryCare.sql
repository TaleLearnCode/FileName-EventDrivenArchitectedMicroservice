CREATE TABLE PM.AncillaryCare
(
  AncillaryCareId         INT           NOT NULL IDENTITY(1,1),
  AncillaryCareCategoryId INT           NOT NULL,
  AncillaryCareName       NVARCHAR(100) NOT NULL,
  ForegroundColor         CHAR(7)           NULL,
  BackgroundColor         CHAR(7)           NULL,
  SortOrder               INT               NULL,
  CONSTRAINT pkcAncillaryCare PRIMARY KEY CLUSTERED (AncillaryCareId),
  CONSTRAINT fkAncillaryCare_AncillaryCareCategory FOREIGN KEY (AncillaryCareCategoryId) REFERENCES PM.AncillaryCareCategory (AncillaryCareCategoryId)
)
GO