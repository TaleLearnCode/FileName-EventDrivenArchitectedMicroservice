MERGE Core.RowStatus AS TARGET
USING (VALUES (1, 1, 1, 'Enabled'),
              (2, 1, 1, 'Disabled'),
              (3, 0, 1, 'Deleted'))
AS SOURCE (RowStatusId,
           IsDisplayed,
           IsActive,
           RowStatusName)
ON TARGET.RowStatusId = SOURCE.RowStatusId
WHEN MATCHED THEN UPDATE SET TARGET.RowStatusName = SOURCE.RowStatusName,
                             TARGET.IsDisplayed   = SOURCE.IsDisplayed,
                             TARGET.IsActive      = SOURCE.IsActive
WHEN NOT MATCHED THEN INSERT (RowStatusId,
                              RowStatusName,
                              IsDisplayed,
                              IsActive)
                      VALUES (SOURCE.RowStatusId,
                              SOURCE.RowStatusName,
                              SOURCE.IsDisplayed,
                              SOURCE.IsActive)
WHEN NOT MATCHED BY SOURCE THEN DELETE;