CREATE TABLE RM.ResidentCommunity
(
  ResidentCommunityId INT                                            NOT NULL,
  ResidentId          INT                                            NOT NULL,
  CommunityId         INT                                            NOT NULL,
  LeaseId             INT                                            NOT NULL,
  ValidFrom           DATETIME2 GENERATED ALWAYS AS ROW START HIDDEN NOT NULL,
  ValidTo             DATETIME2 GENERATED ALWAYS AS ROW END   HIDDEN NOT NULL,
  PERIOD FOR SYSTEM_TIME (ValidFrom, ValidTo),
  CONSTRAINT pkcResidentCommunity PRIMARY KEY CLUSTERED (ResidentCommunityId),
  CONSTRAINT fkResidentCommunity_Resident  FOREIGN KEY (ResidentId)  REFERENCES RM.Resident  (ResidentId),
  CONSTRAINT fkResidentCommunity_Community FOREIGN KEY (CommunityId) REFERENCES PM.Community (CommunityId),
  CONSTRAINT fkResidentCommunity_Lease     FOREIGN KEY (LeaseId)     REFERENCES LM.Lease     (LeaseId)
) WITH (SYSTEM_VERSIONING = ON (HISTORY_TABLE = RM.ResidentCommunityHistory))
GO