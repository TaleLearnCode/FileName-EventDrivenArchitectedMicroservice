SET IDENTITY_INSERT CM.CareTaskStatus ON
GO

MERGE CM.CareTaskStatus AS TARGET
USING (VALUES (1, 1, 1, 'To be scheduled'),
              (2, 1, 1, 'Scheduled'))
AS SOURCE (CareTaskStatusId,
           RowStatusId,
           IsDefault,
           CareTaskStatusName)
ON TARGET.CareTaskStatusId = SOURCE.CareTaskStatusId
WHEN MATCHED THEN UPDATE SET TARGET.CareTaskStatusName = SOURCE.CareTaskStatusName,
                             TARGET.IsDefault          = SOURCE.IsDefault,
                             TARGET.RowStatusId        = SOURCE.RowStatusId
WHEN NOT MATCHED THEN INSERT (CareTaskStatusId,
                              CareTaskStatusName,
                              IsDefault,
                              RowStatusId)
                      VALUES (CareTaskStatusId,
                              CareTaskStatusName,
                              IsDefault,
                              RowStatusId);

SET IDENTITY_INSERT CM.CareTaskStatus OFF
GO