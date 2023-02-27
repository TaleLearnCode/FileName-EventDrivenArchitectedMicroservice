CREATE TABLE PM.CommunityAncillaryCare
(
  CommunityAncillaryCareId INT                                             NOT NULL IDENTITY(1,1),
  ExternalId               NVARCHAR(100)                                       NULL,
  CommunityId              INT                                             NOT NULL,
  AncillaryCareId          INT                                             NOT NULL,
  AssessmentScoreMinimum   INT                                                 NULL,
  AssessmentScoreMaximum   INT                                                 NULL,
  BaseRate                 SMALLMONEY                                          NULL,
  DailyRate                SMALLMONEY                                          NULL,
  ValidFrom                DATETIME2  GENERATED ALWAYS AS ROW START HIDDEN NOT NULL,
  ValidTo                  DATETIME2  GENERATED ALWAYS AS ROW END   HIDDEN NOT NULL,
  PERIOD FOR SYSTEM_TIME (ValidFrom, ValidTo),
  CONSTRAINT pkcCommuniaryAncillaryCare PRIMARY KEY CLUSTERED(CommunityAncillaryCareId),
  CONSTRAINT fkCommunityAncillaryCare_Community FOREIGN KEY (CommunityId) REFERENCES PM.Community (CommunityId),
  CONSTRAINT fkCommunityAncillaryCare_AncillaryCare FOREIGN KEY (AncillaryCareId) REFERENCES PM.AncillaryCare (AncillaryCareId)
) WITH (SYSTEM_VERSIONING = ON (HISTORY_TABLE = PM.CommunityAncillaryCareHistory))
GO