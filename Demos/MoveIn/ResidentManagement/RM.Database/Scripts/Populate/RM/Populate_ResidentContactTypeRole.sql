MERGE RM.ResidentContactTypeRole AS TARGET
USING (VALUES (1, 1, 'Resident'),
              (2, 1, 'Responsible Party'),
              (3, 1, 'Interested Party'),
              (4, 1, 'Emergency Contact'))
AS SOURCE (ResidentContactTypeRoleId,
           RowStatusId,
           ResidentContactTypeRoleName)
ON TARGET.ResidentContactTypeRoleId = SOURCE.ResidentContactTypeRoleId
WHEN MATCHED THEN UPDATE SET TARGET.ResidentContactTypeRoleName = SOURCE.ResidentContactTypeRoleName,
                             TARGET.RowStatusId                 = SOURCE.RowStatusId
WHEN NOT MATCHED THEN INSERT (ResidentContactTypeRoleId,
                              ResidentContactTypeRoleName,
                              RowStatusId)
                      VALUES (SOURCE.ResidentContactTypeRoleId,
                              SOURCE.ResidentContactTypeRoleName,
                              SOURCE.RowStatusId);
GO