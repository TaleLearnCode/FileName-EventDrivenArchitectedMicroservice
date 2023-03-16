CREATE TABLE RM.ResidentAncillaryCare
(
  ResidentAncillaryCareId INT                                            NOT NULL IDENTITY(1,1),
  ResidentCommunityId     INT                                            NOT NULL,
  AncillaryCareId         INT                                            NOT NULL,
  ValidFrom               DATETIME2 GENERATED ALWAYS AS ROW START HIDDEN NOT NULL,
  ValidTo                 DATETIME2 GENERATED ALWAYS AS ROW END   HIDDEN NOT NULL,
  PERIOD FOR SYSTEM_TIME (ValidFrom, ValidTo),
  CONSTRAINT pkcResidentAncillaryCare PRIMARY KEY CLUSTERED (ResidentAncillaryCareId),
  CONSTRAINT fkResidentAncillaryCare_ResidentCommunity FOREIGN KEY (ResidentCommunityId) REFERENCES RM.ResidentCommunity (ResidentCommunityId),
  CONSTRAINT fkResidentAncillaryCare_AncillaryCare     FOREIGN KEY (AncillaryCareId)     REFERENCES PM.AncillaryCare     (AncillaryCareId)
) WITH (SYSTEM_VERSIONING = ON (HISTORY_TABLE = RM.ResidentAncillaryCareHistory))
GO