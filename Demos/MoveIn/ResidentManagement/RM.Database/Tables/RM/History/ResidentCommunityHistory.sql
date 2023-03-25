CREATE TABLE RM.ResidentCommunityHistory
(
  ResidentCommunityId INT       NOT NULL,
  ResidentId          INT       NOT NULL,
  CommunityId         INT       NOT NULL,
  LeaseId             INT           NULL,
  ValidFrom           DATETIME2 NOT NULL,
  ValidTo             DATETIME2 NOT NULL,
)
GO