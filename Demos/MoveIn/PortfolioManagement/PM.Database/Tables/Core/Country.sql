﻿CREATE TABLE Core.Country
(
  CountryCode        CHAR(2)      NOT NULL,
  CountryName        VARCHAR(100) NOT NULL,
  WorldRegionCode    CHAR(3)      NOT NULL,
  WorldSubregionCode CHAR(3)          NULL,
  HasDivisions       BIT          NOT NULL,
  DivisionName       VARCHAR(100)     NULL,
  RowStatusId        INT          NOT NULL,
  CONSTRAINT pkcCountry PRIMARY KEY CLUSTERED (CountryCode ASC),
  CONSTRAINT fkCountry_WorldRegion    FOREIGN KEY (WorldRegionCode)    REFERENCES Core.WorldRegion (WorldRegionCode),
  CONSTRAINT fkCountry_WorldSubregion FOREIGN KEY (WorldSubregionCode) REFERENCES Core.WorldRegion (WorldRegionCode)
);
GO

CREATE NONCLUSTERED INDEX idxCountry_WorldRegionCode ON Core.Country(WorldRegionCode ASC);
GO

CREATE NONCLUSTERED INDEX idxCountry_WorldSubregionCode ON Core.Country(WorldSubregionCode ASC);
GO

EXEC sp_addextendedproperty @level0name=N'Core', @level1name=N'Country',                                               @value=N'Lookup table representing the countries as defined by the ISO 3166-1 standard.',               @name=N'MS_Description', @level0type=N'SCHEMA', @level1type=N'TABLE';
GO
EXEC sp_addextendedproperty @level0name=N'Core', @level1name=N'Country', @level2name=N'CountryCode',                   @value=N'Identifier of the country as defined by ISO 3166-1.',                                          @name=N'MS_Description', @level0type=N'SCHEMA', @level1type=N'TABLE', @level2type=N'COLUMN';
GO
EXEC sp_addextendedproperty @level0name=N'Core', @level1name=N'Country', @level2name=N'CountryName',                   @value=N'Name of the country using the ISO 3166-1 Country Name.',                                       @name=N'MS_Description', @level0type=N'SCHEMA', @level1type=N'TABLE', @level2type=N'COLUMN';
GO
EXEC sp_addextendedproperty @level0name=N'Core', @level1name=N'Country', @level2name=N'WorldRegionCode',               @value=N'Identifier of the world region where the country is located.',                                 @name=N'MS_Description', @level0type=N'SCHEMA', @level1type=N'TABLE', @level2type=N'COLUMN';
GO
EXEC sp_addextendedproperty @level0name=N'Core', @level1name=N'Country', @level2name=N'WorldSubregionCode',            @value=N'Identifier of the world subregion where the country is located.',                              @name=N'MS_Description', @level0type=N'SCHEMA', @level1type=N'TABLE', @level2type=N'COLUMN';
GO
EXEC sp_addextendedproperty @level0name=N'Core', @level1name=N'Country', @level2name=N'HasDivisions',                  @value=N'Flag indicating whether the country has divisions (states, provinces, etc.).',                 @name=N'MS_Description', @level0type=N'SCHEMA', @level1type=N'TABLE', @level2type=N'COLUMN';
GO
EXEC sp_addextendedproperty @level0name=N'Core', @level1name=N'Country', @level2name=N'DivisionName',                  @value=N'The primary name of the country''s divisions.',                                                @name=N'MS_Description', @level0type=N'SCHEMA', @level1type=N'TABLE', @level2type=N'COLUMN';
GO
EXEC sp_addextendedproperty @level0name=N'Core', @level1name=N'Country', @level2name=N'RowStatusId',                   @value=N'Identifier of the status for the record (i.e. enabled, disabled, deleted, etc.).',             @name=N'MS_Description', @level0type=N'SCHEMA', @level1type=N'TABLE', @level2type=N'COLUMN';
GO
EXEC sp_addextendedproperty @level0name=N'Core', @level1name=N'Country', @level2name=N'pkcCountry',                    @value=N'Defines the primary key for the Country table using the CountryId column.',                    @name=N'MS_Description', @level0type=N'SCHEMA', @level1type=N'TABLE', @level2type=N'CONSTRAINT';
GO
EXEC sp_addextendedproperty @level0name=N'Core', @level1name=N'Country', @level2name=N'fkCountry_WorldRegion',         @value=N'Defines the relationship between the Country and WorldRegion tables for the World Region.',    @name=N'MS_Description', @level0type=N'SCHEMA', @level1type=N'TABLE', @level2type=N'CONSTRAINT';
GO
EXEC sp_addextendedproperty @level0name=N'Core', @level1name=N'Country', @level2name=N'fkCountry_WorldSubregion',      @value=N'Defines the relationship between the Country and WorldRegion tables for the World Subregion.', @name=N'MS_Description', @level0type=N'SCHEMA', @level1type=N'TABLE', @level2type=N'CONSTRAINT';
GO
EXEC sp_addextendedproperty @level0name=N'Core', @level1name=N'Country', @level2name=N'idxCountry_WorldRegionCode',    @value=N'Defines an index on the Country table using the WorldRegionCode column.',                      @name=N'MS_Description', @level0type=N'SCHEMA', @level1type=N'TABLE', @level2type=N'INDEX';
GO
EXEC sp_addextendedproperty @level0name=N'Core', @level1name=N'Country', @level2name=N'idxCountry_WorldSubregionCode', @value=N'Defines an index on the Country table using the WorldSubregionCode column.',                   @name=N'MS_Description', @level0type=N'SCHEMA', @level1type=N'TABLE', @level2type=N'INDEX';
GO