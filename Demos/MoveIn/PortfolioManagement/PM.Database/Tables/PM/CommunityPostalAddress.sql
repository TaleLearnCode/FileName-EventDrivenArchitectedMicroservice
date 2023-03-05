CREATE TABLE PM.CommunityPostalAddress
(
  CommunityPostalAddressId INT           NOT NULL IDENTITY (1, 1),
  CommunityId              INT           NOT NULL,
  ExternalId               NVARCHAR(100)     NULL,
  StreetAddress1           NVARCHAR(100)     NULL,
  StreetAddress2           NVARCHAR(100)     NULL,
  City                     NVARCHAR(100) NOT NULL,
  CountryDivisionCode      CHAR(3)           NULL,
  CountryCode              CHAR(2)       NOT NULL,
  PostalCode               NVARCHAR(20)      NULL,
  PostalAddressTypeId      INT               NULL,
	IsListingAddress         BIT           NOT NULL CONSTRAINT dfCommunityPostalAddress_IsListingAddress DEFAULT (0),
  CONSTRAINT pkcCommunityPostalAddress PRIMARY KEY CLUSTERED (CommunityPostalAddressId ASC),
  CONSTRAINT fkCommunityPostalAddress_Community         FOREIGN KEY (CommunityId)                      REFERENCES PM.Community (CommunityId),
  CONSTRAINT fkCommunityPostalAddress_Country           FOREIGN KEY (CountryCode)                      REFERENCES Core.Country (CountryCode),
  CONSTRAINT fkCommunityPostalAddress_CountryDivision   FOREIGN KEY (CountryCode, CountryDivisionCode) REFERENCES Core.CountryDivision(CountryCode, CountryDivisionCode),
  CONSTRAINT fkCommunityPostalAddress_PostalAddressType FOREIGN KEY (PostalAddressTypeId)              REFERENCES PM.PostalAddressType(PostalAddressTypeId)
)
GO