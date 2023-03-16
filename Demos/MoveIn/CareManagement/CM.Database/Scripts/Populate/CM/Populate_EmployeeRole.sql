SET IDENTITY_INSERT CM.EmployeeRole ON
GO

MERGE CM.EmployeeRole AS TARGET
USING (VALUES (1, 'Community Director',       'CD'),
              (2, 'Asst Community Directory', 'ACD'),
              (3, 'Sales Representative',     'SR'),
              (4, 'Activity Director',        'AD'),
              (5, 'Chef',                     NULL),
              (6, 'Kitchen Staff',            'KP'),
              (7, 'Cleaning Staff',           'CS'),
              (8, 'Care Manager',             'CM'),
              (9, 'Care Provider',            'CP'))
AS SOURCE (EmployeeRoleId,
           EmployeeRoleName,
           EmployeeRoleCode)
ON TARGET.EmployeeRoleId = SOURCE.EmployeeRoleId
WHEN MATCHED THEN UPDATE SET TARGET.EmployeeRoleName = SOURCE.EmployeeRoleName,
                             TARGET.EmployeeRoleCode = SOURCE.EmployeeRoleCode
WHEN NOT MATCHED THEN INSERT (EmployeeRoleId,
                              EmployeeRoleName,
                              EmployeeRoleCode)
                      VALUES (SOURCE.EmployeeRoleId,
                              SOURCE.EmployeeRoleName,
                              SOURCE.EmployeeRoleCode);

SET IDENTITY_INSERT CM.EmployeeRole OFF
GO