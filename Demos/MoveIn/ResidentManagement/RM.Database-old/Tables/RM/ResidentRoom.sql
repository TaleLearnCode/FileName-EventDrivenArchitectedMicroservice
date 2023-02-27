CREATE TABLE RM.ResidentRoom
(
  ResidentRoomId INT                                             NOT NULL IDENTITY(1,1),
  ExternalId     NVARCHAR(100)                                       NULL,
  LeaseId        INT                                             NOT NULL,
  RoomId         INT                                             NOT NULL,
  Rate           SMALLMONEY                                      NOT NULL,
  EffectiveDate  DATE                                            NOT NULL,
  ValidFrom      DATETIME2  GENERATED ALWAYS AS ROW START HIDDEN NOT NULL,
  ValidTo        DATETIME2  GENERATED ALWAYS AS ROW END   HIDDEN NOT NULL,
  PERIOD FOR SYSTEM_TIME (ValidFrom, ValidTo),
  CONSTRAINT pkcResidentRoom PRIMARY KEY CLUSTERED (ResidentRoomId),
  CONSTRAINT fkResidentRoom_Lease FOREIGN KEY (LeaseId) REFERENCES LM.Lease (LeaseId),
  --CONSTRAINT fkResidentRoom_Room  FOREIGN KEY (RoomId)  REFERENCES PM.Room  (RoomId)
) WITH (SYSTEM_VERSIONING = ON (HISTORY_TABLE = PM.ResidentRoomHistory))
