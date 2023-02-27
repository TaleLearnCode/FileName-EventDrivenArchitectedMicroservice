CREATE TABLE PM.CommunityCareLevel
(
  CommunityCareLevelId   INT                                            NOT NULL IDENTITY(1,1),
  CommunityId            INT                                            NOT NULL,
  CareLevelId            INT                                            NOT NULL,
  AssessmentScoreMinimum INT                                                NULL,
  AssessmentScoreMaximum INT                                                NULL,
  AssessmentTimeMinimum  INT                                                NULL,
  AssessmentTimeMaximum  INT                                                NULL,
  BaseRate               SMALLMONEY                                         NULL,
  DailyRate              SMALLMONEY                                         NULL,
  ValidFrom              DATETIME2  GENERATED ALWAYS AS ROW START HIDDEN NOT NULL,
  ValidTo                DATETIME2  GENERATED ALWAYS AS ROW END   HIDDEN NOT NULL,
  PERIOD FOR SYSTEM_TIME(ValidFrom, ValidTo),
  CONSTRAINT pkcCommunityCareLevel PRIMARY KEY CLUSTERED (CommunityCareLevelId),
  CONSTRAINT fkCommunityCareLevel_Community FOREIGN KEY (CommunityId) REFERENCES PM.Community (CommunityId),
  CONSTRAINT fkCommunityCareLevel_CareLevel FOREIGN KEY (CareLevelId) REFERENCES PM.CareLevel (CareLevelId)
) WITH (SYSTEM_VERSIONING = ON (HISTORY_TABLE = PM.CommunityCareLevelHistory))
GO