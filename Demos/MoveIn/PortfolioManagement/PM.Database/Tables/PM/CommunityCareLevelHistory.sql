CREATE TABLE PM.CommunityCareLevelHistory
(
  CommunityCareLevelId   INT        NOT NULL,
  CommunityId            INT        NOT NULL,
  CareLevelId            INT        NOT NULL,
  AssessmentScoreMinimum INT            NULL,
  AssessmentScoreMaximum INT            NULL,
  AssessmentTimeMinimum  INT            NULL,
  AssessmentTimeMaximum  INT            NULL,
  BaseRate               SMALLMONEY     NULL,
  DailyRate              SMALLMONEY     NULL,
  ValidFrom              DATETIME2  NOT NULL,
  ValidTo                DATETIME2  NOT NULL,
)
GO