CREATE TABLE PM.AncillaryCare
(
  AncillaryCareId         INT           NOT NULL IDENTITY(1,1),
  ExternalId              NVARCHAR(100)     NULL,
  AncillaryCareCategoryId INT           NOT NULL,
  AncillaryCareName       NVARCHAR(100) NOT NULL,
  ForegroundColor         CHAR(7)           NULL,
  BackgroundColor         CHAR(7)           NULL,
  AssignToNewCommunities  BIT           NOT NULL CONSTRAINT dfAncillaryCare_AssignToNewCommuniteis DEFAULT (0),
  SortOrder               INT               NULL,
  RowStatusId             INT           NOT NULL CONSTRAINT dfAncillaryCare_RowStatusId DEFAULT (1),
  CONSTRAINT pkcAncillaryCare PRIMARY KEY CLUSTERED (AncillaryCareId),
  CONSTRAINT fkAncillaryCare_AncillaryCareCategory FOREIGN KEY (AncillaryCareCategoryId) REFERENCES PM.AncillaryCareCategory (AncillaryCareCategoryId)
)
GO

CREATE UNIQUE NONCLUSTERED INDEX unqAncillaryCare_ExternalId ON PM.AncillaryCare (ExternalId) WHERE ExternalId IS NOT NULL
GO