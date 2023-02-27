CREATE TABLE PM.Community
(
  CommunityId              INT           NOT NULL,
  CommunityNumber          NVARCHAR(50)  NOT NULL,
  CommunityName            NVARCHAR(200) NOT NULL,
  CountryCode              CHAR(2)           NULL,
  ProfileImageUrl          NVARCHAR(500)     NULL,
  CommunityStatusId        INT           NOT NULL,
  RowStatusId              INT           NOT NULL,
  CONSTRAINT pkcCommunity PRIMARY KEY CLUSTERED (CommunityId),
  CONSTRAINT fkCommunity_Country           FOREIGN KEY (CountryCode)           REFERENCES Core.Country (CountryCode),
  CONSTRAINT fkCommunity_CommunityStatus   FOREIGN KEY (CommunityStatusId)     REFERENCES PM.CommunityStatus (CommunityStatusId),
  CONSTRAINT unqCommunity_CommunityNumber  UNIQUE(CommunityNumber)
)
GO

CREATE NONCLUSTERED INDEX idxCommunity_CommunityNumber
  ON PM.Community(CommunityNumber ASC);
GO

EXEC sp_addextendedproperty @level0name=N'PM', @level1name=N'Community',                                                      @value=N'Represents a community run by the tenant.',                                                                @name=N'MS_Description', @level0type=N'SCHEMA', @level1type=N'TABLE';
GO
EXEC sp_addextendedproperty @level0name=N'PM', @level1name=N'Community', @level2name=N'CommunityId',                          @value=N'The identifier of the community record.',                                                                  @name=N'MS_Description', @level0type=N'SCHEMA', @level1type=N'TABLE', @level2type=N'COLUMN';
GO
EXEC sp_addextendedproperty @level0name=N'PM', @level1name=N'Community', @level2name=N'CommunityNumber',                      @value=N'The tenant''s number (identifier) for the community.',                                                     @name=N'MS_Description', @level0type=N'SCHEMA', @level1type=N'TABLE', @level2type=N'COLUMN';
GO
EXEC sp_addextendedproperty @level0name=N'PM', @level1name=N'Community', @level2name=N'CommunityName',                        @value=N'The name of the community.',                                                                               @name=N'MS_Description', @level0type=N'SCHEMA', @level1type=N'TABLE', @level2type=N'COLUMN';
GO
EXEC sp_addextendedproperty @level0name=N'PM', @level1name=N'Community', @level2name=N'CountryCode',                          @value=N'Identifier of the country the community is located in.',                                                   @name=N'MS_Description', @level0type=N'SCHEMA', @level1type=N'TABLE', @level2type=N'COLUMN';
GO
EXEC sp_addextendedproperty @level0name=N'PM', @level1name=N'Community', @level2name=N'ProfileImageUrl',                      @value=N'URL of the digital asset that serves as the profile image for the community.',                             @name=N'MS_Description', @level0type=N'SCHEMA', @level1type=N'TABLE', @level2type=N'COLUMN';
GO
EXEC sp_addextendedproperty @level0name=N'PM', @level1name=N'Community', @level2name=N'RowStatusId',                          @value=N'Identifier of the community record status (i.e. enabled, disabled, etc).',                                 @name=N'MS_Description', @level0type=N'SCHEMA', @level1type=N'TABLE', @level2type=N'COLUMN';
GO
EXEC sp_addextendedproperty @level0name=N'PM', @level1name=N'Community', @level2name=N'pkcCommunity',                         @value=N'Defines the primary key for the Community table using the CommunityId column.',                            @name=N'MS_Description', @level0type=N'SCHEMA', @level1type=N'TABLE', @level2type=N'CONSTRAINT';
GO
EXEC sp_addextendedproperty @level0name=N'PM', @level1name=N'Community', @level2name=N'idxCommunity_CommunityNumber',         @value=N'Defines an ascending index on the Community table using the CommunityNumber column.',                      @name=N'MS_Description', @level0type=N'SCHEMA', @level1type=N'TABLE', @level2type=N'INDEX';
GO