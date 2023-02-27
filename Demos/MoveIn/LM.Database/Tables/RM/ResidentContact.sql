CREATE TABLE RM.ResidentContact
(
  ResidentContactId         INT           NOT NULL IDENTITY(1,1),
  SuffixId                  INT               NULL,
  FirstName                 NVARCHAR(100)     NULL,
  MiddleName                NVARCHAR(100)     NULL,
  LastName                  NVARCHAR(100) NOT NULL,
  StreetAddress1            NVARCHAR(100)     NULL,
  StreetAddress2            NVARCHAR(100)     NULL,
  City                      NVARCHAR(100) NOT NULL,
  CountryDivisionCode       CHAR(3)           NULL,
  CountryCode               CHAR(2)       NOT NULL,
  PostalCode                NVARCHAR(20)      NULL,
  CONSTRAINT pkcResidentContact PRIMARY KEY CLUSTERED (ResidentContactId)
)
GO