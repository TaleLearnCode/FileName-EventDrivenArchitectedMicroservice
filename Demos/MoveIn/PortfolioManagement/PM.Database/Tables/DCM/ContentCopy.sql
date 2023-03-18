CREATE TABLE DCM.ContentCopy
(
	ContentId           INT           NOT NULL,
	LanguageCultureCode VARCHAR(15)   NOT NULL,
	CopyText            NVARCHAR(MAX) NOT NULL,
	CONSTRAINT pkcContentCopy PRIMARY KEY CLUSTERED (ContentId, LanguageCultureCode),
	CONSTRAINT fkContentCopy_Content         FOREIGN KEY (ContentId)           REFERENCES DCM.Content (ContentId),
	CONSTRAINT fkContentCopy_LanguageCulture FOREIGN KEY (LanguageCultureCode) REFERENCES Core.LanguageCulture (LanguageCultureCode)
)
GO

EXEC sp_addextendedproperty @level0name=N'DCM', @level1name=N'ContentCopy',                                               @value=N'Represents content for an item managed by the system.',                                                @name=N'MS_Description', @level0type=N'SCHEMA', @level1type=N'TABLE';
GO
EXEC sp_addextendedproperty @level0name=N'DCM', @level1name=N'ContentCopy', @level2name=N'ContentId',                     @value=N'Identifier of the associated Content record.',                                                         @name=N'MS_Description', @level0type=N'SCHEMA', @level1type=N'TABLE', @level2type=N'COLUMN';
GO
EXEC sp_addextendedproperty @level0name=N'DCM', @level1name=N'ContentCopy', @level2name=N'LanguageCultureCode',             @value=N'Identifier of the associated LanguageCulture record.',                                                 @name=N'MS_Description', @level0type=N'SCHEMA', @level1type=N'TABLE', @level2type=N'COLUMN';
GO
EXEC sp_addextendedproperty @level0name=N'DCM', @level1name=N'ContentCopy', @level2name=N'CopyText',                      @value=N'The text of the content copy.',                                                                        @name=N'MS_Description', @level0type=N'SCHEMA', @level1type=N'TABLE', @level2type=N'COLUMN';
GO
EXEC sp_addextendedproperty @level0name=N'DCM', @level1name=N'ContentCopy', @level2name=N'pkcContentCopy',                @value=N'Defines the primary key for the ContentCopy table using the ContentId and LanguageCultureId columns.', @name=N'MS_Description', @level0type=N'SCHEMA', @level1type=N'TABLE', @level2type=N'CONSTRAINT';
GO
EXEC sp_addextendedproperty @level0name=N'DCM', @level1name=N'ContentCopy', @level2name=N'fkContentCopy_Content',         @value=N'Defines the relationship between the ContentCopy and Content tables using the ContentId column.',      @name=N'MS_Description', @level0type=N'SCHEMA', @level1type=N'TABLE', @level2type=N'CONSTRAINT';
GO
EXEC sp_addextendedproperty @level0name=N'DCM', @level1name=N'ContentCopy', @level2name=N'fkContentCopy_LanguageCulture', @value=N'Defines the relationship between the ContentCopy and Content tables using the ContentId column.',      @name=N'MS_Description', @level0type=N'SCHEMA', @level1type=N'TABLE', @level2type=N'CONSTRAINT';
GO