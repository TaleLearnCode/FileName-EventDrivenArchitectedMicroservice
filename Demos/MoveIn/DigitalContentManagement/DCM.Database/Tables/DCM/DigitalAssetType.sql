CREATE TABLE DCM.DigitalAssetType
(
	DigitalAssetTypeId   INT          NOT NULL,
	DigitalAssetTypeName VARCHAR(100) NOT NULL,
	Discriminator        VARCHAR(20)  NOT NULL,
	SortOrder            INT          NOT NULL,
	RowStatusId          INT          NOT NULL,
	CONSTRAINT pkcDigitalAssetType PRIMARY KEY CLUSTERED (DigitalAssetTypeId)
)
GO

EXEC sp_addextendedproperty @level0name=N'DCM', @level1name=N'DigitalAssetType',                                      @value=N'Defines the types of digital asset locations supported by the system.',                       @name=N'MS_Description', @level0type=N'SCHEMA', @level1type=N'TABLE';
GO
EXEC sp_addextendedproperty @level0name=N'DCM', @level1name=N'DigitalAssetType', @level2name=N'DigitalAssetTypeId',   @value=N'Identifier of the Digital Asset Type record.',                                                @name=N'MS_Description', @level0type=N'SCHEMA', @level1type=N'TABLE', @level2type=N'COLUMN';
GO
EXEC sp_addextendedproperty @level0name=N'DCM', @level1name=N'DigitalAssetType', @level2name=N'DigitalAssetTypeName', @value=N'The name of the Digital Asset Type.',                                                         @name=N'MS_Description', @level0type=N'SCHEMA', @level1type=N'TABLE', @level2type=N'COLUMN';
GO
EXEC sp_addextendedproperty @level0name=N'DCM', @level1name=N'DigitalAssetType', @level2name=N'Discriminator',        @value=N'The discriminator used when saving the different digital asset types.',                       @name=N'MS_Description', @level0type=N'SCHEMA', @level1type=N'TABLE', @level2type=N'COLUMN';
GO
EXEC sp_addextendedproperty @level0name=N'DCM', @level1name=N'DigitalAssetType', @level2name=N'SortOrder',            @value=N'Sorting order of the Digital Asset Type.',                                                    @name=N'MS_Description', @level0type=N'SCHEMA', @level1type=N'TABLE', @level2type=N'COLUMN';
GO
EXEC sp_addextendedproperty @level0name=N'DCM', @level1name=N'DigitalAssetType', @level2name=N'RowStatusId',          @value=N'Identifier of the record status (i.e. enabled, disabled, deleted, etc.).',                    @name=N'MS_Description', @level0type=N'SCHEMA', @level1type=N'TABLE', @level2type=N'COLUMN';
GO
EXEC sp_addextendedproperty @level0name=N'DCM', @level1name=N'DigitalAssetType', @level2name=N'pkcDigitalAssetType',  @value=N'Defines the primary key for the DigitalAssetType table using the DigitalAssetTypeId column.', @name=N'MS_Description', @level0type=N'SCHEMA', @level1type=N'TABLE', @level2type=N'CONSTRAINT';
GO