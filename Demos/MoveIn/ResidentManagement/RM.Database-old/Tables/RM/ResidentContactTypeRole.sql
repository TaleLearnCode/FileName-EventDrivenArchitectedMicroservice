CREATE TABLE RM.ResidentContactTypeRole
(
  ResidentContactTypeRoleId   INT           NOT NULL,
  ResidentContactTypeRoleName NVARCHAR(100) NOT NULL,
  RowStatusId         INT           NOT NULL,
  CONSTRAINT pkcResidentContactTypeRole PRIMARY KEY CLUSTERED (ResidentContactTypeRoleId)
)
GO