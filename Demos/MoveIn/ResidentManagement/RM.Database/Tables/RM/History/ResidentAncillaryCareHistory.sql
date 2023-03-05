CREATE TABLE RM.ResidentAncillaryCareHistory
(
  ResidentAncillaryCareId INT        NOT NULL,
  ResidentCommunityId     INT        NOT NULL,
  AncillaryCareId         INT        NOT NULL,
  Rate                    SMALLMONEY NOT NULL,
  EffectiveDate           DATE       NOT NULL,
  ValidFrom               DATETIME2  NOT NULL,
  ValidTo                 DATETIME2  NOT NULL,
)
GO