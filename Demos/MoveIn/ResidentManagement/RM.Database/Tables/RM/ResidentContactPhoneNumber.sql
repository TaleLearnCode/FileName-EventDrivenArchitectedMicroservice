CREATE TABLE RM.ResidentContactPhoneNumber
(
  ResidentContactPhoneNumberId INT           NOT NULL IDENTITY (1,1),
  ResidentContactId            INT           NOT NULL,
  PhoneNumberTypeId            INT           NOT NULL,
  ExternalId                   NVARCHAR(100)     NULL,
  CountryCode                  VARCHAR(10)       NULL,
  PhoneNumber                  VARCHAR(100)  NOT NULL,
  IsDefault                    BIT           NOT NULL CONSTRAINT dfContactPhoneNumber_IsDefault DEFAULT (0),
  CONSTRAINT pkcContactPhoneNumber PRIMARY KEY (ResidentContactPhoneNumberId),
  CONSTRAINT fkContactPhoneNumber_Contact                 FOREIGN KEY (ResidentContactId) REFERENCES RM.ResidentContact         (ResidentContactId),
  CONSTRAINT fkContactPhoneNumber_ResidentPhoneNumberType FOREIGN KEY (PhoneNumberTypeId) REFERENCES RM.ResidentPhoneNumberType (PhoneNumberTypeId)
)
GO