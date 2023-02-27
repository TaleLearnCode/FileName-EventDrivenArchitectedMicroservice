﻿CREATE TABLE Core.WorldRegion
(
  WorldRegionCode CHAR(3)      NOT NULL,
  WorldRegionName VARCHAR(100) NOT NULL,
  ParentId        CHAR(3)          NULL,
  RowStatusId     INT          NOT NULL,
  CONSTRAINT pkcWorldRegion PRIMARY KEY CLUSTERED (WorldRegionCode ASC),
  CONSTRAINT fkWorldRegion_WorldRegion FOREIGN KEY (ParentId) REFERENCES Core.WorldRegion (WorldRegionCode)
);
GO

CREATE NONCLUSTERED INDEX idxWorldRegion_ParentId ON Core.WorldRegion(ParentId ASC);
GO

EXEC sp_addextendedproperty @level0name=N'Core', @level1name=N'WorldRegion',                                           @value=N'Lookup table representing the world regions as defined by the UN M49 specification.', @name=N'MS_Description', @level0type=N'SCHEMA', @level1type=N'TABLE';
GO
EXEC sp_addextendedproperty @level0name=N'Core', @level1name=N'WorldRegion', @level2name=N'WorldRegionCode',           @value=N'Identifier of the world region.',                                                     @name=N'MS_Description', @level0type=N'SCHEMA', @level1type=N'TABLE', @level2type=N'COLUMN';
GO
EXEC sp_addextendedproperty @level0name=N'Core', @level1name=N'WorldRegion', @level2name=N'WorldRegionName',           @value=N'Name of the world region.',                                                           @name=N'MS_Description', @level0type=N'SCHEMA', @level1type=N'TABLE', @level2type=N'COLUMN';
GO
EXEC sp_addextendedproperty @level0name=N'Core', @level1name=N'WorldRegion', @level2name=N'ParentId',                  @value=N'Identifier of the world region parent (for subregions).',                             @name=N'MS_Description', @level0type=N'SCHEMA', @level1type=N'TABLE', @level2type=N'COLUMN';
GO
EXEC sp_addextendedproperty @level0name=N'Core', @level1name=N'WorldRegion', @level2name=N'RowStatusId',               @value=N'Identifier of the status for the record (i.e. enabled, disabled, deleted, etc.).',             @name=N'MS_Description', @level0type=N'SCHEMA', @level1type=N'TABLE', @level2type=N'COLUMN';
GO
EXEC sp_addextendedproperty @level0name=N'Core', @level1name=N'WorldRegion', @level2name=N'pkcWorldRegion',            @value=N'Defines the primary key for the WorldRegion table.',                                  @name=N'MS_Description', @level0type=N'SCHEMA', @level1type=N'TABLE', @level2type=N'CONSTRAINT';
GO
EXEC sp_addextendedproperty @level0name=N'Core', @level1name=N'WorldRegion', @level2name=N'fkWorldRegion_WorldRegion', @value=N'Defines the relationship between the WorldRegion and WorldRegion tables.',            @name=N'MS_Description', @level0type=N'SCHEMA', @level1type=N'TABLE', @level2type=N'CONSTRAINT';
GO
EXEC sp_addextendedproperty @level0name=N'Core', @level1name=N'WorldRegion', @level2name=N'idxWorldRegion_ParentId',   @value=N'Defines an index on the WorldRegion table using the ParentId column.',                @name=N'MS_Description', @level0type=N'SCHEMA', @level1type=N'TABLE', @level2type=N'INDEX';
GO