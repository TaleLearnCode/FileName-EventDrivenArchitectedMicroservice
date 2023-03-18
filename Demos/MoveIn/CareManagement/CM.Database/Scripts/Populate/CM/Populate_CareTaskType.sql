SET IDENTITY_INSERT CM.CareTaskType ON
GO

MERGE CM.CareTaskType AS TARGET
USING (VALUES (1, 1, 1, 1, 'Welcome new resident'),
              (2, 1, 4, 1, 'Introduce new resident to available activities'),
              (3, 1, 5, 1, 'Get food preferences from new resident'),
              (4, 1, 7, 1, 'Weekly apartment cleaning'))
AS SOURCE (CareTaskTypeId,
           RowStatusId,
           EmployeeRoleId,
           AssignToNewResidents,
           CareTaskTypeName)
ON TARGET.CareTaskTypeId = SOURCE.CareTaskTypeId
WHEN MATCHED THEN UPDATE SET TARGET.CareTaskTypeName     = SOURCE.CareTaskTypeName,
                             TARGET.EmployeeRoleId       = SOURCE.EmployeeRoleId,
                             TARGET.AssignToNewResidents = SOURCE.AssignToNewResidents,
                             TARGET.RowStatusId          = SOURCE.RowStatusId
WHEN NOT MATCHED THEN INSERT (CareTaskTypeId,
                              CareTaskTypeName,
                              EmployeeRoleId,
                              AssignToNewResidents,
                              RowStatusId)
                      VALUES (SOURCE.CareTaskTypeId,
                              SOURCE.CareTaskTypeName,
                              SOURCE.EmployeeRoleId,
                              SOURCE.AssignToNewResidents,
                              SOURCE.RowStatusId);
GO

SET IDENTITY_INSERT CM.CareTaskType OFF
GO