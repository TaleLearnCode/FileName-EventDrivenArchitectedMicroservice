CREATE TABLE RM.ResidentRoomHistory
(
  ResidentRoomId      INT        NOT NULL,
  ResidentCommunityId INT        NOT NULL,
  RoomId              INT        NOT NULL,
  Rate                SMALLMONEY NOT NULL,
  EffectiveDate       DATE       NOT NULL,
  ValidFrom           DATETIME2  NOT NULL,
  ValidTo             DATETIME2  NOT NULL,
)
GO