CREATE TABLE RM.ResidentCareLevel
(
  ResidentCareLevelId INT                                            NOT NULL IDENTITY(1,1),
  ResidentCommunityId INT                                            NOT NULL,
  CareLevelId         INT                                            NOT NULL,
  Rate                SMALLMONEY                                     NOT NULL CONSTRAINT dfResidentCareLevel_Rate DEFAULT (0),
  EffectiveDate       DATE                                           NOT NULL CONSTRAINT dfResidentCareLevel_EffectiveDate DEFAULT (GETUTCDATE()),
  ValidFrom           DATETIME2 GENERATED ALWAYS AS ROW START HIDDEN NOT NULL,
  ValidTo             DATETIME2 GENERATED ALWAYS AS ROW END   HIDDEN NOT NULL,
  PERIOD FOR SYSTEM_TIME (ValidFrom, ValidTo),
  CONSTRAINT pkcResidentCareLevel PRIMARY KEY CLUSTERED (ResidentCareLevelId),
  CONSTRAINT fkResidentCareLevel_ResidentCommunityId FOREIGN KEY (ResidentCommunityId) REFERENCES RM.ResidentCommunity (ResidentCommunityId),
  CONSTRAINT fkResidentCareLevel_CareLevel           FOREIGN KEY (CareLevelId)         REFERENCES PM.CareLevel (CareLevelId)
) WITH (SYSTEM_VERSIONING = ON (HISTORY_TABLE = RM.ResidentCareLevelHistory))
GO