CREATE TABLE RM.ResidentRoom
(
  ResidentRoomId      INT                                             NOT NULL IDENTITY(1,1),
  ResidentCommunityId INT                                             NOT NULL,
  RoomId              INT                                             NOT NULL,
  CareTypeId          INT                                             NOT NULL,
  ValidFrom           DATETIME2  GENERATED ALWAYS AS ROW START HIDDEN NOT NULL,
  ValidTo             DATETIME2  GENERATED ALWAYS AS ROW END   HIDDEN NOT NULL,
  PERIOD FOR SYSTEM_TIME (ValidFrom, ValidTo),
  CONSTRAINT pkcResidentRoom PRIMARY KEY CLUSTERED (ResidentRoomId),
  CONSTRAINT fkResidentRoom_Room  FOREIGN KEY (RoomId)  REFERENCES PM.Room  (RoomId),
  CONSTRAINT fkResidentRoom_ResidentCommunity FOREIGN KEY (ResidentCommunityId) REFERENCES RM.ResidentCommunity (ResidentCommunityId),
  CONSTRAINT fkResidentRoom_CareType FOREIGN KEY (CareTypeId) REFERENCES PM.CareType (CareTypeId)
) WITH (SYSTEM_VERSIONING = ON (HISTORY_TABLE = PM.ResidentRoomHistory))