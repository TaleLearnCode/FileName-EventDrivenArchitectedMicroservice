CREATE TABLE RM.ResidentContactType
(
  ResidentContactTypeId     INT           NOT NULL,
  ExternalId                NVARCHAR(100)     NULL,
  ResidentContactTypeName   NVARCHAR(100) NOT NULL,
  ResidentContactTypeRoleId INT           NOT NULL,
  RowStatusId               INT           NOT NULL,
  CONSTRAINT pkcResidentContactType PRIMARY KEY CLUSTERED (ResidentContactTypeId),
  CONSTRAINT fkResidentContactType_ContactTypeRole FOREIGN KEY (ResidentContactTypeRoleId) REFERENCES RM.ResidentContactTypeRole (ResidentContactTypeRoleId)
)
GO