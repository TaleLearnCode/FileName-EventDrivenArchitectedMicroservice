CREATE TABLE Core.[Language]
(
	LanguageCode CHAR(2)       NOT NULL,
	LanguageName NVARCHAR(100) NOT NULL,
	NativeName   NVARCHAR(100) NOT NULL,
	RowStatusId  INT           NOT NULL,
	CONSTRAINT pkcLanguage PRIMARY KEY CLUSTERED (LanguageCode)
)
GO

EXEC sp_addextendedproperty @level0name=N'Core', @level1name=N'Language',                              @value=N'Represents a spoken/written language.',                                         @name=N'MS_Description', @level0type=N'SCHEMA', @level1type=N'TABLE';
GO
EXEC sp_addextendedproperty @level0name=N'Core', @level1name=N'Language', @level2name=N'LanguageCode', @value=N'Identifier of the language.',                                                   @name=N'MS_Description', @level0type=N'SCHEMA', @level1type=N'TABLE', @level2type=N'COLUMN';
GO
EXEC sp_addextendedproperty @level0name=N'Core', @level1name=N'Language', @level2name=N'LanguageName', @value=N'Name of the language.',                                                         @name=N'MS_Description', @level0type=N'SCHEMA', @level1type=N'TABLE', @level2type=N'COLUMN';
GO
EXEC sp_addextendedproperty @level0name=N'Core', @level1name=N'Language', @level2name=N'NativeName',   @value=N'Native name of the language.',                                                  @name=N'MS_Description', @level0type=N'SCHEMA', @level1type=N'TABLE', @level2type=N'COLUMN';
GO
EXEC sp_addextendedproperty @level0name=N'Core', @level1name=N'Language', @level2name=N'RowStatusId',  @value=N'Identifier of the status for the record (i.e. enabled, disabled, deleted, etc.).',             @name=N'MS_Description', @level0type=N'SCHEMA', @level1type=N'TABLE', @level2type=N'COLUMN';
GO
EXEC sp_addextendedproperty @level0name=N'Core', @level1name=N'Language', @level2name=N'pkcLanguage',  @value=N'Defines the primary key for the Language table using the LanguageCode column.', @name=N'MS_Description', @level0type=N'SCHEMA', @level1type=N'TABLE', @level2type=N'CONSTRAINT';
GO