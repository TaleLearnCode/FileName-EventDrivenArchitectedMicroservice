CREATE TABLE RM.ResidentPhoneNumberType
(
	PhoneNumberTypeId   INT           NOT NULL IDENTITY (1, 1),
	ExternalId          NVARCHAR(100)     NULL,
	PhoneNumberTypeName VARCHAR(100)  NOT NULL,
	SortOrder           INT               NULL,
	IsDefault           BIT           NOT NULL CONSTRAINT dfPhoneNumberType_IsDefault   DEFAULT (0),
	RowStatusId         INT           NOT NULL CONSTRAINT dfPhoneNumberType_RowStatusId DEFAULT (1),
	CONSTRAINT pkcPhoneNumberType PRIMARY KEY CLUSTERED (PhoneNumberTypeId)
);
GO

CREATE UNIQUE NONCLUSTERED INDEX unqResidentPhoneNumberType_ExternalId ON RM.ResidentPhoneNumberType (ExternalId) WHERE ExternalId IS NOT NULL
GO

EXEC sp_addextendedproperty @level0name=N'RM', @level1name=N'ResidentPhoneNumberType',                                               @value=N'Lookup values representing phone number types used by Glennis.',                            @name=N'MS_Description', @level0type=N'SCHEMA', @level1type=N'TABLE';
GO
EXEC sp_addextendedproperty @level0name=N'RM', @level1name=N'ResidentPhoneNumberType', @level2name=N'PhoneNumberTypeId',             @value=N'Identifier of the phone number type.',                                                      @name=N'MS_Description', @level0type=N'SCHEMA', @level1type=N'TABLE', @level2type=N'COLUMN';
GO
EXEC sp_addextendedproperty @level0name=N'RM', @level1name=N'ResidentPhoneNumberType', @level2name=N'ExternalId',                    @value=N'The operator identifier for the phone number type.',                                        @name=N'MS_Description', @level0type=N'SCHEMA', @level1type=N'TABLE', @level2type=N'COLUMN';
GO
EXEC sp_addextendedproperty @level0name=N'RM', @level1name=N'ResidentPhoneNumberType', @level2name=N'PhoneNumberTypeName',           @value=N'Name of the phone number type.',                                                            @name=N'MS_Description', @level0type=N'SCHEMA', @level1type=N'TABLE', @level2type=N'COLUMN';
GO
EXEC sp_addextendedproperty @level0name=N'RM', @level1name=N'ResidentPhoneNumberType', @level2name=N'SortOrder',                     @value=N'The sorting order of the phone number type.',                                               @name=N'MS_Description', @level0type=N'SCHEMA', @level1type=N'TABLE', @level2type=N'COLUMN';
GO
EXEC sp_addextendedproperty @level0name=N'RM', @level1name=N'ResidentPhoneNumberType', @level2name=N'IsDefault',                     @value=N'Flag indicating whether the phone number type is the default phone number type.',           @name=N'MS_Description', @level0type=N'SCHEMA', @level1type=N'TABLE', @level2type=N'COLUMN';
GO
EXEC sp_addextendedproperty @level0name=N'RM', @level1name=N'ResidentPhoneNumberType', @level2name=N'RowStatusId',                   @value=N'Identifier of the status for the row (i.e. enabled, disabled, etc.).',                      @name=N'MS_Description', @level0type=N'SCHEMA', @level1type=N'TABLE', @level2type=N'COLUMN';
GO
EXEC sp_addextendedproperty @level0name=N'RM', @level1name=N'ResidentPhoneNumberType', @level2name=N'pkcPhoneNumberType',            @value=N'Defines the primary key for the PhoneNumberType table using the PhoneNumberTypeId column.', @name=N'MS_Description', @level0type=N'SCHEMA', @level1type=N'TABLE', @level2type=N'CONSTRAINT';
GO
EXEC sp_addextendedproperty @level0name=N'RM', @level1name=N'ResidentPhoneNumberType', @level2name=N'dfPhoneNumberType_IsDefault',   @value=N'Defines the default value for the IsDefault to 0 (false).',                                 @name=N'MS_Description', @level0type=N'SCHEMA', @level1type=N'TABLE', @level2type=N'CONSTRAINT';
GO
EXEC sp_addextendedproperty @level0name=N'RM', @level1name=N'ResidentPhoneNumberType', @level2name=N'dfPhoneNumberType_RowStatusId', @value=N'Defines the default value for the RowStatusId column as 1 (enabled).',                      @name=N'MS_Description', @level0type=N'SCHEMA', @level1type=N'TABLE', @level2type=N'CONSTRAINT';
GO