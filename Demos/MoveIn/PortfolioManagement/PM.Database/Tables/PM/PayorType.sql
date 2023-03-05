CREATE TABLE PM.PayorType
(
  PayorTypeId                  INT           NOT NULL IDENTITY(1,1),
  ExternalId                   NVARCHAR(100)     NULL,
  PayorTypeName                NVARCHAR(100) NOT NULL,
  IsDefault                    BIT           NOT NULL CONSTRAINT dfPayorType_IsDefault DEFAULT(0),
  SortOrder                    INT               NULL,
  RowStatusId                  INT           NOT NULL CONSTRAINT dfPayorType_RowStatusId DEFAULT(1),
  CONSTRAINT pkcPayorType PRIMARY KEY CLUSTERED (PayorTypeId)
)
GO

CREATE UNIQUE NONCLUSTERED INDEX unqPayorType_ExternalId ON PM.PayorType (ExternalId) WHERE ExternalId IS NOT NULL
GO

EXEC sp_addextendedproperty @level0name=N'PM', @level1name=N'PayorType',                                         @value=N'Represents a type of payor.',                                                        @name=N'MS_Description', @level0type=N'SCHEMA', @level1type=N'TABLE';
GO
EXEC sp_addextendedproperty @level0name=N'PM', @level1name=N'PayorType', @level2name=N'PayorTypeId',             @value=N'Identifier of the payor type.',                                                      @name=N'MS_Description', @level0type=N'SCHEMA', @level1type=N'TABLE', @level2type=N'COLUMN';
GO
EXEC sp_addextendedproperty @level0name=N'PM', @level1name=N'PayorType', @level2name=N'PayorTypeName',           @value=N'The name of the payor type.',                                                        @name=N'MS_Description', @level0type=N'SCHEMA', @level1type=N'TABLE', @level2type=N'COLUMN';
GO
EXEC sp_addextendedproperty @level0name=N'PM', @level1name=N'PayorType', @level2name=N'ExternalId',              @value=N'The tenant''s identifier for the payor type.',                                       @name=N'MS_Description', @level0type=N'SCHEMA', @level1type=N'TABLE', @level2type=N'COLUMN';
GO
EXEC sp_addextendedproperty @level0name=N'PM', @level1name=N'PayorType', @level2name=N'SortOrder',               @value=N'The sort order of the payor type within the full listing of payor types.',           @name=N'MS_Description', @level0type=N'SCHEMA', @level1type=N'TABLE', @level2type=N'COLUMN';
GO
EXEC sp_addextendedproperty @level0name=N'PM', @level1name=N'PayorType', @level2name=N'RowStatusId',             @value=N'Identifier of the status for the row (i.e. enabled, disabled, etc.).',               @name=N'MS_Description', @level0type=N'SCHEMA', @level1type=N'TABLE', @level2type=N'COLUMN';
GO
EXEC sp_addextendedproperty @level0name=N'PM', @level1name=N'PayorType', @level2name=N'pkcPayorType',            @value=N'Defines the primary key for the PayorType table using the PayerTypeId column.',      @name=N'MS_Description', @level0type=N'SCHEMA', @level1type=N'TABLE', @level2type=N'CONSTRAINT';
GO
EXEC sp_addextendedproperty @level0name=N'PM', @level1name=N'PayorType', @level2name=N'dfPayorType_RowStatusId', @value=N'Defines the default value for the RowStatusId column as 1 (enabled).',               @name=N'MS_Description', @level0type=N'SCHEMA', @level1type=N'TABLE', @level2type=N'CONSTRAINT';
GO