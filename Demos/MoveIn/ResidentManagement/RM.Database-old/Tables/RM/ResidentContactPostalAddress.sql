CREATE TABLE PM.ResidentContactPostalAddress
(
  ResidentContactPostalAddressId INT           NOT NULL IDENTITY (1, 1),
  ResidentContactId              INT           NOT NULL,
  ExternalId                     NVARCHAR(100)     NULL,
  StreetAddress1                 NVARCHAR(100)     NULL,
  StreetAddress2                 NVARCHAR(100)     NULL,
  City                           NVARCHAR(100) NOT NULL,
  CountryDivisionCode            CHAR(3)           NULL,
  CountryCode                    CHAR(2)       NOT NULL,
  PostalCode                     NVARCHAR(20)      NULL,
  PostalAddressTypeId            INT               NULL,
  CONSTRAINT pkcCommunityPostalAddress PRIMARY KEY CLUSTERED (ResidentContactPostalAddressId),
  CONSTRAINT fkCommunityPostalAddress_Contact                   FOREIGN KEY (ResidentContactId)                REFERENCES RM.ResidentContact           (ResidentContactId),
  CONSTRAINT fkCommunityPostalAddress_Country                   FOREIGN KEY (CountryCode)                      REFERENCES Core.Country                 (CountryCode),
  CONSTRAINT fkCommunityPostalAddress_CountryDivision           FOREIGN KEY (CountryCode, CountryDivisionCode) REFERENCES Core.CountryDivision         (CountryCode, CountryDivisionCode),
  CONSTRAINT fkCommunityPostalAddress_ResidentPostalAddressType FOREIGN KEY (PostalAddressTypeId)              REFERENCES RM.ResidentPostalAddressType (PostalAddressTypeId)
)
GO