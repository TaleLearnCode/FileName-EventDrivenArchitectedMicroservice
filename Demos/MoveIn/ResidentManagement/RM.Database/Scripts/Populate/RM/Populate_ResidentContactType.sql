MERGE RM.ResidentContactType AS TARGET
USING (VALUES ( 1, 1, 1, 'Resident'),
              ( 2, 1, 3, 'Hospital'),
              ( 3, 1, 4, 'Emergency Contact'),
              ( 4, 1, 3, 'Physician'),
              ( 5, 1, 2, 'Responsible Party'),
              ( 6, 1, 3, 'Pharmacy'),
              ( 7, 1, 3, 'Mortuary'),
              ( 8, 1, 3, 'Ambulance'),
              ( 9, 1, 3, 'Insurance'),
              (10, 1, 3, 'Interested Party'),
              (11, 1, 3, 'Lessee'))
AS SOURCE (ResidentContactTypeId,
           RowStatusId,
           ResidentContactTypeRoleId,
           ResidentContactTypeName)
ON TARGET.ResidentContactTypeId = SOURCE.ResidentContactTypeId
WHEN MATCHED THEN UPDATE SET TARGET.ResidentContactTypeRoleId = SOURCE.ResidentContactTypeRoleId,
                             TARGET.ResidentContactTypeName   = SOURCE.ResidentContactTypeName,
                             TARGET.RowStatusId               = SOURCE.RowStatusId
WHEN NOT MATCHED THEN INSERT (ResidentContactTypeId,
                              ResidentContactTypeRoleId,
                              ResidentContactTypeName,
                              RowStatusId)
                      VALUES (SOURCE.ResidentContactTypeId,
                              SOURCE.ResidentContactTypeRoleId,
                              SOURCE.ResidentContactTypeName,
                              SOURCE.RowStatusId);
GO