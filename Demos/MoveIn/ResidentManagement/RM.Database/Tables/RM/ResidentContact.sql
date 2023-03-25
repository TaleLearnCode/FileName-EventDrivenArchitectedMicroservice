CREATE TABLE RM.ResidentContact
(
  ResidentContactId         INT           NOT NULL IDENTITY(1,1),
  ExternalId                NVARCHAR(100)     NULL,
  ResidentId                INT           NOT NULL,
  ResidentContactTypeId     INT           NOT NULL,
  SuffixId                  INT               NULL,
  FirstName                 NVARCHAR(100)     NULL,
  MiddleName                NVARCHAR(100)     NULL,
  LastName                  NVARCHAR(100) NOT NULL,
  EmailAddress              NVARCHAR(200)     NULL,
  HasPowerOfAttorney        BIT           NOT NULL CONSTRAINT dfResidentContact_HasPowerOfAttorney DEFAULT (0),
  HasDurablePowerOfAttorney BIT           NOT NULL CONSTRAINT dfResidentContact_HasDurablePowerOfAttorney DEFAULT (0),
  IsLegalGuardian           BIT           NOT NULL CONSTRAINT dfResidentContact_IsLegalGuardian DEFAULT (0),
  IsMedicalPowerOfAttorney  BIT           NOT NULL CONSTRAINT dfResidentContact_IsMedicalPowerOfAttorney DEFAULT (0),
  CONSTRAINT pkcResidentContact PRIMARY KEY CLUSTERED (ResidentContactId),
  CONSTRAINT fkResidentContact_Resident    FOREIGN KEY (ResidentId)            REFERENCES RM.Resident (ResidentId),
  CONSTRAINT fkResidentContact_ContactType FOREIGN KEY (ResidentContactTypeId) REFERENCES RM.ResidentContactType (ResidentContactTypeId)
)
GO